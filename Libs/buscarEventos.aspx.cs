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
    public partial class asyncBusca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";
            Evento evento = new Evento();
            string busca = null;
            List<Cidade> cidades = new List<Cidade>();
            List<CategoriaEvento> categorias = new List<CategoriaEvento>();
            List<CategoriaFuncao> habilidades = new List<CategoriaFuncao>();
            List<Evento> eventos = null;

            if(Request["c"] == "" && Request["ca"] == "" && Request["h"] == "" && Request["q"] == "")
                {
                    eventos = evento.Listar();
                    if (eventos.Count > 0)
                    {
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string dadosJSON = jss.Serialize(eventos);
                        resposta = dadosJSON;
                    }
                    if (eventos.Count == 0)
                    {
                        resposta = "{'situacao':'true', 'qtdEventos':'0'}";

                    }
                }
            
                

            if (Request["c"] != null)
                if (Request["c"] != "")    
                {         
                
                    string[] codigosCidade = Request["c"].Split(',');

                    foreach (string c in codigosCidade)
                    {
                        Cidade cidade = new Cidade();
                        cidade.Codigo = int.Parse(c);
                        cidades.Add(cidade);
                    }

                }

            if (Request["ca"] != null)
                if (Request["ca"] != "")
                {
                    string[] codigosCategoria = Request["ca"].Split(',');

                    foreach (string c in codigosCategoria)
                    {
                        CategoriaEvento categoria = new CategoriaEvento();
                        categoria.Codigo = int.Parse(c);
                        categorias.Add(categoria);
                    }
                }

            if (Request["h"] != null)
                if (Request["h"] != "")
                {
                    string[] codigosHabilidade = Request["h"].Split(',');

                    foreach (string c in codigosHabilidade)
                    {
                        CategoriaFuncao habilidade = new CategoriaFuncao();
                        habilidade.Codigo = int.Parse(c);
                        habilidades.Add(habilidade);
                    }
                }

            try
            {
                int pagina;
                if (String.IsNullOrEmpty(Request["p"]))
                   pagina = 1;
                else
                    pagina = int.Parse(Request["p"]);

                if (!String.IsNullOrEmpty(Request["q"]))
                {
                    busca = Request["q"].ToString();
                }
                eventos = new List<Evento>(evento.Buscar(busca, cidades, categorias, habilidades, pagina));
                if(eventos.Count > 0) 
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string dadosJSON = jss.Serialize(eventos);
                    resposta = dadosJSON;

                } 
                if (eventos.Count == 0)
                {
                    resposta = "{'situacao':'true', 'qtdEventos':'0'}";

                }

                Response.Write(resposta.Replace('\'', '\"'));


            }
            catch
            {
                Response.Write(resposta.Replace('\'', '\"'));
            }




            
        }
    }
}
