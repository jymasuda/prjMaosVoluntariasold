using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class pegarCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";

            CategoriaEvento categoria = new CategoriaEvento();
            List<CategoriaEvento> categorias = new List<CategoriaEvento>(categoria.Listar());
            if (categorias.Count > 0)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string dadosJSON = jss.Serialize(categorias);
                resposta = dadosJSON;
            }
            if (categorias.Count == 0)
            {
                resposta = "{'situacao':'true', 'qtdEventos':'0'}";
            }


            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}