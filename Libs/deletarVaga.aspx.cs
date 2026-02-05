using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class deletarVaga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            if (Request["c"] != null)
                if (Request["c"] != "")
                {
                    int codigoFuncao = int.Parse(Request["c"]);

                    FuncaoEvento funcao = new FuncaoEvento();
                    funcao.deletarVaga(codigoFuncao);

                    resposta = "{'situacao':'true'}";
                }



            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}