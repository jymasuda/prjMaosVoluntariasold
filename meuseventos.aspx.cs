using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class meuseventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empresa"] != null && Session["email"] != null)
            {
                string email = Session["email"].ToString();
                Evento evento = new Evento();
                InscricaoEvento inscricaoEvento = new InscricaoEvento();
                List<Evento> eventos = new List<Evento>(evento.listarEventosInscricoesPendentes(email));
                List<Evento> eventosAvaliacaoPendente = new List<Evento>();
                double nota = 0;
                if (eventos.Count == 0)
                {
                    litEventos.Text += $@"<main><article class='container'>
                                        <h1 class=""container_title"">Eventos com inscrições pendentes: </h1>
                                        <p>Nenhuma inscrição pendente!</p>
                    ";
                    eventos = evento.listarTodosEventosEncerrados(email);
                    foreach (Evento ev in eventos)
                    {
                        List<InscricaoEvento> inscricoesAprovadas = new List<InscricaoEvento>(inscricaoEvento.listarAprovados(ev.Codigo.ToString()));
                        foreach (InscricaoEvento inscricao in inscricoesAprovadas)
                        {
                            string emailUsuario = inscricao.Usuario.Email;
                            int codigoFuncao = inscricao.FuncaoEvento.Funcao.Codigo;
                            AvaliacaoUsuario avaliacaoUsuario = new AvaliacaoUsuario();
                            if (!avaliacaoUsuario.verificarAvaliacaoExistente(codigoFuncao, emailUsuario))
                            {
                                eventosAvaliacaoPendente.Add(ev);
                            }
                        }
                    }
                    litEventos.Text += $@"<h1 class=""container_title"">Eventos com avaliações pendentes: </h1>";
                    if (eventosAvaliacaoPendente.Count > 0)
                    {
                        eventosAvaliacaoPendente = eventosAvaliacaoPendente.Distinct().ToList();
                        litEventos.Text += "<div class='eventos'>";
                        foreach (Evento ev in eventosAvaliacaoPendente)
                        {
                            nota = evento.calcularMediaAvaliacao(ev.Codigo);
                            litEventos.Text += $@"<a href='avaliacao.aspx?c={ev.Codigo}'>
                                                      <article class=""evento"">
                                                        <img src='{ev.Imagem}' alt="""" class=""evento_capa"">
                                                        <div class=""content"">
                                                          <div class=""titulo-ong"">
                                                            <h2>{ev.Nome}</h2>
                                                            <h4 class=""evento_autor cinzaEItalico"">por {ev.Empresa.Nome}</h4>
                                                          </div>
                                                            <p class=""evento_descricao"">{ev.Descricao}</p>
                                                            <div class=""evento_localizacao"">
                                                                <span class=""material-symbols-outlined"">location_on</span>
                                                                <h5 class=""cinzaEItalico"">{ev.Endereco}</h5>
                                                            </div>
                                                          </div>
                                                          <div class=""evento_avaliacao"">
                                                              <span class=""material-symbols-outlined"">star</span>
                                                              <span class=""data"">{nota}</span>
                                                          </div>
                                                          <div class=""avaliacao-pendente"">
                                                            <span class=""material-symbols-outlined"">star</span>
                                                            <p>Avaliação pendente</p>
                                                          </div>
                                                    </article> </a>";
                        }
                        litEventos.Text += $@"</div> 
                                </article>
                            </main>";
                    }
                    else
                    {

                    }
                    return;
                }

                litEventos.Text += $@"<main><article class='container'>
                                        <h1 class=""container_title"">Eventos com inscrições pendentes: </h1>
                                        <div class=""eventos"">";

                foreach (Evento ev in eventos)
                {
                    int iPendentes = inscricaoEvento.contarInscricoesPendentes(ev.Codigo.ToString());

                    litEventos.Text += $@"<a href='inscricoes.aspx?c={ev.Codigo}'>
                                                <article class=""evento"">
                                                    <img src='{ev.Imagem}' alt="""" class=""evento_capa"">
                                                    <div class=""content"">
                                                        <div class=""titulo-ong"">
                                                            <h2>{ev.Nome}</h2>
                                                            <h4 class=""evento_autor cinzaEItalico"">por {ev.Empresa.Nome}</h4>
                                                        </div>
                                                        <p class=""evento_descricao"">{ev.Descricao}</p>
                                                        <div class=""evento_localizacao"">
                                                            <span class=""material-symbols-outlined"">location_on</span>
                                                            <h5 class=""cinzaEItalico"">{ev.Endereco}</h5>
                                                        </div>
                                                    </div>
                                                    <div class=""evento_data"">
                                                        <span class=""material-symbols-outlined"">calendar_month</span>
                                                        <span class=""data"">{ev.DataInicio.ToString("dd/MM")}</span>
                                                    </div>";
                    if (iPendentes > 0)
                        if (iPendentes == 1)
                            litEventos.Text += $@"<div class=""inscricoes-pendentes"">
                                                            <p>{iPendentes} inscrição pendente</p>
                                                        </div>";
                        else
                            litEventos.Text += $@"<div class=""inscricoes-pendentes"">
                                                                    <p>{iPendentes} inscrições pendentes</p>
                                                                </div>";
                    litEventos.Text += "</article> </a>";
                }
                litEventos.Text += "</div>";

                eventos = evento.listarTodosEventosEncerrados(email);
                foreach (Evento ev in eventos)
                {
                    List<InscricaoEvento> inscricoesAprovadas = new List<InscricaoEvento>(inscricaoEvento.listarAprovados(ev.Codigo.ToString()));
                    foreach (InscricaoEvento inscricao in inscricoesAprovadas)
                    {
                        string emailUsuario = inscricao.Usuario.Email;
                        int codigoFuncao = inscricao.FuncaoEvento.Funcao.Codigo;
                        AvaliacaoUsuario avaliacaoUsuario = new AvaliacaoUsuario();
                        if (!avaliacaoUsuario.verificarAvaliacaoExistente(codigoFuncao, emailUsuario))
                        {
                            eventosAvaliacaoPendente.Add(ev);
                        }
                    }
                }

                if (eventosAvaliacaoPendente.Count > 0)
                {
                    eventosAvaliacaoPendente = eventosAvaliacaoPendente.Distinct().ToList();
                    litEventos.Text += $@"<h1 class=""container_title"">Eventos com avaliações pendentes: </h1>
                                        <div class=""eventos"">";
                    foreach (Evento ev in eventosAvaliacaoPendente)
                    {
                        nota = evento.calcularMediaAvaliacao(ev.Codigo);
                        litEventos.Text += $@"<a href='avaliacao.aspx?c={ev.Codigo}'>
                                                      <article class=""evento"">
                                                        <img src='{ev.Imagem}' alt="""" class=""evento_capa"">
                                                        <div class=""content"">
                                                          <div class=""titulo-ong"">
                                                            <h2>{ev.Nome}</h2>
                                                            <h4 class=""evento_autor cinzaEItalico"">por {ev.Empresa.Nome}</h4>
                                                          </div>
                                                            <p class=""evento_descricao"">{ev.Descricao}</p>
                                                            <div class=""evento_localizacao"">
                                                                <span class=""material-symbols-outlined"">location_on</span>
                                                                <h5 class=""cinzaEItalico"">{ev.Endereco}</h5>
                                                            </div>
                                                          </div>
                                                          <div class=""evento_avaliacao"">
                                                              <span class=""material-symbols-outlined"">star</span>
                                                              <span class=""data"">{nota}</span>
                                                          </div>
                                                          <div class=""avaliacao-pendente"">
                                                            <span class=""material-symbols-outlined"">star</span>
                                                            <p>Avaliação pendente</p>
                                                          </div>
                                                    </article> </a>";
                    }
                    litEventos.Text += $@"</div>";



                }
                litEventos.Text += $@"</article>
                            </main>";

            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}