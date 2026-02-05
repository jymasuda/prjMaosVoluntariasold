using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class realizarInscricao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            
            if (Session["usuario"] != null && Request["c"] != null && Request["ce"] != null && Request["d"] != null)
            {
                InscricaoEvento inscricao = new InscricaoEvento();

                string email = Session["email"].ToString();
                int codigoFuncao = int.Parse(Request["c"]);
                int codigoEvento = int.Parse(Request["ce"]);
                DateTime dataInicio = DateTime.Parse(Request["d"]);

                inscricao.realizarInscricao(email, codigoFuncao, codigoEvento, dataInicio);
                
                resposta = "{'situacao':'true','logado':'true'}";

            }
            else if(Session["empresa"] != null)
            {
                resposta = "{'situacao':'true','logado':'empresa'}";
            }
            else
            {
                resposta = "{'situacao':'true','logado':'false'}";
            }

            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}