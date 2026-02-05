using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class editarFuncaoVaga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            if (Request["c"] != null && Request["ce"] != null && Request["n"] != null && Request["i"] != null && Request["f"] != null && Request["ca"] != null && Request["de"] != null && Request["qi"] != null)
            {
                if (Request["c"] != "" && Request["n"] != "" && Request["i"] != "" && Request["f"] != "" && Request["ca"] != "" && Request["de"] != "" && Request["qi"] != "")
                {
                    string codigo = Request["c"].ToString();
                    string codigoEvento = Request["ce"].ToString();
                    string nome = Request["n"].ToString();
                    string inicio = Request["i"].ToString();
                    string fim = Request["f"].ToString();
                    string codigoCategoria = Request["ca"].ToString();
                    string descricao = Request["de"].ToString();
                    string quantidade = Request["qi"].ToString();





                    Funcao funcao = new Funcao();

                    if (funcao.editarVaga(codigo, nome, codigoCategoria, codigoEvento, inicio, fim, quantidade, descricao))
                        resposta = "{'situacao':'true'}";
                }
            }

            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}