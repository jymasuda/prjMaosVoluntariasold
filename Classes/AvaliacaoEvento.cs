using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class AvaliacaoEvento : Banco
    {
        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
        public int Avaliacao { get; set; }
        public string Observacao { get; set; }

        public AvaliacaoEvento()
        {
        }

        public AvaliacaoEvento(Usuario usuario, Evento evento, int avaliacao, string observacao)
        {
            Usuario = usuario;
            Evento = evento;
            Avaliacao = avaliacao;
            Observacao = observacao;
        }

        public bool verificarAvaliacaoExistente(string email, int codigo)
        {
            MySqlDataReader dados = null;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));

            using (dados = Consultar("verificarAvaliacaoEmpresaExistente", parametros))
            {
                if (dados.HasRows)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public void avaliar(string emailUsuario, int codigo, int quantidadeAvaliacao, string descricao)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", emailUsuario));
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));
            parametros.Add(new Parametro("vQuantidade", quantidadeAvaliacao.ToString()));
            parametros.Add(new Parametro("vDescricao", descricao));

            Executar("avaliarEvento", parametros);
        }


    }
}