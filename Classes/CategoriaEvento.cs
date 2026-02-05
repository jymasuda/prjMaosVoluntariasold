using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class CategoriaEvento : Banco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public CategoriaEvento()
        {
        }
        public CategoriaEvento(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public List<CategoriaEvento> Listar()
        {
            List<CategoriaEvento> categorias = new List<CategoriaEvento>();
            List<Parametro> parametros = new List<Parametro>();

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarCategoriaEvento", parametros))
                {
                    while (dados.Read())
                    {
                        CategoriaEvento categoria = new CategoriaEvento();
                        categoria.Nome = dados.GetString(1);
                        categoria.Codigo = dados.GetInt32(0);

                        categorias.Add(categoria);
                    }

                    return categorias;

                }
            }
            catch
            {
                return null;
            }

        }

        public CategoriaEvento listarNomes(int codigoCategoria)
        {
            MySqlDataReader dados = null;
            CategoriaEvento habilidade = new CategoriaEvento();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoCategoria", codigoCategoria.ToString()));
            using (dados = Consultar("listarNomeCategoria", parametros))
            {
                try
                {
                    if (dados.Read())
                    {
                        habilidade.Nome = dados.GetString(0);
                        habilidade.Codigo = codigoCategoria;
                    }
                }
                catch
                {
                    return null;
                }

            }

            return habilidade;
        }
    }
}