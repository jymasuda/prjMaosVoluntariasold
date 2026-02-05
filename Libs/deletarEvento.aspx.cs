using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class deletarEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";
            if (Request["v"] != null)
                if (Request["v"] != "")
                {
                    string request = Request["v"].ToString();
                    string[] codigos = request.Split(',');
                    foreach(string codigo in codigos)
                    {
                        int codigoFuncao = int.Parse(codigo);

                        FuncaoEvento funcao = new FuncaoEvento();
                        funcao.deletarVaga(codigoFuncao);

                    }
                }
                

            if (Request["c"] != null)
                if (Request["c"] != "")
                {
                    int codigoEvento = int.Parse(Request["c"]);

                    Evento evento = new Evento();

                    evento.deletar(codigoEvento);
                    resposta = "{'situacao':'true'}";
                }

            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}