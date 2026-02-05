<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faleconosco.aspx.cs" Inherits="prjMaosVoluntarias.faleconosco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Fale Conosco | Mãos Voluntárias</title>
    <link rel="stylesheet" href="\css\style.css"/>
    <link rel="stylesheet" href="\css\faleconosco.css"/>
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
    <main class="fale-conosco">
        <div class="fale-conosco-info">
            <h1>Fale Conosco</h1>
            <p>Bem-vindo ao nosso canal de contato! Ficamos felizes em saber que você está interessado em fazer a diferença. Sua vontade de ajudar é inspiradora e estamos aqui para apoiá-lo em sua jornada. Se você tiver alguma dúvida, sugestão, feedback ou apenas quiser compartilhar sua história conosco, sinta-se à vontade para entrar em contato. Nossa equipe está sempre pronta para responder às suas perguntas e fornecer o suporte necessário para garantir que sua experiência em nossa plataforma seja enriquecedora e gratificante.</p>
            <div class="fale-conosco-logotipo">
                <p>Venha fazer parte do Mãos Voluntárias, voluntarie-se você também!</p>
                <img src="/img/logotipo.png" alt="Logotipo Mãos Voluntárias de coloração branca."/>
            </div>
        </div>
    
        <div class="form-fale-conosco">
            <h1>Contato</h1>
            <div class="fale-conosco-input">
                <label for="txtNome">Nome:</label>
                <input type="text" name="txtNome" id="txtNome" placeholder="Digite seu nome..."/>
            </div>
    
            <div class="fale-conosco-input">
                <label for="txtEmail">E-mail:</label>
                <input type="text" name="txtEmail" id="txtEmail" placeholder="Digite seu e-mail..."/>
            </div>
    
            <div class="fale-conosco-input">
                <label for="txtTelefone">Telefone:</label>
            <input type="text" name="txtTelefone" id="txtTelefone" placeholder="(99) 99999-9999"/>  
            </div>
    
            <div class="fale-conosco-input">
                <label for="txtMensagem">Mensagem:</label>
                <br/>
                <textarea name="txtMensagem" id="txtMensagem" cols="50" rows="8" placeholder="Digite sua mensagem"></textarea>
            </div>
    
            <div class="centro">
                <button class="btn azul" type="submit" id="btnEnviar">Enviar</button>
            </div>
        </div>
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
        <script src="..\JS\loginCadastro.js"></script>
    </form>
</body>
</html>
