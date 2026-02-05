using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class Funcao : Banco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public CategoriaFuncao CategoriaFuncao { get; set; }
        public Funcao()
        {
        }

        public Funcao(int codigo, string nome, CategoriaFuncao categoriaFuncao)
        {
            Codigo = codigo;
            Nome = nome;
            CategoriaFuncao = categoriaFuncao;
        }

        public bool criarVaga(string nome, string codigoCategoria, string codigoEvento, string inicio, string fim, string qtVagas, string descricao)
        {
            try
            {
                int codigo;
                List<Parametro> parametros = new List<Parametro>();
                using (MySqlDataReader dados = Consultar("proximaFuncao", parametros))
                {
                    if(dados.Read())
                    {
                        codigo = dados.GetInt32(0);
                        Parametro p = new Parametro("vCodigoFuncao", codigo.ToString());
                        parametros.Add(p);
                    }
                }
               
                Parametro parametro = new Parametro("vNomeFuncao", nome);
                parametros.Add(parametro);
                parametro = new Parametro("vCodigoCategoria", codigoCategoria);
                parametros.Add(parametro);
                parametro = new Parametro("vCodigoEvento", codigoEvento);
                parametros.Add(parametro);
                parametro = new Parametro("vDataInicio", inicio);
                parametros.Add(parametro);
                parametro = new Parametro("vDataFim", fim);
                parametros.Add(parametro);
                parametro = new Parametro("vVagas", qtVagas);
                parametros.Add(parametro);
                parametro = new Parametro("vDescricao", descricao);
                parametros.Add(parametro);

                Executar("criarFuncao", parametros);
                return true;
            }
            catch
            {

                return false;
            }

        }

        public bool editarVaga(string codigoFuncao, string nome, string codigoCategoria, string codigoEvento, string inicio, string fim, string qtVagas, string descricao)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro("vCodigoFuncao", codigoFuncao);
                parametros.Add(parametro);
                parametro = new Parametro("vNomeFuncao", nome);
                parametros.Add(parametro);
                parametro = new Parametro("vCodigoCategoria", codigoCategoria);
                parametros.Add(parametro);
                parametro = new Parametro("vCodigoEvento", codigoEvento);
                parametros.Add(parametro);
                parametro = new Parametro("vDataInicio", inicio);
                parametros.Add(parametro);
                parametro = new Parametro("vDataFim", fim);
                parametros.Add(parametro);
                parametro = new Parametro("vVagas", qtVagas);
                parametros.Add(parametro);
                parametro = new Parametro("vDescricao", descricao);
                parametros.Add(parametro);

                Executar("editarFuncao", parametros);
                return true;
            }
            catch
            {

                return false;
            }

        }
    }
}