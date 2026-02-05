using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class recusarInscricao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situação':'false' }";

            if (!String.IsNullOrEmpty(Request["e"]) && !String.IsNullOrEmpty(Request["c"]) && !String.IsNullOrEmpty(Request["f"]))
            {
                InscricaoEvento inscricaoEvento = new InscricaoEvento();
                string email = Request["e"].ToString();
                string codigoEvento = Request["c"].ToString();
                string codigoFuncao = Request["f"].ToString();

                if (inscricaoEvento.verificarAprovacao(email, codigoEvento, codigoFuncao) == false)
                {
                    inscricaoEvento.recusarInscricao(email, codigoEvento, codigoFuncao);
                    resposta = "{'situação':'true'}";
                }

                else
                {
                    FuncaoEvento funcaoEvento = new FuncaoEvento();
                    int vagas = funcaoEvento.buscarVagas(int.Parse(codigoFuncao), int.Parse(codigoEvento));
                    vagas = vagas + 1;
                    funcaoEvento.atualizarVagas(int.Parse(codigoFuncao), int.Parse(codigoEvento), vagas);
                    inscricaoEvento.recusarInscricao(email, codigoEvento, codigoFuncao);
                    resposta = "{'situação':'true'}";
                }

                //Evento evento = new Evento();
                //evento.Nome = evento.buscarNomeEvento(codigoEvento);
                //EnviarEmail envioEmail = new EnviarEmail(email, "Inscrição recusada!", $"<html><body><h1>Sua inscrição para o evento {evento.Nome} foi recusada!</h1> <p>Não se desanime e fique atento a outras vagas no nosso site!</p></body></html>");
                //envioEmail.enviarEmail(envioEmail);
            }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}
