using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class criarVaga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            if (Request["n"] != null && Request["cc"] != null && Request["ce"] != null  && Request["i"] != null && Request["f"] != null && Request["q"] != null && Request["d"] != null)
                if (Request["n"] != "" && Request["cc"] != "" && Request["ce"] != "" && Request["i"] != "" && Request["f"] != "" && Request["q"] != "" && Request["d"] != "")
                {
                    string nome = Request["n"].ToString();
                    string codigoCategoria = Request["cc"].ToString();
                    string codigoEvento = Request["ce"].ToString();
                    string inicio = Request["i"].ToString();
                    string fim = Request["f"].ToString();
                    string quantidade = Request["q"].ToString();
                    string descricao = Request["d"].ToString();

                    Funcao funcao = new Funcao();
                  
                    if(funcao.criarVaga(nome, codigoCategoria, codigoEvento, inicio, fim, quantidade, descricao))
                        resposta = "{'situacao':'true'}";
                    
                }



            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}