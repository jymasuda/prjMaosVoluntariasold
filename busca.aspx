<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="busca.aspx.cs" Inherits="prjMaosVoluntarias.busca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Busca | Mãos Voluntárias</title>
    <link rel="stylesheet" href="\css\style.css"/>
    <link rel="stylesheet" href="\css\busca.css"/>
    <link rel="stylesheet" href="\css\popup.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,1,0"/>
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <section class="container"> 
                <a href="index.aspx"><img src="../img/logotipo.png" alt="Logotipo Mãos Voluntárias de coloração branca" class="logotipo"/></a>
                <nav>
                    <a href="busca.aspx">Vagas</a>
                    <a href="servoluntario.aspx">O que é ser voluntário?</a>
                    <a href="sobrenos.aspx">Sobre Nós</a>
                </nav>

            <div class="buttons" id="deslogado">
                    <button class="btn header" id="btnLogin">Login</button>
                    <button class="btn header vazado" id="btnCadastro">Cadastro</button>
                </div>

                <div class="contaUsuario escondido" id="logado">
                </div>
                <div class="popup-header escondido">
                </div>
        </section>
    </header>

    <main>
        <article class="container">
            <%-- Textbox para pesquisa. --%>
            <%--No caso da busca ser realizada com Requisição Assíncrona:--%>
            <span class="spanBarraPesquisa">
                <input id="txtBusca" type="text" class="filtro-busca" placeholder="Pesquise por ONGs, vagas, cidade..."/>
                <span class="material-symbols-outlined btn-search" id="btnBarraPesquisa" >search</span>
            </span>
            <%--No caso da busca ser realizada em C# ASPX:--%>
            <%--<asp:TextBox ID="txtBusca" runat="server" cssClass="filtro-busca" placeholder="Pesquise por ONGs, vagas, cidade..."></asp:TextBox>--%> 
        </article>

        <article class="container">
            <%--Inicio da área de geração dinâmica de lista de checkboxes [CIDADE] --------------------------------------------------%>

            <div class="filtros">
                <button id="btnLocal" class="filtro local">Local</button>
                <div class="filtro local-aberto escondido">
                    <div class="checkboxes">
                        <asp:Literal ID="litChckCidades" runat="server"></asp:Literal>
                         
                       <%-- <div class="checkbox1"> 
                                <input class="box" type="checkbox" name="Bertioga" id="chckCidade01"/>
                                <label class="lblCheckbox" for="Bertioga">Bertioga</label>
                            </div>--%>

                    </div> 
                    <div class="buttonsPopUp">
                        <input class="btnLimpar"id="btnLimparCidade" type="button" value="Limpar"/>
                        <input class="btnAplicar" id="btnAplicarCidade" type="button" value="Aplicar"/>
                    </div>

                </div>
                <%-- Fim da área de geração dinâmica de lista de checkboxes [CIDADE] --------------------------------------------------%>

                <%--Inicio da área de geração dinâmica de lista de checkboxes [CATEGORIA] --------------------------------------------------%>
                <button id="btnCategoria" class="filtro categoria">Categorias</button>
                <div class="filtro categoria-aberto escondido">

                    <div class="checkboxes">

                        <asp:Literal ID="litChckCategorias" runat="server"></asp:Literal>


                    </div> 
                    <div class="buttonsPopUp">
                        <input class="btnLimpar" id="btnLimparCategoria" type="button" value="Limpar"/>
                        <input class="btnAplicar" id="btnAplicarCategoria" type="button" value="Aplicar"/>
                    </div>

                </div>
                    <%--Fim da área de geração dinâmica de lista de checkboxes [CATEGORIA] --------------------------------------------------%>

                <%--Inicio da área de geração dinâmica de lista de checkboxes [HABILIDADES] --------------------------------------------------%>
                <button id="btnHabilidade" class="filtro habilidades">Habilidades</button>
                <div class="filtro habilidades-aberto escondido">

                    <div class="checkboxes">

                        <asp:Literal ID="litChckHabilidades" runat="server"></asp:Literal>

                    </div> 
                    <div class="buttonsPopUp">
                        <input class="btnLimpar" id="btnLimparHabilidade" type="button" value="Limpar"/>
                        <input class="btnAplicar" id="btnAplicarHabilidade" type="button" value="Aplicar"/>
                    </div>

                </div>

            <%--Fim da área de geração dinâmica de lista de checkboxes [HABILIDADES] --------------------------------------------------%>
            </div>
        </article>
        
    <%--Inicio da área de dinâmica [Listagem de Eventos] ------------------------------------------------%>

        <article class="container">
           
            <%--<div class='filtros-selecionados'>
                <h1 class='txt-filtro-selecionado'>Filtros ativos:</h1>                 
                <div class='container-filtros-selecionados'>
                    <div class='filtro-selecionado'>
                        <p>Praia Grande</p><span class='material-symbols-outlined'>close</span>
                    </div>                     
                    <div class='filtro-selecionado''>                         
                        <p>Cubatão</p>                         
                        <span class='material-symbols-outlined'>close</span>
                    </div>                 
                </div>
            </div>--%>

                <asp:Literal ID="litEventos" runat="server"></asp:Literal>
                
             <%--   <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>

                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>

                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>

                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>

                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>

                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>

                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>

                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <h2>Título do evento</h2>
                        <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        <p class="evento_descricao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas
                            aut et quo, voluptates officiis, aspernatur tempora excepturi vero facilis maiores amet ut,
                            consequatur quam error voluptate ipsam omnis perspiciatis. Natus?</p>
                        <div class="evento_localizacao">
                            <span class="material-symbols-outlined">location_on</span>
                            <h5 class="cinzaEItalico">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Rerum
                            </h5>
                        </div>
                    </div>
                    <div class="evento_data">
                        <span class="material-symbols-outlined">calendar_month</span>
                        <span class="data">10/08</span>
                    </div>
                </article>--%>
            
        </article>
    </main>
            <%--Fim da área dinâmica listagem de eventos ---------------------------------------------------------------%>
        <footer>
        <div class="container">
            <img src="../img/logotipo.png" alt="Logotipo Mãos Voluntárias de coloração branca" class="logotipo"/>
            <section class="texto_footer">
                <div>
                    <a href="faleconosco.aspx">Fale conosco</a>
                    <a href="sobrenos.aspx">Sobre Nós</a>
                    <a href="servoluntario.aspx">O que é ser voluntário?</a>
                </div>
                <hr/>
                <p>Mãos Voluntárias - Todos os direitos reservados - 2023</p>
            </section>
        </div>
    </footer>
        <!-- PopUp Login -->
    <div class="tela-bloqueio escondido"></div>
    <div class="popup escondido" id="popup_login">
        <div class="logo-popup">
            <img src="/img/logotipo.png" alt="Logotipo Mãos Voluntárias">
            <hr noshade class="separador">
            <p>Faça seu login ou cadastro e torne-se uma mão voluntária.</p>
        </div>

        <div class="form-login">

            <div class="end">
                <span class="nao-selecionavel material-symbols-outlined" id="btnFecharLogin">close</span>
            </div>
            
            <div class="centro">
                <h1>Bem vindo</h1>
                <h2>Faça seu login</h2>
            </div>
            
            <div class="icons-input centro">
            <div>
                <i class="login-icon nao-selecionavel  material-symbols-outlined">mail</i>
                <input type="text" name="txtEmail" id="txtEmail" placeholder="E-mail">
            </div>
                
            <div>
                <i class="login-icon nao-selecionavel  material-symbols-outlined">lock</i>
                <input type="password" name="txtSenha" id="txtSenha" placeholder="Senha">
            </div>
            </div>
            <p class="txtMsg escondido" id="spanMsg">E-mail inválido</p>
            <a class="link-esqueceu-senha" href="">Esqueceu sua senha?</a>
            
            
            <div class="centro">
                <button class="btn azul" type="submit" id="btnLogar">Logar</button>
                <br>
                <a class="link-cadastro" href="">Não possui uma conta? Cadastre-se!</a>    
            </div>
        </div>
    </div>
        <!-- PopUp Cadastro -->
    <div class="popup escondido" id="popup_cadastro">
        <div class="logo-popup">
            <img src="/img/logotipo.png" alt="Logotipo Mãos Voluntárias">
            <hr noshade class="separador">
            <p>Faça seu login ou cadastro e torne-se uma mão voluntária.</p>
        </div>

        <div class="popup-cadastro centro">
            <div class="end">
                <span class="nao-selecionavel material-symbols-outlined" id="btnFecharCadastro">close</span>
            </div>
                <h1>Não possui login?</h1>
                <h2>Escolha seu tipo de cadastro</h2>
                <button class="btn azul" id="btnVoluntario">Voluntário</button>
                <br>
                <button class="btn azul" id="btnOrganizacao">Organização</button>
                <br>
                <br>
                <a class="link-login" href="">Já possuí uma conta? Faça seu login!</a>    
        </div>
    </div>
    <script src="..\JS\loginCadastro.js"></script>
    <script src="..\JS\momentjs.js"></script>
    <script src="..\JS\busca.js"></script>
    <script src="..\JS\verMaisBusca.js"></script>
    </form>
</body>
</html>
