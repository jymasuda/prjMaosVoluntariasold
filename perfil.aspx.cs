using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Evento lista = new Evento();
            List<Evento> eventos = new List<Evento>();
            if (Request["u"] == null)
            {
                if (Session["usuario"] != null && Session["email"] != null)
                {
                    string email = Session["email"].ToString();
                    Usuario usuario = new Usuario();
                    usuario = usuario.listarPerfil(email);
                    int numeroPagina = 0;
                    int offset = 0;
                    double nota = usuario.calcularMediaAvaliacao(email);
                    litPerfil.Text = $@"<main>

                                            <article class=""container-perfil"">
                                                <div class=""div-azul"">
                                                    <div class='crop-foto-perfil' id='fotoPerfil'><img src='{usuario.Foto}' alt='Foto de perfil do usuario {usuario.Nome}'></div>
                                                    <span class='span-editar' id='btnEditarInformacoes'>
	                                                    <span class='nao-selecionavel material-symbols-outlined icon-editar'>edit</span>
                                                        <span class='btn-editar'><p>Editar</p></span>
                                                    </span>
                                                </div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <div class=""divperfil-detalhes"">
                                                    <div class=""divimg-perfil""></div>
                                                    <p class=""nome-perfil"">{usuario.Nome}<span class=""material-symbols-outlined"">star</span>{nota.ToString("N1")}</p>
                                                    <p class=""descricao-perfil"">{usuario.Descricao}</p>
                                                </div>

                                            </article>
                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos em que estou inscrito:</h1>";



                    eventos = lista.listarEventosInscrito(email, offset);
                    if (eventos.Count > 0)
                    {
                        litPerfil.Text += "<div class='eventos'>";
                        foreach (Evento evento in eventos)
                        {
                            litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                    <article class='evento'>
                                                        <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                        <div class='content'>
                                                            <div class='titulo-ong'>
                                                                <h2>{evento.Nome}</h2>
                                                                <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                            </div>
                                                            <p class='evento_descricao'>{evento.Descricao}</p>
                                                            <div class='evento_localizacao'>
                                                                <span class='material-symbols-outlined'>location_on</span>
                                                                <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                            </div>
                                                        </div>
                                                        <div class='evento_data'>
                                                            <span class='material-symbols-outlined'>calendar_month</span>
                                                            <span class='data'>{evento.DataInicio.ToString("dd/MM")}</span>
                                                        </div>
                                                    </article>
                                                </a>";
                        }
                    }
                    else
                    {
                        litPerfil.Text += $@"<p>Você não está inscrito(a) em nenhum evento no momento!</p>";
                    }
                    numeroPagina = lista.contarEventosInscrito(email);
                    if (numeroPagina > 1)
                    {
                        litPerfil.Text += $@"</div>
                                                <div class=""verMais"" id='Inscrito {numeroPagina - 1}'>
                                                    <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                                </div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos participados:</h1>
                                                <div class=""eventos"">";
                    }
                    else
                        litPerfil.Text += $@"</div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos participados:</h1>";


                    eventos = lista.listarEventosParticipado(email, offset);
                    if (eventos.Count > 0 || eventos == null)
                    {
                        litPerfil.Text += "<div class='eventos'>";
                        foreach (Evento evento in eventos)
                        {
                            nota = evento.calcularMediaAvaliacao(evento.Codigo);
                            litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                    <article class='evento'>
                                                        <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                        <div class='content'>
                                                            <div class='titulo-ong'>
                                                                <h2>{evento.Nome}</h2>
                                                                <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                            </div>
                                                            <p class='evento_descricao'>{evento.Descricao}</p>
                                                            <div class='evento_localizacao'>
                                                                <span class='material-symbols-outlined'>location_on</span>
                                                                <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                            </div>
                                                        </div>
                                                        <div class='evento_avaliacao'>
                                                            <span class='material-symbols-outlined'>star</span>
                                                            <span class='data'>{nota.ToString("N1")}</span>
                                                        </div>
                                                    </article>
                                                </a>";
                        }
                    }
                    else
                    {
                        litPerfil.Text += $@"<p>Você ainda não participou de nenhum evento!</p>";
                    }
                    numeroPagina = lista.contarEventosParticipado(email);
                    if (numeroPagina > 1)
                    {
                        litPerfil.Text += $@"</div>
                                                <div class=""verMais"" id='Participado {numeroPagina - 1}'>
                                                    <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                                </div>
                                            </article>      
                                        </main>";
                    }
                    else
                        litPerfil.Text += $@"</div>                                         
                                            </article>      
                                        </main>";
                }

                else if (Session["empresa"] != null && Session["email"] != null)
                {
                    string email = Session["email"].ToString();
                    Empresa empresa = new Empresa();
                    empresa = empresa.listarPerfil(email);
                    int numeroPagina = 0;
                    int offset = 0;
                    double nota = empresa.calcularMediaAvaliacao(email);
                    litPerfil.Text = $@"<main>
                                            <article class=""container-perfil"">
                                               <div class=""div-azul""><div class='crop-foto-perfil' id='fotoPerfil'><img src='{empresa.Foto}' alt='Foto de perfil da {empresa.Nome}'></div>
                                                <span class='span-editar' id='btnEditarInformacoes'>
	                                                <span class='nao-selecionavel material-symbols-outlined icon-editar'>edit</span>
                                                    <span class='btn-editar'><p>Editar</p></span>
                                                </span>    
                                                </div>
                                                <div class=""div-contato"">  <p class=""p-contatos""><span class=""material-symbols-outlined"">link</span> {empresa.Link}</p>   
                                                <p class=""p-contatos""><span class=""material-symbols-outlined"">call</span> {empresa.Telefone}</p></div>
                                            </article>

                                            <article class=""container-perfil"">

                                                <div class=""divperfil-detalhes"">
                                                    <div class=""divimg-perfil""></div>
                                                    <p class=""nome-perfil"">{empresa.Nome}<span class=""material-symbols-outlined"">star</span>{nota.ToString("N1")}</p>
                                                    <p class=""descricao-perfil"">{empresa.Descricao}</p>
                                                </div>

                                                <div class=""btnEditar"">
                                                    <button class=""btn azul"">Editar</button>
                                                </div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos em andamento</h1>

                                      
                                            ";


                    eventos = lista.listarEventosAcontecendo(email, offset);
                    if (eventos != null)
                        if (eventos.Count > 0)
                        {
                            litPerfil.Text += "<div class='eventos'>";
                            foreach (Evento evento in eventos)
                            {
                                litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                        <article class='evento'>
                                                            <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                            <div class='content'>
                                                                <div class='titulo-ong'>
                                                                    <h2>{evento.Nome}</h2>
                                                                    <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                                </div>
                                                                <p class='evento_descricao'>{evento.Descricao}</p>
                                                                <div class='evento_localizacao'>
                                                                    <span class='material-symbols-outlined'>location_on</span>
                                                                    <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                                </div>
                                                            </div>
                                                            <div class='evento_data'>
                                                                <span class='material-symbols-outlined'>calendar_month</span>
                                                                <span class='data'>{evento.DataInicio.ToString("dd/MM")}</span>
                                                            </div>
                                                        </article>
                                                    </a>";
                            }
                        }
                        else
                        {
                            litPerfil.Text += $@"<p>Você não tem nenhum evento em andamento!</p>";
                        }
                    numeroPagina = lista.contarEventosAcontecendo(email);
                    if (numeroPagina > 1)
                        litPerfil.Text += $@"</div>
                                            <div class=""verMais"" id='Acontecendo {numeroPagina - 1}'>
                                                <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                            </div> 
                                            </article>
                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos encerrados</h1>

                                                <div class=""eventos"">";
                    else
                        litPerfil.Text += $@"</div>
                                        </article>
                                        <article class=""container-perfil"">
                                            <h1 class=""container_title"">Eventos encerrados</h1>";



                    eventos = lista.listarEventosEncerrados(email, offset);
                    if (eventos != null)
                        if (eventos.Count > 0)
                        {
                            litPerfil.Text += "<div class='eventos'>";
                            foreach (Evento evento in eventos)
                            {
                                nota = evento.calcularMediaAvaliacao(evento.Codigo);

                                litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                        <article class='evento'>
                                                            <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                            <div class='content'>
                                                                <div class='titulo-ong'>
                                                                    <h2>{evento.Nome}</h2>
                                                                    <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                                </div>
                                                                <p class='evento_descricao'>{evento.Descricao}</p>
                                                                <div class='evento_localizacao'>
                                                                    <span class='material-symbols-outlined'>location_on</span>
                                                                    <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                                </div>
                                                            </div>
                                                            <div class='evento_avaliacao'>
                                                                <span class='material-symbols-outlined'>star</span>
                                                                <span class='data'>{nota.ToString("N1")}</span>
                                                            </div>
                                                        </article>
                                                    </a>";
                            }
                        }
                        else
                        {
                            litPerfil.Text += $@"<p>Você ainda não tem nenhum evento encerrado!</p>";
                        }

                    numeroPagina = lista.contarEventosEncerrado(email);
                    if (numeroPagina > 1)
                        litPerfil.Text += $@"</div>
                                            <div class=""verMais"" id='Encerrado {numeroPagina - 1}'>
                                                <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                            </div>
                                        </article>      
                                    </main>";
                    else
                        litPerfil.Text += $@"</div>                                     
                                        </article>      
                                    </main>";
                }

                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else if (Request["u"] != null)
            {
                string email = Request["u"].ToString();

                int numeroPagina = 0;
                int offset = 0;
                Usuario usuario = new Usuario();
                usuario = usuario.listarPerfil(email);
                if (usuario.Nome == null)
                {
                    Empresa empresa = new Empresa();
                    empresa = empresa.listarPerfil(email);
                    double nota = empresa.calcularMediaAvaliacao(email);
                    litPerfil.Text = $@"<main>
                                            <article class=""container-perfil"">
                                               <div class=""div-azul""><div class='crop-foto-perfil' id='fotoPerfil'><img src='{empresa.Foto}' alt='Foto de perfil da {empresa.Nome}'></div></div>
                                                <div class=""div-contato"">  <p class=""p-contatos""><span class=""material-symbols-outlined"">link</span> {empresa.Link}</p>   
                                                <p class=""p-contatos""><span class=""material-symbols-outlined"">call</span> {empresa.Telefone}</p></div>
                                            </article>

                                            <article class=""container-perfil"">

                                                <div class=""divperfil-detalhes"">
                                                    <div class=""divimg-perfil""></div>
                                                    <p class=""nome-perfil"">{empresa.Nome}<span class=""material-symbols-outlined"">star</span>{nota.ToString("N1")}</p>
                                                    <p class=""descricao-perfil"">{empresa.Descricao}</p>
                                                </div>

                                                <div class=""btnEditar"">
                                                    <button class=""btn azul"">Editar</button>
                                                </div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos em andamento</h1>

                                      
                                            ";


                    eventos = lista.listarEventosAcontecendo(email, offset);
                    if (eventos != null)
                        if (eventos.Count > 0)
                        {
                            litPerfil.Text += "<div class='eventos'>";
                            foreach (Evento evento in eventos)
                            {
                                litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                        <article class='evento'>
                                                            <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                            <div class='content'>
                                                                <div class='titulo-ong'>
                                                                    <h2>{evento.Nome}</h2>
                                                                    <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                                </div>
                                                                <p class='evento_descricao'>{evento.Descricao}</p>
                                                                <div class='evento_localizacao'>
                                                                    <span class='material-symbols-outlined'>location_on</span>
                                                                    <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                                </div>
                                                            </div>
                                                            <div class='evento_data'>
                                                                <span class='material-symbols-outlined'>calendar_month</span>
                                                                <span class='data'>{evento.DataInicio.ToString("dd/MM")}</span>
                                                            </div>
                                                        </article>
                                                    </a>";
                            }
                        }
                        else
                        {
                            litPerfil.Text += $@"<p>Essa empresa não tem nenhum evento em andamento!</p>";
                        }
                    numeroPagina = lista.contarEventosAcontecendo(email);
                    if (numeroPagina > 1)
                        litPerfil.Text += $@"</div>
                                            <div class=""verMais"" id='Acontecendo {numeroPagina - 1}'>
                                                <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                            </div> 
                                            </article>
                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos encerrados</h1>

                                                <div class=""eventos"">";
                    else
                        litPerfil.Text += $@"</div>
                                        </article>
                                        <article class=""container-perfil"">
                                            <h1 class=""container_title"">Eventos encerrados</h1>";



                    eventos = lista.listarEventosEncerrados(email, offset);
                    if (eventos != null)
                        if (eventos.Count > 0)
                        {
                            litPerfil.Text += "<div class='eventos'>";
                            foreach (Evento evento in eventos)
                            {
                                nota = evento.calcularMediaAvaliacao(evento.Codigo);

                                litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                        <article class='evento'>
                                                            <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                            <div class='content'>
                                                                <div class='titulo-ong'>
                                                                    <h2>{evento.Nome}</h2>
                                                                    <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                                </div>
                                                                <p class='evento_descricao'>{evento.Descricao}</p>
                                                                <div class='evento_localizacao'>
                                                                    <span class='material-symbols-outlined'>location_on</span>
                                                                    <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                                </div>
                                                            </div>
                                                            <div class='evento_avaliacao'>
                                                                <span class='material-symbols-outlined'>star</span>
                                                                <span class='data'>{nota.ToString("N1")}</span>
                                                            </div>
                                                        </article>
                                                    </a>";
                            }
                        }
                        else
                        {
                            litPerfil.Text += $@"<p>Essa empresa não tem nenhum evento encerrado!</p>";
                        }

                    numeroPagina = lista.contarEventosEncerrado(email);
                    if (numeroPagina > 1)
                        litPerfil.Text += $@"</div>
                                            <div class=""verMais"" id='Encerrado {numeroPagina - 1}'>
                                                <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                            </div>
                                        </article>      
                                    </main>";
                    else
                        litPerfil.Text += $@"</div>                                     
                                        </article>      
                                    </main>";
                }
                else
                {
                    double nota = usuario.calcularMediaAvaliacao(email);
                    litPerfil.Text = $@"<main>

                                            <article class=""container-perfil"">
                                                <div class=""div-azul""><div class='crop-foto-perfil' id='fotoPerfil'><img src='{usuario.Foto}' alt='Foto de perfil do usuario {usuario.Nome}'></div></div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <div class=""divperfil-detalhes"">
                                                    <div class=""divimg-perfil""></div>
                                                    <p class=""nome-perfil"">{usuario.Nome}<span class=""material-symbols-outlined"">star</span>{nota.ToString("N1")}</p>
                                                    <p class=""descricao-perfil"">{usuario.Descricao}</p>
                                                </div>

                                                <div class=""btnEditar"">
                                                    <button class=""btn azul"">Editar</button>
                                                </div>
                                            </article>
                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos em que estou inscrito:</h1>";



                    eventos = lista.listarEventosInscrito(email, offset);
                    if (eventos.Count > 0)
                    {
                        litPerfil.Text += "<div class='eventos'>";
                        foreach (Evento evento in eventos)
                        {
                            litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                    <article class='evento'>
                                                        <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                        <div class='content'>
                                                            <div class='titulo-ong'>
                                                                <h2>{evento.Nome}</h2>
                                                                <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                            </div>
                                                            <p class='evento_descricao'>{evento.Descricao}</p>
                                                            <div class='evento_localizacao'>
                                                                <span class='material-symbols-outlined'>location_on</span>
                                                                <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                            </div>
                                                        </div>
                                                        <div class='evento_data'>
                                                            <span class='material-symbols-outlined'>calendar_month</span>
                                                            <span class='data'>{evento.DataInicio.ToString("dd/MM")}</span>
                                                        </div>
                                                    </article>
                                                </a>";
                        }
                    }
                    else
                    {
                        litPerfil.Text += $@"<p>Esse usuário não está inscrito(a) em nenhum evento no momento!</p>";
                    }
                    numeroPagina = lista.contarEventosInscrito(email);
                    if (numeroPagina > 1)
                    {
                        litPerfil.Text += $@"</div>
                                                <div class=""verMais"" id='Inscrito {numeroPagina - 1}'>
                                                    <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                                </div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos participados:</h1>
                                                <div class=""eventos"">";
                    }
                    else
                        litPerfil.Text += $@"</div>
                                            </article>

                                            <article class=""container-perfil"">
                                                <h1 class=""container_title"">Eventos participados:</h1>";


                    eventos = lista.listarEventosParticipado(email, offset);
                    if (eventos.Count > 0 || eventos == null)
                    {
                        litPerfil.Text += "<div class='eventos'>";
                        foreach (Evento evento in eventos)
                        {
                            nota = evento.calcularMediaAvaliacao(evento.Codigo);
                            litPerfil.Text += $@"<a href='evento.aspx?c={evento.Codigo}'>
                                                    <article class='evento'>
                                                        <img src='{evento.Imagem}' alt='' class='evento_capa'>
                                                        <div class='content'>
                                                            <div class='titulo-ong'>
                                                                <h2>{evento.Nome}</h2>
                                                                <h4 class='evento_autor cinzaEItalico'>por {evento.Empresa.Nome}</h4>
                                                            </div>
                                                            <p class='evento_descricao'>{evento.Descricao}</p>
                                                            <div class='evento_localizacao'>
                                                                <span class='material-symbols-outlined'>location_on</span>
                                                                <h5 class='cinzaEItalico'>{evento.Endereco}</h5>
                                                            </div>
                                                        </div>
                                                        <div class='evento_avaliacao'>
                                                            <span class='material-symbols-outlined'>star</span>
                                                            <span class='data'>{nota.ToString("N1")}</span>
                                                        </div>
                                                    </article>
                                                </a>";
                        }
                    }
                    else
                    {
                        litPerfil.Text += $@"<p>Esse usuário ainda não participou de nenhum evento!</p>";
                    }
                    numeroPagina = lista.contarEventosParticipado(email);
                    if (numeroPagina > 1)
                    {
                        litPerfil.Text += $@"</div>
                                                <div class=""verMais"" id='Participado {numeroPagina - 1}'>
                                                    <button class=""btn azul"" id='{offset}'>Ver mais</button>
                                                </div>
                                            </article>      
                                        </main>";
                    }
                    else
                        litPerfil.Text += $@"</div>                                         
                                            </article>      
                                        </main>";
                }

            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}