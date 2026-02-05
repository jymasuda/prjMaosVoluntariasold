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
    public partial class editarEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situação':'false'}";

            if (Request["v"] != null && Request["c"] != null && Request["t"] != null && Request["i"] != null && Request["f"] != null && Request["e"] != null && Request["ca"] != null && Request["d"] != null)
            {

                if (Request["v"] == "informacao" && Request["v"] != "" && Request["c"] != "" && Request["t"] != "" && Request["i"] != "" && Request["f"] != "" && Request["e"] != "" && Request["ca"] != "" && Request["d"] != "")
                {
                    string codigo = Request["c"];
                    string titulo = Request["t"];
                    string dtInicio = Request["i"];
                    string dtInicioReplace = dtInicio.Replace('T', ' ');
                    string dtFim = Request["f"];
                    string dtFimReplace = dtFim.Replace('T', ' ');
                    string endereco = Request["e"];
                    string categoria = Request["ca"];
                    string descricao = Request["d"];
                    Evento evento = new Evento();
                    evento.Editar(codigo, titulo, dtInicioReplace, dtFimReplace, endereco, categoria, descricao);

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
                                string comando = $"Update evento set nm_imagem = @foto where cd_evento = {codigo};";

                                using (MySqlCommand cmd = new MySqlCommand(comando, conexao))
                                {
                                    cmd.Parameters.AddWithValue("@foto", fileData);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    resposta = "{'situação':'true'}";
                }
            }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}