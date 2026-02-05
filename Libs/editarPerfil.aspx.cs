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
    public partial class editarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            if (Request["n"] == null || Request["f"] == "")
            {
                Response.Write(resposta.Replace('\'', '\"'));
                return;
            }

            string email = Session["email"].ToString();
            string nome = Request["n"].ToString();
            string descricao = Request["d"].ToString();



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
                        string comando = "";
                        if (Session["usuario"] != null)
                            comando = $"update usuario set nm_usuario = '{nome}', ds_usuario = '{descricao}', nm_foto_perfil = @foto where nm_email = '{email}';";
                        if (Session["empresa"] != null)
                            comando = $"update empresa set nm_empresa = '{nome}', ds_empresa = '{descricao}', nm_foto = @foto where nm_email = '{email}';";
                        

                        using (MySqlCommand cmd = new MySqlCommand(comando, conexao))
                        {
                            cmd.Parameters.AddWithValue("@foto", fileData);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    resposta = "{'situacao':'true'}";
                }
            }

            if (Request.Files.Count <= 0)
            {
                    string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=maos_voluntarias";
                    using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
                    {
                        conexao.Open();
                        string comando = "";
                        if (Session["usuario"] != null)
                            comando = $"update usuario set nm_usuario = '{nome}', ds_usuario = '{descricao}' where nm_email = '{email}';";
                        if (Session["empresa"] != null)
                            comando = $"update empresa set nm_empresa = '{nome}', ds_empresa = '{descricao}' where nm_email = '{email}';";

                        using (MySqlCommand cmd = new MySqlCommand(comando, conexao))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    resposta = "{'situacao':'true'}";
                
            }

                
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}