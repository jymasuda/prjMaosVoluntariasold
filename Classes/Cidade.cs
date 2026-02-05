using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace prjMaosVoluntarias.Classes
{
    public class Cidade:Banco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Cidade()
        {
        }

        public Cidade(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public List<Cidade> Listar()
        {
            List<Cidade> cidades = new List<Cidade>();
            List<Parametro> parametros = new List<Parametro>();

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarCidades", parametros))
                {
                    while (dados.Read()) 
                    {
                        Cidade cidade = new Cidade();
                        cidade.Nome = dados.GetString(1);
                        cidade.Codigo = dados.GetInt32(0);

                        cidades.Add(cidade);
                    }

                    return cidades;

                }
            }
            catch
            {
                return null;
            }

        }

        public Cidade listarNomes( int codigoCidade)
        {
            MySqlDataReader dados = null;
            Cidade cidade = new Cidade();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoCidade", codigoCidade.ToString()));
            using (dados = Consultar("listarNomeCidade", parametros))
            {
                try
                {
                    if (dados.Read())
                    {
                        cidade.Nome = dados.GetString(0);
                        cidade.Codigo = codigoCidade;
                    }
                }
                catch
                {
                    return null;
                }

            }

            return cidade;
        }

    }
}