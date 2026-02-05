using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class Empresa : Banco
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Link { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Senha { get; set; }
        public bool Verificado { get; set; }
        public string Foto { get; set; }
        public bool Banido { get; set; }
        public Empresa()
        {
        }

        public Empresa(string email, string nome, string cNPJ, string link, string telefone, string descricao, string senha, bool verificado, string foto, bool banido)
        {
            Email = email;
            Nome = nome;
            CNPJ = cNPJ;
            Link = link;
            Telefone = telefone;
            Descricao = descricao;
            Senha = senha;
            Verificado = verificado;
            Foto = foto;
            Banido = banido;
        }

        public Empresa Logar(string email, string senha)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email.ToString()));
            parametros.Add(new Parametro("vSenha", senha.ToString()));

            MySqlDataReader dados = Consultar("logar", parametros);

            Empresa empresa = new Empresa();
            if (dados.Read())
            {
                string nome = dados.GetString(0);
                string cnpj = dados.GetString(1);
                if (cnpj.Length == 18)
                {
                    empresa.Nome = nome;
                }
            }

            return empresa;
        }

        public Empresa listarPerfil(string email)
        {
            Empresa empresa = new Empresa();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email.ToString()));

            using (MySqlDataReader dados = Consultar("buscarInfoEmpresa", parametros))
            {
                if (dados.Read())
                {
                    if (!dados.HasRows)
                    {
                        return empresa;
                    }
                    empresa.Nome = dados.GetString(0);
                    if (dados[1] != null)
                    {
                        byte[] f = (byte[])dados[1];
                        string base64 = Convert.ToBase64String(f, 0, f.Length);
                        empresa.Foto = Convert.ToString("data:image/jpeg;base64,") + base64;
                    }
                    empresa.Link = dados.GetString(2);
                    empresa.Telefone = dados.GetString(3);
                    if (dados[4] != null)
                        empresa.Descricao = dados.GetString(4);

                }
            }


            return empresa;
        }

        public bool verificaDonoEvento(string email, int codigo)
        {
            MySqlDataReader dados = null;
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));

            using (dados = Consultar("verificarDono", parametros))
            {
                if (dados.Read())
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public bool Cadastrar(string nome, string email, string senha, string cnpj, string site, string telefone)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vEmail", email.ToString()));
                parametros.Add(new Parametro("vEmpresa", nome.ToString()));
                parametros.Add(new Parametro("vSenha", senha.ToString()));
                parametros.Add(new Parametro("vCnpj", cnpj.ToString()));
                parametros.Add(new Parametro("vSite", site.ToString()));
                parametros.Add(new Parametro("vTelefone", telefone.ToString()));


                Executar("cadastrarEmpresa", parametros);



                string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Maos_Voluntarias";
                using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
                {
                    conexao.Open();
                    string comando = $"UPDATE empresa SET nm_foto = @foto WHERE nm_email = '{email}';";
                    MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                    MemoryStream ms = new MemoryStream();


                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    UriBuilder uri = new UriBuilder(codeBase);
                    string launcherPath = Uri.UnescapeDataString(uri.Path);
                    string caminhoImagem = Path.GetFullPath(Path.Combine(launcherPath, "../../Img/conta.png"));

                    Bitmap figura = new Bitmap(caminhoImagem);


                    figura.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] foto = ms.ToArray();

                    cSQL = new MySqlCommand(comando, conexao);
                    MySqlParameter parametro = new MySqlParameter("@foto", MySqlDbType.Binary);
                    parametro.Value = foto;
                    cSQL.Parameters.Add(parametro);
                    cSQL.ExecuteNonQuery();
                    conexao.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool verificaEmail(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email.ToString()));

            MySqlDataReader dados = Consultar("verificaEmail", parametros);

            using (dados)
            {
                if (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        return true;
                    }
                }
                return false;
            }

        }

        public double calcularMediaAvaliacao(string email)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", email));
            MySqlDataReader dados = null;
            double notaEmpresa = 0;
            try
            {
                using (dados = Consultar("calcularMediaAvaliacaoEmpresa", parametros))
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
    }
}