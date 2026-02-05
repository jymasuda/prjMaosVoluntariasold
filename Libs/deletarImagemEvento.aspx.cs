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
    public partial class deletarImagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            if (Request["c"] == null)
            {
                Response.Write(resposta.Replace('\'', '\"'));
                return;
            }

            int codigo = int.Parse(Request["c"]);
            ImagemEvento imagem = new ImagemEvento();
            try
            {
                imagem.deletarImagem(codigo);
                resposta = "{'situacao':'true'}";
            }
            catch (Exception)
            {
                throw;
            }
            


            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}