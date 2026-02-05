using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI;
using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace prjMaosVoluntarias
{
    public partial class busca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Cidade> cidades = new List<Cidade>();
            List<CategoriaEvento> categorias = new List<CategoriaEvento>();
            List<CategoriaFuncao> habilidades = new List<CategoriaFuncao>();

            #region recebendo valores da busca via requests
            if (Request["c"] != null && Request["c"] != "")
            {

                string[] codigosCidade = Request["c"].Split(',');

                foreach (string c in codigosCidade)
                {
                    Cidade cidade = new Cidade();
                    cidade.Codigo = int.Parse(c);
                    cidades.Add(cidade);
                }

            }

            if (Request["ca"] != null && Request["ca"] != "")
            {
                string[] codigosCategoria = Request["ca"].Split(',');

                foreach (string c in codigosCategoria)
                {
                    CategoriaEvento categoria = new CategoriaEvento();
                    categoria.Codigo = int.Parse(c);
                    categorias.Add(categoria);
                }
            }

            if (Request["h"] != null && Request["h"] != "")
            {
                string[] codigosHabilidade = Request["h"].Split(',');

                foreach (string c in codigosHabilidade)
                {
                    CategoriaFuncao habilidade = new CategoriaFuncao();
                    habilidade.Codigo = int.Parse(c);
                    habilidades.Add(habilidade);
                }
            }
            #endregion

            if (!IsPostBack)
            {
                Cidade cidade = new Cidade();
                CategoriaEvento categoria = new CategoriaEvento();
                CategoriaFuncao habilidade = new CategoriaFuncao();

                List<Cidade> ci = new List<Cidade>(cidade.Listar());
                foreach (Cidade c in ci)
                {
                    litChckCidades.Text += $@"<div class='checkbox1'> 
                                                 <input class='box' type='checkbox' name='{c.Nome}' value='{c.Codigo}' id='chckCidade'";

                    for (int i = 0; i < cidades.Count; i++)
                    {
                        if(cidades[i].Codigo == c.Codigo)
                        {
                            litChckCidades.Text += "checked";
                        }
                    }

                    litChckCidades.Text += $@"/>
                        <label class='lblCheckbox' for='chckCidade{c.Codigo}'>{c.Nome}</label>
                        </div>";

                }

                List<CategoriaEvento> ca = new List<CategoriaEvento>(categoria.Listar());
                foreach (CategoriaEvento c in ca)
                {
                    litChckCategorias.Text += $@"<div class='checkbox1'> 
                                                 <input class='box' type='checkbox' name='{c.Nome}' value='{c.Codigo}' id='chckCategoria'";

                    for (int i = 0; i < categorias.Count; i++)
                    {
                        if(categorias[i].Codigo == c.Codigo)
                        {
                            litChckCategorias.Text += "checked";
                        }
                    }
                    litChckCategorias.Text += $@"/>
                                            <label class='lblCheckbox' for='chckCategoria{c.Codigo}'>{c.Nome}</label>
                                            </div>";
                }

                List<CategoriaFuncao> ha = new List<CategoriaFuncao>(habilidade.Listar());
                foreach (CategoriaFuncao h in ha)
                {
                    litChckHabilidades.Text += $@"<div class='checkbox1'> 
                                                 <input class='box' type='checkbox' name='{h.Nome}' value='{h.Codigo}' id='chckHabilidade'";

                    for (int i = 0; i < habilidades.Count; i++)
                    {
                        if(habilidades[i].Codigo == h.Codigo)
                        {
                            litChckHabilidades.Text += "checked";
                        }
                    }
                    litChckHabilidades.Text += $@"/>
                                            <label class='lblCheckbox' for='chckHabilidades{h.Codigo}'>{h.Nome}</label>
                                            </div>";
                }

            }

            Evento evento = new Evento();

            string busca = null;
           
            

            int pagina = 1;
            if (Request["p"] != null)
                pagina = int.Parse(Request["p"]);

            if(cidades.Count != 0 | habilidades.Count != 0 | categorias.Count != 0)
                litEventos.Text = $@"<div class='filtros-selecionados'>
                        <h1 class='txt-filtro-selecionado'>Filtros ativos:</h1>                 
                        <div class='container-filtros-selecionados'>";

            foreach (Cidade c in cidades)
            {
                Cidade cidade = c.listarNomes(c.Codigo);
                litEventos.Text += $@"<div class='filtro-selecionado cidadeAtivo'>
                                <p>{cidade.Nome}</p><span class='material-symbols-outlined' id='{cidade.Codigo}'>close</span>
                            </div>";
            }

            foreach (CategoriaEvento c in categorias)
            {
                CategoriaEvento categoria = c.listarNomes(c.Codigo);
                litEventos.Text += $@"<div class='filtro-selecionado categoriaAtivo'>
                                <p>{categoria.Nome}</p><span class='material-symbols-outlined' id='{categoria.Codigo}'>close</span>
                            </div>";
            }

            foreach (CategoriaFuncao h in habilidades)
            {
                CategoriaFuncao habilidade = h.listarNomes(h.Codigo);
                litEventos.Text += $@"<div class='filtro-selecionado habilidadeAtivo'>
                                <p>{habilidade.Nome}</p><span class='material-symbols-outlined' id='{habilidade.Codigo}'>close</span>
                            </div>";
            }

            litEventos.Text += $@" </div>
                </div>";

            List<Evento> eventos = new List<Evento>(evento.Buscar(busca, cidades, categorias, habilidades, pagina));
            if (eventos.Count == 0)
            {
                litEventos.Text += $@"<h1 class=""buscaTexto centro"">Nenhum evento ou vaga nesses critérios encontrado(a)!</h1>
                                    <h2 class=""buscaTexto centro"">Tente realizar sua busca novamente, com outros filtros</h2>";
                return;
            }

            

              
    
            litEventos.Text += "<div class='eventos'>";
            foreach(Evento ev in eventos.Take(8))
            {
                litEventos.Text += $@"<a href='evento.aspx?c={ev.Codigo}'>
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
            litEventos.Text += "</div>";
            int numeroPaginas = evento.buscarPagMaxima(busca, cidades, categorias, habilidades);
            if(numeroPaginas > 1)
            {
                litEventos.Text += $@" <div class=""verMais"" id='{numeroPaginas - 1}'>
                                                <button class=""btn azul"" id='{pagina}'>Ver mais</button>
                                            </div>";
                //litEventos.Text += $@"  <div class=""nav-pag"">
                //                            <div id=""iconeNavegacaoRecuar""><span class=""material-symbols-outlined"">arrow_back_ios</span></div>
                //                            <div>1</div>
                //                            <div>2</div>
                //                            <div>3</div>
                //                            ";
                //if (numeroPaginas >= 4)
                //    litEventos.Text += $@"<div id=""navegacao"">...</div>
                //                        <div id=""navegacaoFinal"">{numeroPaginas}</div>";
                //if (pagina != numeroPaginas)
                //    litEventos.Text += $@"<div id=""iconeNavegacaoAvancar""><span class=""material-symbols-outlined"">arrow_forward_ios</span></div>
                //                            </div>
                //                        ";
            }


        }
    }
}