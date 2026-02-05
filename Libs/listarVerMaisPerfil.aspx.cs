using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class listarVerMaisPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situação':'false'}";
            Evento evento = new Evento();
            List<Evento> eventos = new List<Evento>();

            if (!String.IsNullOrEmpty(Request["t"]))
            {
                string email = Session["email"].ToString();

                int offset = int.Parse(Request["p"]);
                offset = offset + 4;
                string[] request = Request["t"].ToString().Split(' ');
                string tipoListar = request[0];
                int paginasRestantes = int.Parse(request[1]);
                    paginasRestantes = paginasRestantes - 1;
                resposta = "{'Paginas': [{ 'paginasRestantes':'" + paginasRestantes + "', 'offset':'" + offset + "'}],";
                if (tipoListar == "Acontecendo")
                    eventos = evento.listarEventosAcontecendo(email, offset);
                if (tipoListar == "Encerrado")
                    eventos = evento.listarEventosEncerrados(email, offset);
                if (tipoListar == "Inscrito")
                    eventos = evento.listarEventosInscrito(email, offset);
                if (tipoListar == "Participado")
                    eventos = evento.listarEventosParticipado(email, offset);

                
                double[] notas = new double[eventos.Count];

                for (int i = 0; i < eventos.Count; i++)
                {
                    notas[i] = evento.calcularMediaAvaliacao(eventos[i].Codigo);
                }


                JavaScriptSerializer jss = new JavaScriptSerializer();
                string dadosJSON = jss.Serialize(eventos);
                string dadosJSON2 = jss.Serialize(notas);
                resposta += "'Eventos':" + dadosJSON + ", 'Notas':"+ dadosJSON2 +"}";

            }


            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}