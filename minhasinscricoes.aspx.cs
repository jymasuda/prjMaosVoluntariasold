using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class minhasinscricoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null && Session["empresa"] == null)
            {
                string emailUsuario = Session["email"].ToString();
                InscricaoEvento inscricaoEvento = new InscricaoEvento();

                List<InscricaoEvento> inscricoes = new List<InscricaoEvento>(inscricaoEvento.listarMinhasInscricoes(emailUsuario));
                litInscricoes.Text = "";
                if (inscricoes.Count == 0)
                {
                    litInscricoes.Text = $@"<main class='nao-existe-main'>
                                            <div class='txt-nao-existe'>
                                                <span class='material-symbols-outlined'>cancel</span>
                                                <h1>Você não tem inscrições pendentes!</h1>
                                            </div>
                                            <div class='voltarPagina'>
                                                <a href='index.aspx'>
                                                    <span class='material-symbols-outlined'>arrow_back</span>
                                                    <h2 class='linkVoltar'>Voltar para a página principal</h2>
                                                </a>
                                            </div>
                                        </main>";
                    return;
                }
                litInscricoes.Text += $@"   <main>
                                                <div class=""titulo"">
                                                    <h1 class=""bold"">Minhas inscrições</h1>
                                                </div>
                                                <article class=""inscricoes"">
                                                    <section class=""area-voluntarios"">
                                                        <div>";
                litInscricoes.Text += $@"<div class='voluntario'>
                                                <div class='icon-usuario'>
                                                    <h2>Evento</h2>
                                                </div>
                                                <div class='vaga' style=""color: black;"">
                                                    <p>Vaga</p>
                                                </div>
                                                <div class='avaliacao-usuario' style=""width: 50%;"">
                                                    <p>Status</p>
                                                </div>
                                                <div class='icons escondido'>
                                                    <span style='cursor:pointer;'nao-selecionavel material-symbols-outlined btnRecusar'>close</span>
                                                </div>
                                            </div>";
                foreach (InscricaoEvento i in inscricoes)
                {
                    if (i.Aprovado == false)
                    {
                        litInscricoes.Text += $@"<div class='voluntario'>
                                                <div class='icon-usuario'>
                                                    <h2>{i.FuncaoEvento.Evento.Nome}</h2>
                                                </div>
                                                <div class='vaga'>
                                                    <p>{i.FuncaoEvento.Funcao.Nome}</p>
                                                </div>
                                                <div class='avaliacao-usuario'>
                                                    <span class='nao-selecionavel material-symbols-outlined'>schedule</span>
                                                    <p>Pendente</p>
                                                </div>
                                                <div class='icons'>
                                                    <span style='cursor:pointer;' id={i.FuncaoEvento.Funcao.Codigo} class='{emailUsuario} {i.FuncaoEvento.Evento.Codigo} nao-selecionavel material-symbols-outlined btnRecusar'>close</span>
                                                </div>
                                            </div>";
                    }
                    else
                    {
                        litInscricoes.Text += $@"<div class='voluntario'>
                                                <div class='icon-usuario'>
                                                    <h2>{i.FuncaoEvento.Evento.Nome}</h2>
                                                </div>
                                                <div class='vaga'>
                                                    <p>{i.FuncaoEvento.Funcao.Nome}</p>
                                                </div>
                                                <div class='avaliacao-usuario'>
                                                    <span class='nao-selecionavel material-symbols-outlined'>check</span>
                                                    <p>Aceita</p>
                                                </div>
                                                <div class='icons'>
                                                    <span style='cursor:pointer;' id={i.FuncaoEvento.Funcao.Codigo} class='{emailUsuario} {i.FuncaoEvento.Evento.Codigo} nao-selecionavel material-symbols-outlined btnRecusar'>close</span>
                                                </div>
                                            </div>";
                    }
                }
                litInscricoes.Text += $@"</div>
                                        </section>
                                    </article>
                                </main>";

            }
            else
            {
                litInscricoes.Text = "<h1 style='display:flex; justify-content:center;'>Voce deve estar logado como usuario para visualizar suas inscrições</h1>";
            }


        }
    }
}