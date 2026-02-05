using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class avaliarVoluntario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situação':'false' }";

            if (!String.IsNullOrEmpty(Request["e"]) && !String.IsNullOrEmpty(Request["c"]) && !String.IsNullOrEmpty(Request["f"]) && !String.IsNullOrEmpty(Request["u"]) && Request["d"] != null && !String.IsNullOrEmpty(Request["q"]))
            {
                AvaliacaoUsuario avaliacaoUsuario = new AvaliacaoUsuario();
                string emailEmpresa = Request["e"].ToString();
                string emailUsuario = Request["u"].ToString();
                string codigoEvento = Request["c"].ToString();
                string codigoFuncao = Request["f"].ToString();
                string descricao = Request["d"].ToString();
                string quantidade = Request["q"].ToString();

                avaliacaoUsuario.avaliar(emailEmpresa, emailUsuario, int.Parse(codigoFuncao), int.Parse(quantidade), descricao);
                resposta = "{'situação':'true'}";

            }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}