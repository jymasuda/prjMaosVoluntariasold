using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empresa"] != null)
            {
                litIndex.Text = $@"";
                // Dashboard
                litIndex.Text += $@"<article class=""dashboard"">
                                        <article class=""btn azul evento btn-adicionar-evento"" id='btnAddEvento'>
                                            <div class=""nao-selecionavel"">
                                                <span class=""material-symbols-outlined"">add</span>
                                                <h1>Adicione um evento!</h1>
                                            </div>
                                        </article>
    
                                        <article class=""btn azul evento btn-adicionar-evento a"" id='btnVerPendencias'>
                                            <div  class=""nao-selecionavel"">
                                                <span class=""material-symbols-outlined"">other_admission</span>
                                                <h1>Ver pendências</h1>
                                            </div>
                                        </article>
                                    </article>";
                Evento evento = new Evento();

                List<Evento> eventos = new List<Evento>(evento.listarEventosAcontecendo(Session["email"].ToString(), 0));

                litIndex.Text += $@"<h1 class=""container_title"">Meus Eventos: </h1>
                                    <div class=""eventos"">";
                foreach (Evento ev in eventos.Take(8))
                {
                    litIndex.Text += $@"<a href='evento.aspx?c={ev.Codigo}'>
                                                    <article class='evento'>
                                                        <img src='{ev.Imagem}' alt='' class='evento_capa'>
                                                        <div class='content'>
                                                            <div class='titulo-ong'>
                                                                <h2>{ev.Nome}</h2>
                                                                <h4 class='evento_autor cinzaEItalico'>por {ev.Empresa.Nome}</h4>
                                                            </div>
                                                            <p class='evento_descricao'>{ev.Descricao}</p>
                                                            <div class='evento_localizacao'>
                                                                <span class='material-symbols-outlined'>location_on</span>
                                                                <h5 class='cinzaEItalico'>{ev.Endereco}</h5>
                                                            </div>
                                                        </div>
                                                        <div class='evento_data'>
                                                            <span class='material-symbols-outlined'>calendar_month</span>
                                                            <span class='data'>{ev.DataInicio.ToString("dd/MM")}</span>
                                                        </div>
                                                    </article>
                                                </a>";
                }
                litIndex.Text += $@"</div>";
                int numeroPagina = evento.contarEventosAcontecendo(Session["email"].ToString());
                if (numeroPagina > 1)
                    litIndex.Text += $@"<div class=""verMais""> 
                                            <button id=""btnVerMaisE"" class=""btn azul"">Ver mais</button> 
                                        </div>";
            }
            else
            {

                Evento evento = new Evento();

                List<Evento> eventos = new List<Evento>(evento.Listar());

                litIndex.Text += $@"<h1 class=""container_title"">Eventos próximos do prazo: </h1>
                                    <div class=""eventos"">";
                foreach (Evento ev in eventos.Take(8))
                {
                    litIndex.Text += $@"<a href='evento.aspx?c={ev.Codigo}'>
                                                    <article class='evento'>
                                                        <img src='{ev.Imagem}' alt='' class='evento_capa'>
                                                        <div class='content'>
                                                            <div class='titulo-ong'>
                                                                <h2>{ev.Nome}</h2>
                                                                <h4 class='evento_autor cinzaEItalico'>por {ev.Empresa.Nome}</h4>
                                                            </div>
                                                            <p class='evento_descricao'>{ev.Descricao}</p>
                                                            <div class='evento_localizacao'>
                                                                <span class='material-symbols-outlined'>location_on</span>
                                                                <h5 class='cinzaEItalico'>{ev.Endereco}</h5>
                                                            </div>
                                                        </div>
                                                        <div class='evento_data'>
                                                            <span class='material-symbols-outlined'>calendar_month</span>
                                                            <span class='data'>{ev.DataInicio.ToString("dd/MM")}</span>
                                                        </div>
                                                    </article>
                                                </a>";
                }
                litIndex.Text += $@"
                                    </div>
                                    <div class=""verMais"">
                                        <button id=""btnVerMais"" class=""btn azul"">Veja todos os eventos</button>
                                    </div>
                                ";
                //Carrossel
                CategoriaEvento categoria = new CategoriaEvento();
                List<CategoriaEvento> categorias = new List<CategoriaEvento>(categoria.Listar());

                litCarrossel.Text += $@" 
                                <article class=""container"">
                                    <h1 class=""container_title"">Encontre o que mais combina com você:</h1>
                                    <div class=""f-carousel"" id=""grid_icones"">
                                        <div class=""f-carousel__viewport"">
                                            <div class=""f-carousel__track"">";

                foreach (CategoriaEvento c in categorias)
                {
                    litCarrossel.Text += $@"<div class=""f-carousel__slide icone carrosselElement"">
                                        <a id='iconeCarrossel' href=""busca.aspx?ca={c.Codigo}"">
                                            <span id={c.Codigo} class=""nao-selecionavel material-symbols-outlined icone""></span>
                                            <h4 class=""text"">{c.Nome}</h4>
                                        </a>
                                    </div>";

                }

                litCarrossel.Text += $@"</div> 
                                </div>
                            </div>
                    </article>";
            }






        }
    }
}