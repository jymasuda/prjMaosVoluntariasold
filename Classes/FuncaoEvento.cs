using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class FuncaoEvento : Banco
    {
        public Funcao Funcao { get; set; }
        public Evento Evento { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int QuantidadeVagas { get; set; }
        public string Descricao { get; set; }
        public FuncaoEvento()
        {
        }

        public FuncaoEvento(Funcao funcao, Evento evento, DateTime inicio, DateTime fim, int quantidadeVagas, string descricao)
        {
            Funcao = funcao;
            Evento = evento;
            Inicio = inicio;
            Fim = fim;
            QuantidadeVagas = quantidadeVagas;
            Descricao = descricao;
        }
        public FuncaoEvento(Funcao funcao, Evento evento, DateTime inicio)
        {
            Funcao = funcao;
            Evento = evento;
            Inicio = inicio;

        }

        public List<FuncaoEvento> listarFuncoes(int codigo)
        {
            List<FuncaoEvento> vagasEvento = new List<FuncaoEvento>();

            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro("vCodigoEvento", codigo.ToString());
            parametros.Add(parametro);

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarFuncoesEvento", parametros))
                {
                    while(dados.Read()) 
                    {
                        FuncaoEvento vagaEvento = new FuncaoEvento();
                        vagaEvento.Descricao = dados.GetString(1);
                        vagaEvento.Inicio = dados.GetDateTime(2);
                        vagaEvento.Fim = dados.GetDateTime(3);
                        vagaEvento.QuantidadeVagas = dados.GetInt32(4);
                        
                        Funcao vaga = new Funcao();
                        vaga.Nome = dados.GetString(0);
                        vaga.Codigo = dados.GetInt32(5);
                        vagaEvento.Funcao = vaga;

                        vagasEvento.Add(vagaEvento);
                    }
                    
                    return vagasEvento;
                }
            }
            catch
            {
                return null;
            }

        }
        public FuncaoEvento exibeVaga(FuncaoEvento dadosFuncao)
        {
            FuncaoEvento vagaEvento = new FuncaoEvento();
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro("vDataInicio", dadosFuncao.Inicio.ToString("yyyy-MM-dd HH:mm:ss"));
            parametros.Add(parametro);
            parametro = new Parametro("vCodigoEvento", dadosFuncao.Evento.Codigo.ToString());
            parametros.Add(parametro);
            parametro = new Parametro("vNomeFuncao", dadosFuncao.Funcao.Nome);
            parametros.Add(parametro);


            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("exibeVaga", parametros))
                {
                    if (dados.Read())
                    {
                        vagaEvento.Inicio = dadosFuncao.Inicio;
                        vagaEvento.Fim = dados.GetDateTime(0);
                        vagaEvento.Descricao = dados.GetString(1);
                        vagaEvento.QuantidadeVagas = dados.GetInt32(2);
                        
                    }
                    return vagaEvento;
                }
            }
            catch
            {
                return null;
            }

        }

        public int buscarVagas(int codigoFuncao, int codigoEvento)
        {
            int vagas = -1;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao.ToString()));
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento.ToString()));

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("buscarVagas", parametros))
                {
                    if (dados.Read())
                    {
                        FuncaoEvento funcaoEvento = new FuncaoEvento();
                        funcaoEvento.QuantidadeVagas = dados.GetInt32(0);
                        vagas = funcaoEvento.QuantidadeVagas;
                    }
                    return vagas;
                }
            }
            catch
            {
                return -1;
            }
        }
        public void atualizarVagas(int codigoFuncao, int codigoEvento, int vagas)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao.ToString()));
            parametros.Add(new Parametro("vCodigoEvento", codigoEvento.ToString()));
            parametros.Add(new Parametro("vVagas", vagas.ToString()));

            Executar("atualizarVagas", parametros);

        }

        public void deletarVaga(int codigoFuncao)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoFuncao", codigoFuncao.ToString()));

            Executar("deletarFuncao", parametros);
        }
    }
}