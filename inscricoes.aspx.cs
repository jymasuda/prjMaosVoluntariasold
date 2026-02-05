using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class inscricoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["c"] != null)
            {
                if (Request["c"].ToString() != "")
                {
                    if (Session["usuario"] == null && Session["empresa"] != null)
                    {
                        string emailEmpresa = Session["email"].ToString();
                        string codigoEvento = Request["c"].ToString();
                        Empresa empresa = new Empresa();
                        if (empresa.verificaDonoEvento(emailEmpresa, int.Parse(codigoEvento)))
                        {
                            int listaPendente = 0;
                            int listaAprovado = 0;

                            AvaliacaoUsuario avaliacaoUsuario = new AvaliacaoUsuario();
                            InscricaoEvento inscricaoEvento = new InscricaoEvento();
                            List<InscricaoEvento> inscricoes = new List<InscricaoEvento>(inscricaoEvento.listar(codigoEvento));
                            Evento evento = new Evento();

                            litTitulo.Text = $@"<h1 class='bold'>Inscrições</h1>
                                                <h1>{evento.buscarNomeEvento(codigoEvento)}</h1>
                                            ";
                            litTituloAprovadas.Text = "<h1 class='bold'>Inscrições Aprovadas</h1>";
                            litInscricoes.Text = "";
                            if (inscricoes.Count > 0)
                            {
                                listaPendente++;
                                litInscricoes.Text += $@"<div class='voluntario' style=""margin-left: 35px;"">
                                                <div class='icon-usuario icon-voluntario'>
                                                    <h2 style='font-weight: bold'>Voluntário</h2>
                                                </div>
                                                <div class='vaga' style=""color: black"">
                                                    <p style='font-weight: bold'>Vaga</p>
                                                </div>
                                                <div class='icons escondido'>
                                                    <span style='cursor:pointer;'nao-selecionavel material-symbols-outlined btnRecusar'>close</span>
                                                </div>
                                            </div>";
                                foreach (InscricaoEvento i in inscricoes)
                                {
                                    int quantidadeAvaliacao = avaliacaoUsuario.calcularNotaUsuario(i.Usuario.Email);
                                    litInscricoes.Text += $@"<div class='voluntario'>
                                                    <a class='icon-link' href='perfil.aspx?u={i.Usuario.Email}'>
                                                            <div class='icon-usuario'>
                                                            <div class='crop-icon'><img src='{i.Usuario.Foto}'></div>
                                                            <h2>{i.Usuario.Nome}</h2>
                                                            </div>
                                                        </a>
                                                    <div class='avaliacao-usuario'>
                                                        <span class='nao-selecionavel material-symbols-outlined'>star</span>
                                                        <p>{quantidadeAvaliacao.ToString()}</p>
                                                    </div>
                                                    <div class='vaga'>
                                                        <p>{i.FuncaoEvento.Funcao.Nome}</p>
                                                    </div>
                                                    <div class='icons'>
                                                        <span id='{i.Usuario.Email}' class='{i.FuncaoEvento.Funcao.Codigo} nao-selecionavel material-symbols-outlined btnRecusar'>close</span>
                                                        <span id='{i.Usuario.Email}' class='{i.FuncaoEvento.Funcao.Codigo} nao-selecionavel material-symbols-outlined btnAceitar'>done</span>
                                                    </div>
                                                </div>";
                                }
                            }
                            else
                            {
                                litInscricoes.Text = "<h1 style='display:flex; justify-content:center;'>Sem vagas pendentes</h1>";
                            }


                            List<InscricaoEvento> inscricoesAprovadas = new List<InscricaoEvento>(inscricaoEvento.listarAprovados(codigoEvento));
                            litInscricoesAprovadas.Text = "";
                            if (inscricoesAprovadas.Count > 0)
                            {
                                listaAprovado++;
                                foreach (InscricaoEvento i in inscricoesAprovadas)
                                {
                                    int quantidadeAvaliacao = avaliacaoUsuario.calcularNotaUsuario(i.Usuario.Email);
                                    litInscricoesAprovadas.Text += $@"<div class='voluntario'>
                                                        
                                                        <a href='perfil.aspx?{i.Usuario.Email}'>
                                                            <div class='icon-usuario'>
                                                            <div class='crop-icon'><img src='{i.Usuario.Foto}'></div>
                                                            <h2>{i.Usuario.Nome}</h2>
                                                            </div>
                                                        </a>
                                                    <div class='avaliacao-usuario'>
                                                        <span class='nao-selecionavel material-symbols-outlined'>star</span>
                                                        <p>{quantidadeAvaliacao.ToString()}</p>
                                                    </div>
                                                    <div class='vaga'>
                                                        <p>{i.FuncaoEvento.Funcao.Nome}</p>
                                                    </div>
                                                    <div class='icons'>
                                                        <span id='{i.Usuario.Email}' class='{i.FuncaoEvento.Funcao.Codigo}  nao-selecionavel material-symbols-outlined btnRecusar'>close</span>
                                                    </div>
                                                </div>";
                                }
                            }
                            else
                            {
                                litInscricoesAprovadas.Text = "<h1 style='display:flex; justify-content:center;'>Sem vagas aprovadas</h1>";
                            }
                            if (listaAprovado == 0 && listaPendente == 0)
                            {
                                litTituloAprovadas.Text = "";
                                litInscricoesAprovadas.Text = "";
                                litInscricoes.Text = "<h1 style='display:flex; justify-content:center;'>Sem vagas pendentes ou aprovadas</h1>";
                            }
                        }
                        else
                        {
                            litInscricoes.Text = "<h1 style='display:flex; justify-content:center;'>Voce deve ser o dono do evento para visualizar as inscrições pendentes</h1>";
                        }

                    }
                    else
                    {
                        litInscricoes.Text = "<h1 style='display:flex; justify-content:center;'>Voce deve estar logado na conta da empresa dona do evento para visualizar as inscrições pendentes</h1>";
                    }

                }
                else
                {
                    litInscricoes.Text = "<h1 style='display:flex;font-size:20px; justify-content:center;'>Nenhum evento selecionado</h1>";
                }
            }
            else
            {
                litInscricoes.Text = "<h1 style='display:flex;font-size:20px; justify-content:center;'>Nenhum evento selecionado</h1>";
            }
        }
    }
}