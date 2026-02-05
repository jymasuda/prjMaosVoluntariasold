using MySql.Data.MySqlClient;
using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class adicionarImagemEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            if (Request["p"] == null)
            {
                Response.Write(resposta.Replace('\'', '\"'));
                return;
            }

            int ultimoCodigo = 0;

            try
            {
                string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=maos_voluntarias";
                using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
                {
                    conexao.Open();
                    string comando = $"Select max(cd_imagem) from imagem_evento;";
                    MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                    MySqlDataReader dados = cSQL.ExecuteReader();
                    

                    if (dados.Read())
                    {
                        ultimoCodigo = dados.GetInt32(0);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }


            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file.ContentType.StartsWith("image/") && file.ContentLength > 0)
                {
                    try
                    {
                        int codigoEvento = int.Parse(Request["p"]);
                        int novoCodigoImagem = ultimoCodigo + 1;

                        byte[] fileData = new byte[file.ContentLength];
                        file.InputStream.Read(fileData, 0, file.ContentLength);

                        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=maos_voluntarias";
                        using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
                        {
                            conexao.Open();
                            string comando = $"insert into imagem_evento (cd_imagem, nm_imagem, cd_evento) values ({novoCodigoImagem}, @foto, {codigoEvento});";


                            using (MySqlCommand cmd = new MySqlCommand(comando, conexao))
                            {
                                cmd.Parameters.AddWithValue("@foto", fileData);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        resposta = "{'situacao':'true'}";
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                
                }


            }

            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}