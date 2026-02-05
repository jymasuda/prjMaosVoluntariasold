using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class Usuario : Banco
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public bool Banido { get; set; }
        public string CPF { get; set; }
        public string Verificacao { get; set; }
        public string Documento { get; set; }
        public string RG { get; set; }
        public string Descricao { get; set; }
        public bool Verificado { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public Usuario()
        {
        }

        public Usuario(string email, string nome, string senha, string foto, bool banido, string cPF, string verificacao, string documento, string rG, string descricao, bool verificado, TipoUsuario tipoUsuario)
        {
            Email = email;
            Nome = nome;
            Senha = senha;
            Foto = foto;
            Banido = banido;
            CPF = cPF;
            Verificacao = verificacao;
            Documento = documento;
            RG = rG;
            Verificado = verificado;
            Descricao = descricao;
            this.tipoUsuario = tipoUsuario;
        }

        public Usuario Logar(string email, string senha)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email.ToString()));
            parametros.Add(new Parametro("vSenha", senha.ToString()));

            MySqlDataReader dados = Consultar("logar", parametros);

            Usuario usuario = new Usuario();
            using (dados)
            {
                if (dados.Read())
                {
                    string nome = dados.GetString(0);
                    string cpf = dados.GetString(1);
                    if (cpf.Length == 14)
                    {
                        usuario.Nome = nome;
                    }
                }
            }

            return usuario;
        }

        public Usuario listarPerfil(string email)
        {
            Usuario usuario = new Usuario();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email.ToString()));

            using (MySqlDataReader dados = Consultar("buscarInfoUsuario", parametros))
            {
                if (dados.Read())
                {
                    if (!dados.HasRows)
                    {
                        return usuario;
                    }
                    usuario.Nome = dados.GetString(0);

                    if (dados[1] != null)
                    {
                        byte[] f = (byte[])dados[1];
                        string base64 = Convert.ToBase64String(f, 0, f.Length);
                        usuario.Foto = Convert.ToString("data:image/jpeg;base64,") + base64;
                    }
                    if (!dados.IsDBNull(2))
                        usuario.Descricao = dados.GetString(2);
                    else
                        usuario.Descricao = "";
                }

            }


            return usuario;
        }

        public void Editar(byte[] fotoPerfil, string desc, string email)
        {

            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Maos_Voluntarias";
            using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
            {
                conexao.Open();

                string comando = $@"update usuario set ds_usuario = '{desc}' where nm_email = '{email}';";
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);


                //cSQL = new MySqlCommand(comando, conexao);
                //MySqlParameter parametro = new MySqlParameter("@foto", MySqlDbType.Binary);
                //parametro.Value = fotoPerfil;
                //cSQL.Parameters.Add(parametro);
                cSQL.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Usuario pegarFotoPerfil(string email)
        {
            Usuario usuario = new Usuario();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email.ToString()));

            using (MySqlDataReader dados = Consultar("pegarFotoPerfil", parametros))
            {
                if (dados.Read())
                {
                    if (dados[0] != null)
                    {
                        byte[] f = (byte[])dados[0];
                        string base64 = Convert.ToBase64String(f, 0, f.Length);
                        usuario.Foto = Convert.ToString("data:image/jpeg;base64,") + base64;
                    }
                }

            }
            return usuario;
        }

        public bool verificaEmail(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email.ToString()));

            MySqlDataReader dados = Consultar("verificaEmail", parametros);

            using (dados)
            {
                if (dados.Read())
                    if (dados.HasRows)
                    {
                        return true;
                    }

                return false;
            }

        }
        public double calcularMediaAvaliacao(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            MySqlDataReader dados = null;
            double notaUsuario = 0;
            try
            {
                using (dados = Consultar("calcularMediaAvaliacaoUsuario", parametros))
                {

                    if (dados.Read())
                        if (!dados.IsDBNull(0))
                        {
                            notaUsuario = dados.GetDouble(0);
                        }
                }
                return notaUsuario;
            }
            catch
            {
                return -1;
            }
        }
    }
}