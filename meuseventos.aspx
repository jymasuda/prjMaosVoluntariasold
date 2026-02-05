<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meuseventos.aspx.cs" Inherits="prjMaosVoluntarias.meuseventos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Eventos | Mãos Voluntárias</title>
    <link rel="stylesheet" href="\css\style.css"/>
    <link rel="stylesheet" href="\css\meusEventos.css"/>
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

        <asp:Literal ID="litEventos" runat="server"></asp:Literal>

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
    </form>
</body>
</html>
