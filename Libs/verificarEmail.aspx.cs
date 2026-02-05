using System;
using prjMaosVoluntarias.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class verificarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";
            if (!String.IsNullOrEmpty(Request["e"]))
            {
                if (Request["t"] == "usuario")
                {
                    Usuario usuario = new Usuario();
                    string email = Request["e"];
                    
                    if (usuario.verificaEmail(email))
                    {
                        resposta = "{'situacao':'true'}";
                    }
                }
                if (Request["t"] == "empresa")
                {
                    Empresa empresa = new Empresa();
                    string email = Request["e"];

                    if (empresa.verificaEmail(email))
                    {
                        resposta = "{'situacao':'true'}";
                    }
                }
            }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}