using MySql.Data.MySqlClient;
using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class realizarCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            string resposta = "{'situacao':'false'}";

            if (!String.IsNullOrEmpty(Request["cpf"]))
            {
                if (Session["usuario"] != null)
                {
                    Response.Redirect("erro.aspx");
                    return;
                }


                string nome = Request["n"];
                string email = Request["e"];
                string senha = Request["s"];
                string cpf = Request["cpf"];
                string rg = Request["rg"];
                string codigoVerificacao = "123";

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file.ContentType.StartsWith("image/") && file.ContentLength > 0)
                    {

                        byte[] fileData = new byte[file.ContentLength];
                        file.InputStream.Read(fileData, 0, file.ContentLength);


                        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=maos_voluntarias";
                        using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
                        {
                            conexao.Open();

                            string comando = $@"insert into usuario (nm_email, nm_usuario, nm_senha, nm_foto_perfil, ic_banido, cd_cpf, cd_verificacao, nm_foto_documento, cd_rg, ic_verificado, cd_tipo_usuario, ds_usuario) 
                                            values ('{email}', '{nome}', sha('{senha}'), null, false, '{cpf}', '{codigoVerificacao}', @FotoDocumento, '{rg}', false, 1, '')";
                            using (MySqlCommand cSql = new MySqlCommand(comando, conexao))
                            {
                                cSql.Parameters.AddWithValue("@FotoDocumento", fileData);
                                cSql.ExecuteNonQuery();
                            }

                            conexao.Close();
                        }

                        
                        using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
                        {
                            conexao.Open();
                            string comando = $"UPDATE usuario SET nm_foto_perfil = @foto WHERE nm_email = '{email}';";
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

                        resposta = "{'situacao':'true','nome':'" + nome + "','email':'" + email + "'}";
                    }

                }


                //Session["usuario"] = nome;
                //Session["email"] = email;

                //Usuario usuario = new Usuario();
                //usuario.Cadastrar(nome, email, senha, cpf, rg, documento);
                //resposta = "{'situação':'true','usuario','"+nome+"','email':'" + email+"'}";
                //Response.Write(resposta.Replace('\'', '\"'));
                //return;
            }

            if (!String.IsNullOrEmpty(Request["cnpj"]))
            {

                if (Session["empresa"] != null)
                {
                    Response.Redirect("erro.aspx");
                    return;
                }

                string nome = Request["n"];
                string email = Request["e"];
                string senha = Request["s"];
                string cnpj = Request["cnpj"];
                string telefone = Request["t"];
                string site = Request["st"];

                try
                {
                    Empresa empresa = new Empresa();
                    empresa.Cadastrar(nome, email, senha, cnpj, site, telefone);
                }
                catch (Exception)
                {

                    throw;
                }
                resposta = "{'situacao':'true','nome':'" + nome + "','email':'" + email + "'}";
            }

            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}