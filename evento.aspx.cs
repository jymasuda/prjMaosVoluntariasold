using MySql.Data.MySqlClient;
using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class evento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Evento evento = new Evento();
            Evento evento1 = new Evento();
            int codigoEvento = 0;
            int.TryParse(Request["c"], out codigoEvento);
            evento = evento1.listarConteudo(codigoEvento);
            if (Request["c"] != null && evento.Nome != null)
            {
                Empresa empresa = new Empresa();
                string emailUsuario = null;
                string emailEmpresa = null;
                if (Session["email"] != null)
                 emailEmpresa = Session["email"].ToString();
                if (Session["empresa"] != null && empresa.verificaDonoEvento(emailEmpresa, codigoEvento))

                {
                    litEvento.Text = $@"
                                    <main>
                                       <article id='tituloInformacoes'>
                                            <div class='titulo-evento'>
                                                <h1>{evento.Nome}</h1>
                                                ";
                    if(evento.DataFim > DateTime.Now)
                    {
                        litEvento.Text += $@"<div style='display: flex;'>
                                             <span class='span-editar' id='btnEditarInformacoes'>
                                                    <span class='nao-selecionavel material-symbols-outlined icon-editar'>edit</span>
                                                    <span class='btn-editar'><p>Editar</p></span>
                                             </span>
                                             <span class='span-deletar-evento' id='deletarEvento'>
                                                    <span class='nao-selecionavel material-symbols-outlined deletar'>delete</span>
                                                    <p>Deletar</p> 
                                             </span>
                                            </div>";
                    }
                    // metonimia
                    litEvento.Text += $@"
                                            </div>

                                            <div class='informacoes-evento'>
                                                <div class='informacao data-hora' id='text-box-data-hora'>
                                                    <span class='nao-selecionavel material-symbols-outlined'>schedule</span>
                                                    <div class='cinza-italico'>
                                                        <div class='input-datetime'><p>Data de início: {evento.DataInicio.ToString("dd/MM/yyyy")} às {evento.DataInicio.ToString("HH:mm")}</p></div>
                                                        <div class='input-datetime'><p>Data de fim: {evento.DataFim.ToString("dd/MM/yyyy")} às {evento.DataFim.ToString("HH:mm")}</p></div>
                                                    </div>
                                                </div>

                                                <div class='informacao endereco'>
                                                    <span class='nao-selecionavel material-symbols-outlined'>location_on</span>
                                                    <div>
                                                        <p class='cinza-italico'>Endereço: {evento.Endereco}</p>
                                                    </div>
                                                </div>

                                            <div class='informacao categoria'>
                                                    <div>
                                                       <span class='nao-selecionavel material-symbols-outlined icone' id='{evento.CategoriaEvento.Codigo}'></span>
                                                    </div>
                                                    <p class='cinza-italico'>{evento.CategoriaEvento.Nome}</p>
                                                </div>

                                                <div class='informacao nome-ong'>
                                                    <img src='{evento.Empresa.Foto}' alt=''>
                                                    <p class='cinza-italico'>{evento.Empresa.Nome}</p>
                                                </div>

                                            </div>
                                       </article>

                                        <article class='sobre-evento'>
                                                <div class='texto-evento'>
                                                    <div class='sobre-editar'>
                                                        <h1>Sobre o evento</h1>
                                                    </div>

                                                    <p>{evento.Descricao}</p>
                                                </div>
                                                <div class='img-evento'>";
                    
                    litEvento.Text += $@"<img src='{evento.Imagem}'>
                                                </div>
                                        </article>

                                        <article id='artVaga'>
                                                <div class='titulo-vaga'>
                                                    <div class='titulo-vaga-texto'>
                                                        <h1>Vagas disponíveis:</h1>
                                                        <p>Inscrições disponíveis até: {evento.DataLimiteInscricao.ToString("dd/MM/yyyy")} às {evento.DataLimiteInscricao.ToString("HH:mm")}</p>
                                                    </div>";
                    if (evento.DataFim > DateTime.Now)
                        litEvento.Text += $@"<span class='span-editar editar-vaga' id='btnEditarVaga'>
                                                        <span class='nao-selecionavel material-symbols-outlined icon-editar'>edit</span>
                                                        <span class='btn-editar'><p>Editar</p></span> 
                                            </span>";
                    litEvento.Text += $@"</div>
                                                <div class='vaga'>
                                                <div class='vagas scrollbar'>";
                    if (evento.DataLimiteInscricao > DateTime.Now)
                        if (evento.DataFim > DateTime.Now)
                        litEvento.Text += $@"<div class='adicionar-vaga'>
                                                    <span id='adicionarVagaIcon' class='nao-selecionavel material-symbols-outlined'>add</span>
                                                    <span>Adic. Vaga</span>
                                        </div>";
            
                    FuncaoEvento vaga = new FuncaoEvento();
                    List<FuncaoEvento> vagas = vaga.listarFuncoes(evento.Codigo);
                    FuncaoEvento vaga1 = new FuncaoEvento();


                    CategoriaFuncao funcao = new CategoriaFuncao();
                    funcao = funcao.pegarCodigoCategoria(codigoEvento.ToString());
                    if (vagas.Count > 0)
                    {

                        litEvento.Text += $@"<div id='{vagas[0].Inicio}' class='funcao selecionado'>
                                                    <p id='{vagas[0].Funcao.Codigo}'>{vagas[0].Funcao.Nome}</p>";
                        if (evento.DataLimiteInscricao > DateTime.Now)
                            litEvento.Text += $@"<span class='material-symbols-outlined nao-selecionavel' id='deletar'>delete</span>";
                        litEvento.Text +="</div>";
                            vaga1.Descricao = vagas[0].Descricao;
                            vaga1.Inicio = vagas[0].Inicio;
                            vaga1.Fim = vagas[0].Fim;
                            vaga1.QuantidadeVagas = vagas[0].QuantidadeVagas;
                            vagas.RemoveRange(0, 1);
                            foreach (FuncaoEvento v in vagas)
                            {
                                {
                                litEvento.Text += $@"
                                                <div id='{v.Inicio}' class='funcao'>
                                                    <p id='{v.Funcao.Codigo}'>{v.Funcao.Nome}</p>";
                                if (evento.DataLimiteInscricao > DateTime.Now)
                                    litEvento.Text += $@"<span class='material-symbols-outlined nao-selecionavel' id='deletar'>delete</span>";
                                litEvento.Text += $@"</div>
                                                ";
                                }
                            }
                        litEvento.Text += $@"
                                            </div>

                                            <div class='descricao'>
                                                <p class='descricao-data'>{vaga1.Inicio.ToString("dd/MM")} {vaga1.Inicio.ToString("HH:mm")} até {vaga1.Fim.ToString("HH:mm")}</p>
                                                <span class='escondido codigoFuncaoCategoria' id='{funcao.Codigo}'></span>
                                                <p class='descricao-info'>{vaga1.Descricao}</p>";
                                                
                        if (evento.DataLimiteInscricao < DateTime.Now)
                            litEvento.Text += $@"<p class='descricao-aviso'>Período de inscrições encerrado!</p>";
                        else
                            litEvento.Text += $@"<p class='descricao-aviso'></p>";
                        litEvento.Text += $@" </div>
                                            <div class='botao'>
                                                <div>";
                        if (evento.DataLimiteInscricao > DateTime.Now)
                        {
                            if (vaga1.QuantidadeVagas > 1)
                            litEvento.Text += $@"<p id='vagasRestantes'>{vaga1.QuantidadeVagas} vagas restantes</p>";
                            else if(vaga1.QuantidadeVagas == 1)
                            {
                                litEvento.Text += $@"<p id='vagasRestantes'>{vaga1.QuantidadeVagas} vaga restante</p>";
                            }
                        }
                        litEvento.Text += $@"<input class='btn azul' type='button' value='Ver inscrições' id='btnInscicoes'/>
                                                </div>
                                            </div>
                                        </div>
                                    </article>";
                    }
                    else
                    {
                        {
                            litEvento.Text += $@"
                                            </div>
                                            <div class='descricao'>
                                                <p class='descricao-data'></p>
                                                <p class='descricao-info'>Nenhuma vaga criada ainda!</p>
                                                <p class='descricao-aviso'>Eventos sem vagas não aparecerão para os voluntários!</p>
                                            </div>
                                            <div class='botao'>
                                                <div>
                                                    <p id='vagasRestantes'></p>
                                                </div>
                                            </div>
                                    </article>";
                        }
                    }

                    ImagemEvento imagemEvento = new ImagemEvento();
                    List<ImagemEvento> imagens = new List<ImagemEvento>(imagemEvento.listarImagens(codigoEvento));
                    if (imagens.Count > 0)
                    {
                        litEvento.Text += $@"<article class=""galeria"">
                                            <div class=""texto-galeria"">
                                                <h1>Galeria</h1>";
                        if (evento.DataFim > DateTime.Now)
                            litEvento.Text += $@"<span class=""adicionar-imagem"">
                            <span class=""nao-selecionavel material-symbols-outlined"">add</span>
                                <label for='inputAdcImgGaleria'><p>Adic. Imagem</p></label>
                                <input type='file' name='inputAdcImgGaleria' id='inputAdcImgGaleria'>
                            </span>";
                        litEvento.Text += $@"</div>
                                                <div class=""f-carousel imagens-galeria"" id=""carrossel"">
                                                    <div class=""f-carousel__viewport"">
                                                        <div class=""f-carousel__track"">";
                        foreach (ImagemEvento imagem in imagens)
                        {
                            litEvento.Text += $@"<div class=""f-carousel__slide imagem-galeria"" id='{imagem.Codigo}'>
                                                 <img src='{imagem.Imagem}' alt=''/>'";
                            if(evento.DataFim > DateTime.Now)
                                litEvento.Text += $@"<span class=""deletar-img"" id=""btnDelatarImg"" >
                                                        <span class=""nao-selecionavel material-symbols-outlined"" id=""deletar-galeria"">delete</span>
                                                     </span>";
                            litEvento.Text += $@"</div>";
                        }

                        litEvento.Text += $@"</div>
                                    </div>
                                </div>
                            </article>
                            </main>
                            ";
                    }
                    else
                    {
                        litEvento.Text += $@"<article class=""galeria"">  <div class=""texto-galeria""><h1>Galeria</h1>";
                        if (evento.DataFim > DateTime.Now)
                            litEvento.Text += $@"<span class=""adicionar-imagem"">
                            <span class=""nao-selecionavel material-symbols-outlined"">add</span>
                                <label for='inputAdcImgGaleria'><p>Adic. Imagem</p></label>
                                <input type='file' name='inputAdcImgGaleria' id='inputAdcImgGaleria'>
                            </span>";
                        litEvento.Text += $@"</div> <p>Esse evento ainda não tem nenhuma imagem!</p>  </div> </article> </main>";
                    }                                   
                }
                else
                {
                    #region Carregamento da página para qualquer um que não seja dono evento
                    string sessao;
                    if (Session["usuario"] != null)
                    {
                        sessao = Session["usuario"].ToString();
                        emailUsuario = Session["email"].ToString();
                    }
                    litEvento.Text = $@"
                                    <main>
                                       <article>
                                            <div class='titulo-evento'>
                                                <h1>{evento.Nome}</h1>
                                            </div>
                                            <div class='informacoes-evento'>
                                                <div class='informacao data-hora'>
                                                    <span class='nao-selecionavel material-symbols-outlined'>schedule</span>
                                                    <div class='cinza-italico'>
                                                        <div class='input-datetime'><p>Data de início: {evento.DataInicio.ToString("dd/MM/yyyy")} às {evento.DataInicio.ToString("HH:mm")} </p></div>
                                                        <div class='input-datetime'><p>Data de fim: {evento.DataFim.ToString("dd/MM/yyyy")} às {evento.DataFim.ToString("HH:mm")}</p></div>
                                                    </div>
                                                </div>
        
                                                <div class='informacao endereco'>
                                                    <span class='nao-selecionavel material-symbols-outlined'>location_on</span>
                                                    <div>
                                                        <p class='cinza-italico'>Endereço: {evento.Endereco}</p>
                                                    </div>
                                                </div>
                                                <div class='informacao categoria'>
                                                    <div>
                                                        <span class='nao-selecionavel material-symbols-outlined icone' id='{evento.CategoriaEvento.Codigo}'></span>
                                                    </div>
                                                    <p class='cinza-italico'>{evento.CategoriaEvento.Nome}</p>
                                                </div>
                                                <div class='informacao nome-ong'>
                                                    <img src='{evento.Empresa.Foto}' alt=''>
                                                    <p class='cinza-italico'>{evento.Empresa.Nome}</p>
                                                </div>
                                            </div>  
                                       </article>

                                       <article class='sobre-evento'>
                                                <div class='texto-evento'>
                                                    <div class='sobre-editar'>
                                                        <h1>Sobre o evento</h1>
                                                    </div>
                
                                                    <p>{evento.Descricao}</p>
                                                </div>
                                                <div class='img-evento'>
                                                    <img src='{evento.Imagem}'>
                                                </div>
                                        </article>

                                        <article>
                                                <div class='titulo-vaga'>
                                                    <div class='titulo-vaga-texto'>
                                                        <h1>Vagas disponíveis:</h1>
                                                        <p>Inscrições disponíveis até: {evento.DataLimiteInscricao.ToString("dd/MM/yyyy")} às {evento.DataLimiteInscricao.ToString("HH:mm")}</p>
                                                    </div>
                                                </div>
                                                <div class='vaga'><div class='vagas scrollbar'>";
            
                    FuncaoEvento vaga = new FuncaoEvento();
                    List<FuncaoEvento> vagas = vaga.listarFuncoes(evento.Codigo);
                    FuncaoEvento vaga1 = new FuncaoEvento();
                                                        
                    if (vagas.Count > 0 )
                    {
                     
                        litEvento.Text += $@"
                                                <div id='{vagas[0].Inicio}' class='funcao selecionado'>
                                                    <p id='{vagas[0].Funcao.Codigo}'>{vagas[0].Funcao.Nome}</p>
                                                </div>
                                            ";
                        vaga1.Descricao = vagas[0].Descricao;
                        vaga1.Inicio = vagas[0].Inicio;
                        vaga1.Fim = vagas[0].Fim;
                        vaga1.QuantidadeVagas = vagas[0].QuantidadeVagas;
                        Funcao funcaovaga1 = new Funcao();
                        funcaovaga1.Nome = vagas[0].Funcao.Nome;
                        funcaovaga1.Codigo = vagas[0].Funcao.Codigo;
                        vaga1.Funcao = funcaovaga1;
                        vagas.RemoveRange(0, 1);
                        foreach (FuncaoEvento v in vagas)
                        {
                            litEvento.Text += $@"
                                                <div id='{v.Inicio}' class='funcao'>
                                                      <p id='{v.Funcao.Codigo}'>{v.Funcao.Nome}</p>
                                                </div>
                                                ";
                        }
                        if (evento.DataLimiteInscricao < DateTime.Now)
                        {
                            litEvento.Text += $@"
                                        </div>

                                        <div class='descricao'>
                                            <p class='descricao-data'>{vaga1.Inicio.ToString("dd/MM")}  {vaga1.Inicio.ToString("HH:mm")} até {vaga1.Fim.ToString("HH:mm")}</p>
                                            <p class='descricao-info'>{vaga1.Descricao}</p>    
                                            <p class='descricao-aviso'>O período de inscrições deste evento acabou!</p>
                                        </div>
                                        <div class='botao'>
                                    </article>
                                        ";
                        }
                        else if (evento.DataFim > DateTime.Now)
                        {
                            litEvento.Text += $@"
                                        </div>

                                        <div class='descricao'>
                                            <p class='descricao-data'>{vaga1.Inicio.ToString("dd/MM")}  {vaga1.Inicio.ToString("HH:mm")} até {vaga1.Fim.ToString("HH:mm")}</p>
                                            <p class='descricao-info'>{vaga1.Descricao}</p>
                                            <p class='descricao-aviso'>Lembre-se, ao se inscrever em uma vaga, você assume que irá comparecer na data e hora comprometidos.</p>
                                        </div>
                                        <div class='botao'>
                                            <div>";
                            if (vaga1.QuantidadeVagas > 1)
                                litEvento.Text += $@"<p id='vagasRestantes'>{vaga1.QuantidadeVagas} vagas restantes</p>";
                            else if (vaga1.QuantidadeVagas == 1)
                            {
                                litEvento.Text += $@"<p id='vagasRestantes'>{vaga1.QuantidadeVagas} vaga restante</p>";
                            }
                            else if (vaga1.QuantidadeVagas == 0)
                            {
                                litEvento.Text += $@"<p id='vagasRestantes'>0 vagas restantes</p>";
                            }
                            InscricaoEvento inscricao = new InscricaoEvento();
                            if (Session["usuario"] != null)
                            {
                                if (inscricao.procurarInscricao(emailUsuario, evento.Codigo, vaga1.Funcao.Codigo, vaga1.Inicio))
                                {
                                    litEvento.Text += $@"
                                            <input class='btn vazado2' type='button' value='Já inscrito' id='btnInscrito'/>
                                                        </div>
                                                    </div>
                                                </div>
                                            </article>";
                                }
                                else if (vaga1.QuantidadeVagas > 0)
                                {
                                    litEvento.Text += $@"
                                            <input class='btn azul' type='button' value='Quero me inscrever' id='btnInscrever'/>
                                                        </div>
                                                    </div>
                                                </div>
                                            </article>";

                                }
                                else
                                {
                                    litEvento.Text += $@"
                                            <input class='btn azul' type='button' value='Sem vagas disponíveis' id='btn' disabled/>
                                                        </div>
                                                    </div>
                                                </div>
                                            </article>";
                                }
                            }
                            else if (vaga1.QuantidadeVagas > 0)
                            {
                                litEvento.Text += $@"
                                            <input class='btn azul' type='button' value='Quero me inscrever' id='btnInscrever'/>
                                                        </div>
                                                    </div>
                                                </div>
                                            </article>";

                            }
                            else
                            {
                                litEvento.Text += $@"
                                            <input class='btn azul' type='button' value='Sem vagas disponíveis' id='btn' disabled/>
                                                        </div>
                                                    </div>
                                                </div>
                                            </article>";

                            }
                        }
                        
                        else if (evento.DataFim < DateTime.Now)
                        {
                            litEvento.Text += $@"
                                        </div>

                                        <div class='descricao'>
                                            <p class='descricao-data'>{vaga1.Inicio.ToString("dd/MM")}  {vaga1.Inicio.ToString("HH:mm")} até {vaga1.Fim.ToString("HH:mm")}</p>
                                            <p class='descricao-info'>{vaga1.Descricao}</p>    
                                        </div>
                                        <div class='botao'>
                                    </article>
                                        ";
                            
                        }                                                  
                    }
                    else
                    {
                        litEvento.Text += $@"
                                            <h1>Nenhuma vaga criada ainda!</h1>
                                            </div>
                                    </article>";
                    }

                    ImagemEvento imagemEvento = new ImagemEvento();
                    List<ImagemEvento> imagens = new List<ImagemEvento>(imagemEvento.listarImagens(codigoEvento));
                    if (imagens.Count > 0)
                    {
                        litEvento.Text += $@"<article class=""galeria"">
                                            <div class=""texto-galeria""><h1>Galeria</h1></div>
                                            <div class=""f-carousel imagens-galeria"" id=""carrossel"">
                                                <div class=""f-carousel__viewport"">
                                                    <div class=""f-carousel__track"">";
                        foreach (ImagemEvento imagem in imagens)
                        {
                            litEvento.Text += $@"<div class=""f-carousel__slide imagem-galeria""><img src='{imagem.Imagem}' alt=''/></div>";
                        }

                        litEvento.Text += $@"</div>
                                    </div>
                                </div>
                            </article>
                            ";
                    }
                    else
                    {
                        litEvento.Text += $@"<article class=""galeria"">  <div class=""texto-galeria""><h1>Galeria</h1></div> <p>Esse evento não tem nenhuma imagem!</p>  </div> </article>";
                    }

                    litEvento.Text += $@"</main>";
                #endregion
                }
            }
            else
            {
                litEvento.Text = $@"    <main class='nao-existe-main'>
                                            <div class='txt-nao-existe'>
                                                <span class='material-symbols-outlined'>cancel</span>
                                                <h1>Esse evento não existe.</h1>
                                            </div>
                                            <div class='voltarPagina'>
                                                <a href='index.aspx'>
                                                    <span class='material-symbols-outlined'>arrow_back</span>
                                                    <h2 class='linkVoltar'>Voltar para a página principal</h2>
                                                </a>
                                            </div>
                                        </main>";
            }
        }
    }
}