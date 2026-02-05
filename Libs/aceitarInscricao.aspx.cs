using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class aceitarInscricao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situação':'false' }";

            if (!String.IsNullOrEmpty(Request["e"]) && !String.IsNullOrEmpty(Request["c"]) && !String.IsNullOrEmpty(Request["f"]))
            {
                InscricaoEvento inscricaoEvento = new InscricaoEvento();
                FuncaoEvento funcaoEvento = new FuncaoEvento();
                string email = Request["e"].ToString();
                string codigoEvento = Request["c"].ToString();
                string codigoFuncao = Request["f"].ToString();
                int vagas = funcaoEvento.buscarVagas(int.Parse(codigoFuncao), int.Parse(codigoEvento));
                if (vagas == 0)
                {
                    resposta = "{'situação':'vagasEsgotadas'}";
                }
                if (vagas > 0)
                {
                    vagas = vagas - 1;
                    funcaoEvento.atualizarVagas(int.Parse(codigoFuncao), int.Parse(codigoEvento), vagas);
                    inscricaoEvento.aceitarInscricao(email, codigoEvento, codigoFuncao);
                    resposta = "{'situação':'true'}";
                    Evento evento = new Evento();
                    evento.Nome = evento.buscarNomeEvento(codigoEvento);
                    EnviarEmail envioEmail = new EnviarEmail(email, "Inscrição aceita!", $"<html><body><h1>Sua inscrição para o evento {evento.Nome} foi aceita!</h1> <p>Lembre de confirmar a data e hora, e qualquer outro aviso dado pelos organizadores!</p> <a href='evento.aspx?c={codigoEvento}'><p style='font-style: italic;'>Clique aqui para ver a página do evento</p></a></body></html>");
                    envioEmail.enviarEmail(envioEmail);
                }

               
            }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}