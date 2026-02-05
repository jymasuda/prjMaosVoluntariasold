using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class CategoriaFuncao:Banco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public CategoriaFuncao()
        {
        }

        public CategoriaFuncao(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
        public List<CategoriaFuncao> Listar()
        {
            List<CategoriaFuncao> habilidades = new List<CategoriaFuncao>();
            List<Parametro> parametros = new List<Parametro>();

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarCategoriaFuncao", parametros))
                {
                    while (dados.Read())
                    {
                        CategoriaFuncao habilidade = new CategoriaFuncao();
                        habilidade.Nome = dados.GetString(1);
                        habilidade.Codigo = dados.GetInt32(0);

                        habilidades.Add(habilidade);
                    }

                    return habilidades;
                }
            }
            catch
            {
                return null;
            }
          
            
        }

        public CategoriaFuncao listarNomes(int codigoHabilidade)
        {
            MySqlDataReader dados = null;
            CategoriaFuncao categoria = new CategoriaFuncao();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoHabilidade", codigoHabilidade.ToString()));
            using (dados = Consultar("listarNomeHabilidade", parametros))
            {
                try
                {
                    if (dados.Read())
                    {
                        categoria.Nome = dados.GetString(0);
                        categoria.Codigo = codigoHabilidade;
                    }
                }
                catch
                {
                    return null;
                }

            }

            return categoria;
        }

        public CategoriaFuncao pegarCodigoCategoria(string codigoEvento)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro("vCodigoEvento", codigoEvento);
            parametros.Add(parametro);

            MySqlDataReader dados = Consultar("pegarCodigoCategoriaFuncao", parametros);
            CategoriaFuncao funcao = new CategoriaFuncao();

            if (dados.Read())
            {
                int codigoCategoria = dados.GetInt32(0);
                funcao.Codigo = codigoCategoria;
                return funcao;

            }
            return funcao;

        }

    }
}