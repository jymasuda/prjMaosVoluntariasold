using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class avaliarEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situação':'false' }";

            if (!String.IsNullOrEmpty(Request["c"]) && !String.IsNullOrEmpty(Request["u"]) && Request["d"] != null && !String.IsNullOrEmpty(Request["q"]))
            {
                AvaliacaoEvento avaliacaoEvento = new AvaliacaoEvento();
                string emailUsuario = Request["u"].ToString();
                string codigoEvento = Request["c"].ToString();
                string descricao = Request["d"].ToString();
                string quantidade = Request["q"].ToString();

                avaliacaoEvento.avaliar(emailUsuario, int.Parse(codigoEvento), int.Parse(quantidade), descricao);
                resposta = "{'situação':'true'}";

            }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}