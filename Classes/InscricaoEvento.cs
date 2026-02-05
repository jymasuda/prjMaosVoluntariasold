using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class InscricaoEvento : Banco
    {
        public Usuario Usuario { get; set; }
        public FuncaoEvento FuncaoEvento { get; set; }
        public DateTime Inscricao { get; set; }
        public bool Aprovado { get; set; }
        public InscricaoEvento()
        {
        }

        public InscricaoEvento(Usuario usuario, FuncaoEvento funcaoEvento, DateTime inscricao, bool aprovado)
        {
            Usuario = usuario;
            FuncaoEvento = funcaoEvento;
            Inscricao = inscricao;
            Aprovado = aprovado;
        }

        public List<InscricaoEvento> listar(string codigoEvento)
        {
            List<InscricaoEvento> inscricoes = new List<InscricaoEvento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigo", codigoEvento));

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarInscricoes", parametros))
                {
                    while (dados.Read())
                    {
                        InscricaoEvento inscricaoEvento = new InscricaoEvento();
                        Usuario usuario = new Usuario();
                        usuario.Email = dados.GetString(0);
                        if (dados[1] != null)
                        {
                            byte[] f = (byte[])dados[1];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            usuario.Foto = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }
                        usuario.Nome = dados.GetString(2);
                        inscricaoEvento.Usuario = usuario;
                        Funcao funcao = new Funcao();
                        funcao.Nome = dados.GetString(3);
                        funcao.Codigo = dados.GetInt32(4);
                        FuncaoEvento funcaoEvento = new FuncaoEvento();
                        funcaoEvento.Funcao = funcao;
                        inscricaoEvento.FuncaoEvento = funcaoEvento;

                        inscricoes.Add(inscricaoEvento);
                    }

                    return inscricoes;

                }
            }
            catch
            {
                return null;
            }
        }
        public List<InscricaoEvento> listarAprovados(string codigoEvento)
        {
            List<InscricaoEvento> inscricoes = new List<InscricaoEvento>();
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("vCodigo", codigoEvento));

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarInscricoesAprovadas", lista))
                {
                    while (dados.Read())
                    {
                        InscricaoEvento inscricaoEvento = new InscricaoEvento();
                        Usuario usuario = new Usuario();
                        usuario.Email = dados.GetString(0);
                        if (dados[1] != null)
                        {
                            byte[] f = (byte[])dados[1];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            usuario.Foto = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }
                        usuario.Nome = dados.GetString(2);
                        inscricaoEvento.Usuario = usuario;
                        Funcao funcao = new Funcao();
                        funcao.Nome = dados.GetString(3);
                        funcao.Codigo = dados.GetInt32(4);
                        FuncaoEvento funcaoEvento = new FuncaoEvento();
                        funcaoEvento.Funcao = funcao;
                        inscricaoEvento.FuncaoEvento = funcaoEvento;

                        inscricoes.Add(inscricaoEvento);
                    }

                    return inscricoes;

                }
            }
            catch
            {
                return null;
            }
        }
        public void recusarInscricao(string email, string codigoEvento, string codigoFuncao)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento));
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao));
            Executar("recusarInscricao", parametros);
        }

        public void aceitarInscricao(string email, string codigoEvento, string codigoFuncao)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento));
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao));
            Executar("aceitarInscricao", parametros);
        }

        public void realizarInscricao(string email, int codigoFuncao, int codigoEvento, DateTime inicio)
        {

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao.ToString()));
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento.ToString()));
            parametros.Add(new Parametro("vDataInicio", inicio.ToString("yyyy-MM-dd HH:mm:ss")));

            Executar("solicitarInscricao", parametros);
        }

        public bool procurarInscricao(string email, int codigoEvento, int codigoFuncao, DateTime inicio)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento.ToString()));
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao.ToString()));
            parametros.Add(new Parametro("vDataInicio", inicio.ToString("yyyy-MM-dd HH:mm:ss")));

            MySqlDataReader dados = null;
            dados = Consultar("procurarInscricaoUsuario", parametros);

            if (dados.HasRows)
                return true;

            return false;
        }

        public bool cancelarInscricao(string email, int codigoFuncao, int codigoEvento)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vEmail", email));
                parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao.ToString()));
                parametros.Add(new Parametro("vCodigoEvento", codigoEvento.ToString()));

                Executar("cancelarInscricao", parametros);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int contarInscricoesPendentes(string codigoEvento)
        {
            int inscricoesPendentes;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento));

            try
            {
                MySqlDataReader dados = null;
                dados = Consultar("contarInscricoesPendentes", parametros);
                if (dados.Read())
                {
                    inscricoesPendentes = dados.GetInt32(0);
                    return inscricoesPendentes;
                }

                return -1;


            }
            catch
            {
                return -1;
            }
        }

        public List<InscricaoEvento> listarMinhasInscricoes(string email)
        {
            List<InscricaoEvento> inscricoes = new List<InscricaoEvento>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("buscarMinhasInscricoes", parametros))
                {
                    while (dados.Read())
                    {
                        InscricaoEvento inscricaoEvento = new InscricaoEvento();
                        Evento evento = new Evento();
                        evento.Codigo = dados.GetInt32(0);
                        evento.Nome = dados.GetString(1);
                        Funcao funcao = new Funcao();
                        funcao.Nome = dados.GetString(2);
                        funcao.Codigo = dados.GetInt32(3);
                        FuncaoEvento funcaoEvento = new FuncaoEvento();
                        funcaoEvento.Evento = evento;
                        funcaoEvento.Funcao = funcao;
                        inscricaoEvento.FuncaoEvento = funcaoEvento;
                        inscricaoEvento.Aprovado = dados.GetBoolean(4);

                        inscricoes.Add(inscricaoEvento);
                    }

                    return inscricoes;

                }
            }
            catch
            {
                return null;
            }
        }

        public bool verificarAprovacao(string email, string codigoEvento, string codigoFuncao)
        {
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("vEmail", email));
            lista.Add(new Parametro("vCodigoEvento", codigoEvento));
            lista.Add(new Parametro("vCodigoFuncao", codigoFuncao));

            MySqlDataReader dados = null;
            dados = Consultar("verificarAprovacao", lista);
            if (dados.Read())
            {
                Aprovado = dados.GetBoolean(0);
                if (Aprovado == true)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
