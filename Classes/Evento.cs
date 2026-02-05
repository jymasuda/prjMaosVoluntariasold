using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class Evento : Banco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataLimiteInscricao { get; set; }
        public string Imagem { get; set; }
        public Empresa Empresa { get; set; }
        public CategoriaEvento CategoriaEvento { get; set; }
        public Cidade Cidade { get; set; }
        public Evento()
        {
        }

        public Evento(int codigo, string nome, string descricao, string endereco, DateTime dataInicio, string imagem, Empresa empresa)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            DataInicio = dataInicio;
            Empresa = empresa;
            Imagem = imagem;
        }

        public Evento(int codigo, string nome, string descricao, string endereco, DateTime dataInicio, DateTime dataFim, DateTime dataLimiteInscricao, string imagem, Empresa empresa, CategoriaEvento categoriaEvento, Cidade cidade)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataLimiteInscricao = dataLimiteInscricao;
            Empresa = empresa;
            CategoriaEvento = categoriaEvento;
            Cidade = cidade;
            Imagem = imagem;
        }

        public List<Evento> Listar()
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = null;

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarEventosComFuncao", parametros))
                {
                    while (dados.Read())
                    {
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        evento.Nome = dados.GetString(1);
                        evento.DataInicio = dados.GetDateTime(2);
                        evento.Descricao = dados.GetString(3);
                        evento.Endereco = dados.GetString(4);

                        if (dados[5] != null)
                        {
                            byte[] f = (byte[])dados[5];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }

                        Empresa empresa = new Empresa();
                        empresa.Nome = dados.GetString(6);
                        evento.Empresa = empresa;
                        eventos.Add(evento);
                    }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }

            
        }

        public Evento listarConteudo(int codigo)
        {
            Evento evento = new Evento();
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro("vCodigoEvento", codigo.ToString());
            parametros.Add(parametro);
           
            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarConteudoEvento", parametros))
                {
                    if (dados.Read())
                    {
                        evento.Codigo = codigo;
                        evento.Nome = dados.GetString(0);
                        evento.Descricao = dados.GetString(1);
                        evento.Endereco = dados.GetString(2);
                        evento.DataInicio = dados.GetDateTime(3);
                        evento.DataFim = dados.GetDateTime(4);
                        evento.DataLimiteInscricao = dados.GetDateTime(5);
                        if (dados[10] != null)
                        {
                            byte[] f = (byte[])dados[10];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }


                        CategoriaEvento categoria = new CategoriaEvento();
                        categoria.Nome = dados.GetString(6);
                        categoria.Codigo = dados.GetInt16(7);
                        evento.CategoriaEvento = categoria;

                        Empresa empresa = new Empresa();
                        empresa.Nome = dados.GetString(8);
                        if (dados[9] != null)
                        {
                            byte[] f = (byte[])dados[9];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            empresa.Foto = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }
                        evento.Empresa = empresa;

                    }
                        return evento;

                }
            }
            catch
            {
                return null;
            }

        }
        public int buscarPagMaxima(string busca, List<Cidade> cidades, List<CategoriaEvento> categorias, List<CategoriaFuncao> habilidades)
        {
            int numeroPaginas = 1;
            MySqlDataReader dados = null;
            StringBuilder cidadesComando = new StringBuilder();
            StringBuilder categoriasComando = new StringBuilder();
            StringBuilder habilidadesComando = new StringBuilder();
            StringBuilder comando = new StringBuilder($@"
                 Select ceiling(count(distinct(e.cd_Evento))/8) from funcao f 
                join funcao_evento fe on (f.cd_funcao = fe.cd_funcao)
                join evento e on (fe.cd_evento = e.cd_evento)
                join empresa em on e.nm_email = em.nm_email
                where e.dt_fim > current_date
                
                ");

            if (!String.IsNullOrEmpty(busca))
            {
                comando.Append($@"and (e.nm_evento like '{busca}%') or (f.nm_funcao like '{busca}%') or (em.nm_empresa like '{busca}%')");
            }

            if (cidades != null && cidades.Count > 0)
            {
                cidadesComando.Append($@" and (e.cd_cidade = {cidades[0].Codigo}");
                cidades.RemoveRange(0, 1);
                foreach (Cidade cidade in cidades)
                {
                    cidadesComando.Append($@" or e.cd_cidade = {cidade.Codigo} ");
                }
                cidadesComando.Append($@")");
                comando.Append(cidadesComando.ToString());
            }


            if (categorias != null && categorias.Count > 0)
            {
                categoriasComando.Append($@" and (e.cd_categoria_evento = {categorias[0].Codigo}");
                categorias.RemoveRange(0, 1);
                foreach (CategoriaEvento categoria in categorias)
                {
                    categoriasComando.Append($@" or e.cd_categoria_evento = {categoria.Codigo} ");
                }
                categoriasComando.Append($@")");
                comando.Append(categoriasComando.ToString());
            }

            if (habilidades != null && habilidades.Count > 0)
            {

                habilidadesComando.Append($@" and (f.cd_categoria_funcao = {habilidades[0].Codigo}");
                habilidades.RemoveRange(0, 1);
                foreach (CategoriaFuncao habilidade in habilidades)
                {
                    habilidadesComando.Append($@" or f.cd_categoria_funcao = {habilidade.Codigo} ");
                }
                habilidadesComando.Append($@")");
                comando.Append(habilidadesComando.ToString());
            }

            using (dados = Consultar(comando.ToString()))
                if (dados.Read())
                {
                    numeroPaginas = dados.GetInt32(0);
                }

            return numeroPaginas;
        }

        public List<Evento> Buscar(string busca, List<Cidade> cidades, List<CategoriaEvento> categorias, List<CategoriaFuncao> habilidades, int pagina)
        {
            MySqlDataReader dados = null;
            List<Evento> eventos = new List<Evento>();
            int offset = pagina;
            string b = busca;
            List<Cidade> c = new List<Cidade>(cidades);
            List<CategoriaEvento> ca = new List<CategoriaEvento>(categorias);
            List<CategoriaFuncao> h = new List<CategoriaFuncao>(habilidades);
            int numeroPaginas = buscarPagMaxima(b, c, ca, h);
            StringBuilder cidadesComando = new StringBuilder();
            StringBuilder categoriasComando = new StringBuilder();
            StringBuilder habilidadesComando = new StringBuilder();
            

            if(offset > numeroPaginas)
            {
                offset = numeroPaginas;
            }
            if (offset <= 0)
            {
                offset = 0;
            }
            else
            {
                offset = 8 * (offset - 1);
            }


            StringBuilder comando = new StringBuilder($@"
                Select distinct(e.cd_evento) as codigo, e.nm_evento, e.dt_inicio, e.ds_evento, e.ds_endereco, e.nm_imagem, em.nm_empresa from funcao f 
                join funcao_evento fe on f.cd_funcao = fe.cd_funcao
                join evento e on fe.cd_evento = e.cd_evento
                join empresa em on e.nm_email = em.nm_email
                where e.dt_fim > current_date
                
                ");

            if (!String.IsNullOrEmpty(busca))
            {
                comando.Append($@"and (e.nm_evento like '{busca}%') or (f.nm_funcao like '{busca}%') or (em.nm_empresa like '{busca}%')");
            }

            if (cidades != null && cidades.Count > 0)
            {
                cidadesComando.Append($@" and (e.cd_cidade = {cidades[0].Codigo}");
                cidades.RemoveRange(0, 1);
                foreach (Cidade cidade in cidades)
                {
                    cidadesComando.Append($@" or e.cd_cidade = {cidade.Codigo} ");
                }
                cidadesComando.Append($@")");
                comando.Append(cidadesComando.ToString());
            }


            if (categorias != null && categorias.Count > 0)
            {
                categoriasComando.Append($@" and (e.cd_categoria_evento = {categorias[0].Codigo}");
                categorias.RemoveRange(0, 1);
                foreach (CategoriaEvento categoria in categorias)
                {
                    categoriasComando.Append($@" or e.cd_categoria_evento = {categoria.Codigo} ");
                }
                categoriasComando.Append($@")");
                comando.Append(categoriasComando.ToString());
            }

            if (habilidades != null && habilidades.Count > 0)
            {

                habilidadesComando.Append($@" and (f.cd_categoria_funcao = {habilidades[0].Codigo}");
                habilidades.RemoveRange(0, 1);
                foreach (CategoriaFuncao habilidade in habilidades)
                {
                    habilidadesComando.Append($@" or f.cd_categoria_funcao = {habilidade.Codigo} ");
                }
                habilidadesComando.Append($@")");
                comando.Append(habilidadesComando.ToString());
            }

            comando.Append($@" order by dt_limite_inscricao limit 8 offset {offset};");

            
            try
            {
                using (dados = Consultar(comando.ToString())) 
                {
                    while (dados.Read()) 
                    {
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        evento.Nome = dados.GetString(1);
                        evento.DataInicio = dados.GetDateTime(2);
                        evento.Descricao = dados.GetString(3);
                        evento.Endereco = dados.GetString(4);

                        if (dados[5] != null)
                        {
                            byte[] f = (byte[])dados[5];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }

                        Empresa empresa = new Empresa();
                        empresa.Nome = dados.GetString(6);
                        evento.Empresa = empresa;
                        eventos.Add(evento);
                    }
                    
                }
            }
            catch
            (Exception)
            {
                throw new Exception("Não foi possível realizar a busca!");
            }

            return eventos;
        }

        public int proximoEvento()
        {
            int proximoCodigo = 0;
            List<Parametro> parametros = new List<Parametro>();
            parametros = null;

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("proximoEvento", parametros))
                {
                    if (dados.Read())
                    {
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        proximoCodigo = evento.Codigo;
                    }
                    return proximoCodigo;
                }
            }
            catch
            {
                return 0;
            }
        }

        public string buscarNomeEvento(string codigoEvento)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigo", codigoEvento));
            string nomeEvento = null;

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("buscarNomeEvento", parametros))
                {
                    if (dados.Read())
                    {
                        nomeEvento = dados.GetString(0);
                    }
                    return nomeEvento;
                }
            }
            catch
            {
                return null;
            }
        }

        public void Editar(string codigo, string titulo, string inicio, string fim, string endereco, string categoria, string descricao)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));
            parametros.Add(new Parametro("vNome", titulo.ToString()));
            parametros.Add(new Parametro("vInicio", inicio.ToString()));
            parametros.Add(new Parametro("vFim", fim.ToString()));
            parametros.Add(new Parametro("vEndereco", endereco.ToString()));
            parametros.Add(new Parametro("vCategoria", categoria.ToString()));
            parametros.Add(new Parametro("vDescricao", descricao.ToString()));

            Executar("editarEvento", parametros);
        }

        public List<Evento> listarEventosInscrito(string email, int offset)
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vOffset", offset.ToString()));

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarEventosInscrito", parametros))
                {
                    while (dados.Read())
                    {
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        evento.Nome = dados.GetString(1);
                        evento.DataInicio = dados.GetDateTime(2);
                        evento.Descricao = dados.GetString(3);
                        evento.Endereco = dados.GetString(4);

                        if (dados[5] != null)
                        {
                            byte[] f = (byte[])dados[5];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }

                        Empresa empresa = new Empresa();
                        empresa.Nome = dados.GetString(6);
                        evento.Empresa = empresa;
                        eventos.Add(evento);
                    }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }
        }

        public int contarEventosInscrito(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));

            MySqlDataReader dados = null;
            int numeroPaginas = 0;
            try
            {
                using (dados = Consultar("contarEventosInscrito", parametros))
                {
                    if (dados.Read())
                    {
                        numeroPaginas = dados.GetInt32(0);
                    }
                    else
                        numeroPaginas = -1;
                }
                return numeroPaginas;
            }
            catch
            {
                return -1;
            }

        }
        public List<Evento> listarEventosParticipado(string email, int offset)
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vOffset", offset.ToString()));

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarEventosParticipado", parametros))
                {
                    while (dados.Read())
                    {
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        evento.Nome = dados.GetString(1);
                        evento.DataInicio = dados.GetDateTime(2);
                        evento.Descricao = dados.GetString(3);
                        evento.Endereco = dados.GetString(4);

                        if (dados[5] != null)
                        {
                            byte[] f = (byte[])dados[5];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }

                        Empresa empresa = new Empresa();
                        empresa.Nome = dados.GetString(6);
                        evento.Empresa = empresa;
                        eventos.Add(evento);
                    }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }
        }
        public int contarEventosParticipado(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));

            MySqlDataReader dados = null;
            int numeroPaginas = 0;
            try
            {
                using (dados = Consultar("contarEventosParticipado", parametros))
                {
                    if (dados.Read())
                    {
                        numeroPaginas = dados.GetInt32(0);
                    }
                    else
                        numeroPaginas = -1;
                }
                return numeroPaginas;
            }
            catch
            {
                return -1;
            }

        }

        public List<Evento> listarEventosAcontecendo(string email, int offset)
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vOffset", offset.ToString()));

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarEventosAcontecendo", parametros))
                {
                    while (dados.Read())
                    {
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        evento.Nome = dados.GetString(1);
                        evento.DataInicio = dados.GetDateTime(2);
                        evento.Descricao = dados.GetString(3);
                        evento.Endereco = dados.GetString(4);

                        if (dados[5] != null)
                        {
                            byte[] f = (byte[])dados[5];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }

                        Empresa empresa = new Empresa();
                        empresa.Nome = dados.GetString(6);
                        evento.Empresa = empresa;
                        eventos.Add(evento);
                    }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }
        }
        public int contarEventosAcontecendo(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));

            MySqlDataReader dados = null;
            int numeroPaginas = 0;
            try
            {
                using (dados = Consultar("contarEventosAcontecendo", parametros))
                {
                    if (dados.Read())
                    {
                        numeroPaginas = dados.GetInt32(0);
                    }
                    else
                        numeroPaginas = -1;
                }
                return numeroPaginas;
            }
            catch
            {
                return -1;
            }

        }

        public List<Evento> listarEventosEncerrados(string email, int offset)
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vOffset", offset.ToString()));
            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarEventosEncerrados", parametros))
                {
                    while (dados.Read())
                    {
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        evento.Nome = dados.GetString(1);
                        evento.DataInicio = dados.GetDateTime(2);
                        evento.Descricao = dados.GetString(3);
                        evento.Endereco = dados.GetString(4);

                        if (dados[5] != null)
                        {
                            byte[] f = (byte[])dados[5];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }

                        Empresa empresa = new Empresa();
                        empresa.Nome = dados.GetString(6);
                        evento.Empresa = empresa;
                        eventos.Add(evento);
                    }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }
        }
        public int contarEventosEncerrado(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));

            MySqlDataReader dados = null;
            int numeroPaginas = 0;
            try
            {
                using (dados = Consultar("contarEventosEncerrado", parametros))
                {
                    if (dados.Read())
                    {
                        numeroPaginas = dados.GetInt32(0);
                    }
                    else
                        numeroPaginas = -1;
                }
                return numeroPaginas;
            }
            catch
            {
                return -1;
            }

        }

        public string buscarEmailEvento(string codigoEvento)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento));
            string emailEvento = null;

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("buscarEmailEvento", parametros))
                {
                    if (dados.Read())
                    {
                        emailEvento = dados.GetString(0);
                    }
                    return emailEvento;
                }
            }
            catch
            {
                return null;
            }
        }

        public int procurarQuantidadeVagas(int codigoEvento, int codigoFuncao)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento.ToString()));
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao.ToString()));

            int qtVagas;
            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("procurarQuantidadeVagas", parametros))
                {
                    if (dados.Read())
                    {
                       qtVagas = dados.GetInt32(0);
                        return qtVagas;
                    }
                    return -1;
                }
                
            }
            catch
            {
                return -1;
            }
        }

        public List<Evento> listarEventosInscricoesPendentes(string email)
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));


            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarEventosInscricoesPendentes", parametros))
                {
                    if(dados.HasRows)
                        while (dados.Read())
                        {
                                Evento evento = new Evento();
                                evento.Codigo = dados.GetInt32(0);
                                evento.Nome = dados.GetString(1);
                                evento.DataInicio = dados.GetDateTime(2);
                                evento.Descricao = dados.GetString(3);
                                evento.Endereco = dados.GetString(4);

                                if (!dados.IsDBNull(5))
                                {
                                    byte[] f = (byte[])dados[5];
                                    string base64 = Convert.ToBase64String(f, 0, f.Length);
                                    evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                                }

                                Empresa empresa = new Empresa();
                                empresa.Nome = dados.GetString(6);
                                evento.Empresa = empresa;
                                eventos.Add(evento);                        
                        }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }
        }

        public void deletar(int codigoEvento)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento.ToString()));

            Executar("deletarEvento", parametros);
        }

        public double calcularMediaAvaliacao(int codigo)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoEvento", codigo.ToString()));
            MySqlDataReader dados = null;
            double notaEmpresa = 0;
            try
            {
                using (dados = Consultar("calcularMediaAvaliacaoEvento", parametros))
                {
                    if (dados.Read())
                        if (!dados.IsDBNull(0))
                        {
                            notaEmpresa = dados.GetDouble(0);
                        }
                    
                }
                return notaEmpresa;
            }
            catch
            {
                return -1;
            }
        }

        public bool verificarEventoEncerrado(int codigo)
        {
            MySqlDataReader dados = null;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));

            using (dados = Consultar("buscarDataFim", parametros))
            {
                if (dados.Read())
                {
                    DataFim = dados.GetDateTime(0);
                    if (DataFim < DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        public List<Evento> procurarEventoAvaliacaoPendente(string email)
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));


            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("procurarEventoAvaliacaoPendente", parametros))
                {
                    if (dados.HasRows)
                        while (dados.Read())
                        {
                            Evento evento = new Evento();
                            evento.Codigo = dados.GetInt32(0);
                            evento.Nome = dados.GetString(1);
                            Empresa empresa = new Empresa();
                            empresa.Nome = dados.GetString(2);
                            if (dados[3] != null)
                            {
                                byte[] f = (byte[])dados[3];
                                string base64 = Convert.ToBase64String(f, 0, f.Length);
                                empresa.Foto = Convert.ToString("data:image/jpeg;base64,") + base64;
                            }
                            evento.Empresa = empresa;
                            eventos.Add(evento);
                        }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Evento> listarTodosEventosEncerrados(string email)
        {
            List<Evento> eventos = new List<Evento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));


            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarTodosEventosEncerrados", parametros))
                {
                    if (dados.HasRows)
                        while (dados.Read())
                        {
                            Evento evento = new Evento();
                            evento.Codigo = dados.GetInt32(0);
                            evento.Nome = dados.GetString(1);
                            evento.DataInicio = dados.GetDateTime(2);
                            evento.Descricao = dados.GetString(3);
                            evento.Endereco = dados.GetString(4);

                            if (dados[5] != null)
                            {
                                byte[] f = (byte[])dados[5];
                                string base64 = Convert.ToBase64String(f, 0, f.Length);
                                evento.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                            }

                            Empresa empresa = new Empresa();
                            empresa.Nome = dados.GetString(6);
                            evento.Empresa = empresa;
                            eventos.Add(evento);
                        }

                    return eventos;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}