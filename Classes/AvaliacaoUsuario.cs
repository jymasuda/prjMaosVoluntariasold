using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class AvaliacaoUsuario : Banco
    {
        public Empresa Empresa { get; set; }
        public Usuario Usuario { get; set; }
        public int Avaliacao { get; set; }
        public string Observacao { get; set; }
        public AvaliacaoUsuario()
        {
        }

        public AvaliacaoUsuario(Empresa empresa, Usuario usuario, int avaliacao, string observacao)
        {
            Empresa = empresa;
            Usuario = usuario;
            Avaliacao = avaliacao;
            Observacao = observacao;
        }

        public int calcularNotaUsuario(string email)
        {
            int notaUsuario = 0;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));

            MySqlDataReader dados = null;

            try
            {
                using (dados = Consultar("listarNotaAvaliacao", parametros))
                {
                    int quantidadeAvaliacao = 1;
                    while (dados.Read())
                    {
                        AvaliacaoUsuario avaliacaoUsuario = new AvaliacaoUsuario();
                        avaliacaoUsuario.Avaliacao = dados.GetInt32(0);
                        notaUsuario = notaUsuario + avaliacaoUsuario.Avaliacao;
                        notaUsuario = notaUsuario / quantidadeAvaliacao;
                        quantidadeAvaliacao++;
                    }
                }
                return notaUsuario;
            }
            catch
            {
                return -1;
            }

        }

        public bool verificarAvaliacaoExistente(int codigo, string email)
        {
            MySqlDataReader dados = null;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCodigoFuncao", codigo.ToString()));

            using (dados = Consultar("verificarAvaliacaoExistente", parametros))
            {
                if (dados.HasRows)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public void avaliar(string emailEmpresa, string emailUsuario, int codigo, int quantidadeAvaliacao, string descricao)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailEmpresa", emailEmpresa));
            parametros.Add(new Parametro("vEmailUsuario", emailUsuario));
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));
            parametros.Add(new Parametro("vQuantidade", quantidadeAvaliacao.ToString()));
            parametros.Add(new Parametro("vDescricao", descricao));

            Executar("avaliarUsuario", parametros);
        }

    }
}