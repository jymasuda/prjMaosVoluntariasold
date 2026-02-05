<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prjMaosVoluntarias.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Home | Mãos Voluntárias</title>
    <link rel="stylesheet" href="\css\style.css"/>
    <link rel="stylesheet" href="\css\index.css"/>
    <link rel="stylesheet" href="\css\popup.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,1,0"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0/dist/carousel/carousel.css"/>
    <link rel="stylesheet"href="https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0/dist/carousel/carousel.autoplay.css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <section class="container"> 
                <a href="index.aspx"><img src="../img/logotipo.png" alt="Logotipo Mãos Voluntárias de coloração branca" class="logotipo"/></a>
                <nav>
                    <a href="busca.aspx">Vagas</a>
                    <a class="some" href="servoluntario.aspx">O que é ser voluntário?</a>
                    <a class="some" href="sobrenos.aspx">Sobre Nós</a>
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
        <article id="banner">
            <div class="f-carousel imagens-galeria" id="carosselHeader">
                <div class="f-carousel__viewport">
                    <div class="f-carousel__track">
                        <div class="f-carousel__slide imagem-galeria">
                                <img src="../img/banner-img-3.png" alt="imagem banner">
                                <div class="titulo-banner">
                                    <h1>Se torne um voluntário!</h1>
                                    <p>Com o amor que você sente, é possível mudar vidas. <br> Acesse abaixo! </p>
                                </div>
                            <button class="btn azul" id="btnVagas">Vagas</button>
                        </div>
                        <div class="f-carousel__slide imagem-galeria">
                            <img src="../img/banner-img-2.png" alt="imagem banner">
                                <div class="titulo-banner">
                                    <h1>Anuncie seu Evento!</h1>
                                    <p>Vamos nos ajudar com foco em humildade e empatia.</p>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </article>

        <article class="container">
            <asp:Literal ID="litIndex" runat="server"></asp:Literal>

           
            <%-- Início área dinâmica [Listagem de eventos] -------------------------------------------------------- --%>
<%--                <article class="evento">
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

        
        <asp:Literal ID="litCarrossel" runat="server"></asp:Literal>

            
        
        <%--Fim área dinâmica [Listagem de eventos]--%>

    </main>


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
        <script src="..\JS\icones.js"></script>
        <script src="..\JS\loginCadastro.js"></script>
        <script src="..\JS\toast.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0/dist/carousel/carousel.umd.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0/dist/carousel/carousel.autoplay.umd.js" ></script>
        <script type="module" src="..\JS\carrosselIndex.js"></script>
    </form>
</body>
</html>
