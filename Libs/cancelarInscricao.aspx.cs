using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class cancelarInscricao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";
            string email = null;
            int codigoEvento;
            int codigoFuncao;
            DateTime dataInicio;

            InscricaoEvento inscricao = new InscricaoEvento();
            FuncaoEvento funcaoEvento = new FuncaoEvento();

            if (Request["c"] != null && Request["ce"] != null)
                if (Request["c"] != "" && Request["ce"] != "")
                {
                    codigoEvento = int.Parse(Request["ce"]);
                    codigoFuncao = int.Parse(Request["c"]);

                    if (Session["email"] != null && Session["usuario"] != null)
                    {
                        email = Session["email"].ToString();
                        if(inscricao.verificarAprovacao(email, codigoEvento.ToString(), codigoFuncao.ToString()))
                        {
                            int vagas = funcaoEvento.buscarVagas(codigoFuncao, codigoEvento);
                            vagas = vagas + 1;
                            funcaoEvento.atualizarVagas(codigoFuncao, codigoEvento, vagas);

                        }

                            if (inscricao.cancelarInscricao(email, codigoFuncao, codigoEvento))
                                resposta = "{'situacao':'true'}";

                    }

                }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}