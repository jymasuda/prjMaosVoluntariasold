using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class conferirInscricao : System.Web.UI.Page
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
            Evento evento = new Evento();

            if (Request["c"] != null && Request["ce"] != null && Request["d"] != null)
                if (Request["c"] != "" && Request["ce"] != "" && Request["d"] != "")
                {
                    codigoEvento = int.Parse(Request["ce"]);
                    codigoFuncao = int.Parse(Request["c"]);
                    dataInicio = DateTime.Parse(Request["d"].ToString());
                    bool vagas;
                    int q = evento.procurarQuantidadeVagas(codigoEvento, codigoFuncao);
                    if (q > 0)
                    {
                        vagas = true;
                    }
                    else
                        vagas = false;

                    if (Session["email"] != null && Session["usuario"] != null)
                    {
                        email = Session["email"].ToString();


                        if (inscricao.procurarInscricao(email, codigoEvento, codigoFuncao, dataInicio))
                            resposta = "{'situacao':'true','inscrito':'true','vagas':'"+ vagas +"'}";
                        else
                            resposta = "{'situacao':'true','inscrito':'false','vagas':'"+ vagas +"'}";
                    }
                    else
                        resposta = "{'situacao':'true','logado':'false','inscrito':'false','vagas':'"+ vagas +"'}";
                }

            
             
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}