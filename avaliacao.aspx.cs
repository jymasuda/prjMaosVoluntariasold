using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class avaliacao : System.Web.UI.Page
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
                            Evento evento = new Evento();
                            if (evento.verificarEventoEncerrado(int.Parse(codigoEvento)))
                            {
                                litTitulo.Text = $@"<h1>{evento.buscarNomeEvento(codigoEvento)}</h1>";
                                InscricaoEvento inscricaoEvento = new InscricaoEvento();
                                List<InscricaoEvento> inscricoesAprovadas = new List<InscricaoEvento>(inscricaoEvento.listarAprovados(codigoEvento));
                                litAvaliacao.Text = "";
                                int lista = 0;
                                foreach (InscricaoEvento i in inscricoesAprovadas)
                                {

                                    string emailUsuario = i.Usuario.Email;
                                    int codigoFuncao = i.FuncaoEvento.Funcao.Codigo;
                                    AvaliacaoUsuario avaliacaoUsuario = new AvaliacaoUsuario();
                                    if (!avaliacaoUsuario.verificarAvaliacaoExistente(codigoFuncao, emailUsuario))
                                    {
                                        lista = lista + 1;
                                    }
                                }
                                if (lista > 0)
                                {
                                    foreach (InscricaoEvento i in inscricoesAprovadas)
                                    {

                                        string emailUsuario = i.Usuario.Email;
                                        int codigoFuncao = i.FuncaoEvento.Funcao.Codigo;
                                        AvaliacaoUsuario avaliacaoUsuario = new AvaliacaoUsuario();
                                        if (!avaliacaoUsuario.verificarAvaliacaoExistente(codigoFuncao, emailUsuario))
                                        {
                                            litAvaliacao.Text += $@"<div>
                                                            <button class='collapsible'>
                                                                <div class='voluntario'>
                                                                    <div class='icon-usuario'>
                                                                        <div class='crop-icon'><img src='{i.Usuario.Foto}'></div>
                                                                        <h2>{i.Usuario.Nome}</h2>
                                                                    </div>
                                                                    <div class='avaliacao-usuario'>
                                                                        <span class='nao-selecionavel estrela material-symbols-outlined'>star</span>
                                                                        <input type='number' name='inputAvaliacao' id='inputAvaliacao' min='1' max='5' value='5'>
                                                                    </div>
                                                                    <div class='vaga'>
                                                                        <p>{i.FuncaoEvento.Funcao.Nome}</p>
                                                                    </div>
                                                                </div>
                                                             </button>
                                                             <div class='collapsible content'>
                                                                <div class='area-comentario'>
                                                                    <div class='label'>
                                                                        <label for='txtComentario'>Comentário </label>
                                                                        <p>(Opcional)</p>
                                                                    </div>
                                                                    <div class='textbox'>
                                                                        <textarea name='txtComentario' id='txtComentario' cols='30' rows='10' placeholder='Adicione um comentário sobre este voluntário'></textarea>
                                                                        <button class='{i.Usuario.Email} {i.FuncaoEvento.Funcao.Codigo} {emailEmpresa} btn header vazado' id='btnPronto'>
                                                                            <span class='pronto nao-selecionavel material-symbols-outlined'>done</span>
                                                                            Confirmar
                                                                        </button>
                                                                    </div>
                                                                </div>                       
                                                             </div>   
                                                    </div>
                                                            
                                                            ";
                                        }
                                    }

                                }
                                else
                                {
                                    litAvaliacao.Text = "<h1 style='display:flex; justify-content:center;'>Sem avaliações pendentes</h1>";
                                }
                            }
                            else
                            {
                                litAvaliacao.Text = "<h1 style='display:flex; justify-content:center;'>O evento deve ser encerrado</h1>";
                            }
                        }
                        else
                        {
                            litAvaliacao.Text = "<h1 style='display:flex; justify-content:center;'>Voce deve ser o dono do evento para visualizar as inscrições pendentes</h1>";
                        }
                    }
                    else
                    {
                        litAvaliacao.Text = "<h1 style='display:flex; justify-content:center;'>Voce deve estar logado na conta da empresa dona do evento para visualizar as inscrições pendentes</h1>;";
                    }
                }
                else
                {
                    litAvaliacao.Text = "<h1 style='display:flex;font-size:20px; justify-content:center;'>Nenhum evento selecionado</h1>;";
                }
            }
            else
            {
                litAvaliacao.Text = "<h1 style='display:flex;font-size:20px; justify-content:center;'>Nenhum evento selecionado</h1>;";
            }

        }
    }
}