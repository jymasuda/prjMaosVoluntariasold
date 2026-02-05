using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class enviarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";
            if (Request["c"] != null)
            {
                string codigoEvento = Request["c"].ToString();
                string email = null;

                if (Request["t"] == "inscricaoRealizada") 
                {
                    Evento evento = new Evento();
                    email = evento.buscarEmailEvento(codigoEvento.ToString());
                    EnviarEmail envioEmail = new EnviarEmail(email, "Nova inscrição realizada!", $"<html><body><h1>Uma nova inscrição para {evento.Nome} foi realizada!</h1> <p>Lembre de verifica-la e responde-la!</p> <a href='inscricoes.aspx?c={codigoEvento}'><p style='font-style: italic;'>Clique aqui para ver a página de inscrições</p></a></body></html>");
                    if(envioEmail.enviarEmail(envioEmail))
                        resposta = "{'situacao':'true'}";
                }

            }

            Response.Write(resposta.Replace('\'', '\"'));

        }
    }
}