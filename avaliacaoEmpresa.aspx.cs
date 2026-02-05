using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class avaliacaoEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null && Session["empresa"] == null)
            {
                string emailUsuario = Session["email"].ToString();
                Evento evento = new Evento();
                List<Evento> eventos = new List<Evento>(evento.procurarEventoAvaliacaoPendente(emailUsuario));
                litAvaliacao.Text = "";
                if (eventos.Count > 0)
                {
                    int lista = 0;
                    foreach (Evento ev in eventos)
                    {

                        int codigoEvento = ev.Codigo;
                        string nome = ev.Nome;
                        AvaliacaoEvento avaliacaoEvento = new AvaliacaoEvento();
                        if (!avaliacaoEvento.verificarAvaliacaoExistente(emailUsuario, codigoEvento))
                        {
                            lista = lista + 1;
                        }
                    }
                    if (lista > 0)
                    {
                        foreach (Evento ev in eventos)
                        {

                            int codigoEvento = ev.Codigo;
                            string nome = ev.Nome;
                            AvaliacaoEvento avaliacaoEvento = new AvaliacaoEvento();
                            if (!avaliacaoEvento.verificarAvaliacaoExistente(emailUsuario, codigoEvento))
                            {
                                litAvaliacao.Text += $@"<div>
                                            <button class='collapsible'>
                                                <div class='voluntario'>
                                                    <div class='icon-usuario'>
                                                        <div class='crop-icon'><img src='{ev.Empresa.Foto}'></div>
                                                        <h2>{nome}</h2>
                                                    </div>
                                                    <div class='avaliacao-usuario'>
                                                        <span class='nao-selecionavel estrela material-symbols-outlined'>star</span>
                                                        <input type='number' name='inputAvaliacao' id='inputAvaliacao' min='1' max='5' value='5'>
                                                    </div>
                                                    <div class='vaga'>
                                                        <p>{ev.Empresa.Nome}</p>
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
                                                        <button class='{emailUsuario} {ev.Codigo} btn header vazado' id='btnPronto'>
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
                        litAvaliacao.Text = "<h1 style='display:flex; justify-content:center;'>Sem avaliações pendentes.</h1>;";
                    }
                }
                else
                {
                    litAvaliacao.Text = "<h1 style='display:flex; justify-content:center;'>Sem avaliações pendentes.</h1>;";
                }

            }
            else
            {
                litAvaliacao.Text = "<h1 style='display:flex; justify-content:center;'>Voce deve estar logado como usuario para visualizar as avaliações pendentes.</h1>;";
            }



        }
    }
}