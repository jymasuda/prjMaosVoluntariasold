<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="prjMaosVoluntarias.cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Cadastro | Mãos Voluntárias</title>

    <link rel="stylesheet" href="\css\style.css"/>
    <link rel="stylesheet" href="\css\cadastro.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,1,0"/>
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
                    <button class="btn header vazado" id="btnCadastro">Cadastro</button>
                </div>

                <div class="contaUsuario escondido" id="logado">
                </div>
                <div class="popup-header escondido">
                </div>
        </section>
    </header>
    <%--Início da estrutura de cadastro para usuário Organização--%>
    <main class="cadastro">
        <div class="cadastro-info">
            <h1>Falta Pouco!</h1>
            <p>Apenas preencha suas informações e faça seu cadastro para se tornar parte do Mãos Voluntárias!</p>
            <br/>
            <p>Lembre-se de revisar as informações para não ocorrer nenhum engano, erros de digitação são bem comuns!</p>
            <div class="cadastro-logotipo">
                <p>Atenciosamente,</p>
                <img src="/img/logotipo.png" alt="Logotipo Mãos Voluntárias de coloração branca"/>
            </div>
        </div>

        <div class="form-cadastro">
            <asp:Literal ID="litFormCadastro" runat="server"></asp:Literal>
            
        </div>
     </main>

    <%--Fim da estrutura de cadastro para usuário Organização--%>
        <%--Início da estrutura de cadastro para usuário voluntariado--%>

<%--    <main class="cadastro">
        <div class="cadastro-info">
            <h1>Falta Pouco!</h1>
            <p>Apenas preencha suas informações e faça seu cadastro para se tornar parte do Mãos Voluntárias!</p>
            <br>
            <p>Lembre-se de revisar as informações para não ocorrer nenhum engano, erros de digitação são bem comuns!</p>
            <div class="cadastro-logotipo">
                <p>Atenciosamente,</p>
                <img src="/img/logotipo.png" alt="Logotipo Mãos Voluntárias">
            </div>
        </div>

        <div class="form-cadastro">

            <div class="cadastro-input">
                <label for="txtNome">Nome Completo:</label>
                <input type="text" name="txtNome" id="txtNome" placeholder="Digite o nome completo...">
            </div>

            <div class="cadastro-input">
                <label for="txtEmail">E-mail:</label>
                <input type="text" name="txtEmail" id="txtEmail" placeholder="Digite seu e-mail...">
            </div>

            <div class="cadastro-input">
                <label for="txtSenha">Senha:</label>
                <input type="password" name="txtSenha" id="txtSenha" placeholder="Digite sua senha...">
            </div>

            <div class="cadastro-input">
                <label for="txtSenhaConfirmar">Confirmar Senha:</label>
                <input type="password" name="txtSenhaConfirmar" id="txtSenhaConfirmar" placeholder="Confirme sua senha...">
            </div>

            <div class="cadastro-input">
                <label for="txtCNPJ">CPF:</label>
                <input type="text" name="txtCPF" id="txtCPF" placeholder="Digite seu CPF...">
            </div>

            <div class="cadastro-input">
                <label for="txtSite">RG: </label>
                <input type="text" name="txtRG" id="txtRG" placeholder="Digite seu RG...">    
            </div>
    
            <div class="cadastro-input">
                <label for="input-documento">Foto do Documento</label>
                <div class="input-documento">
                    <i class="material-symbols-outlined">photo_camera</i>
                    <label for="fileDocumento">Insira uma imagem...</label>
                    <input type="file" name="fileDocumento" id="fileDocumento" accept="image/png,image/jpeg,image/jpg ">
                </div>    
            </div>

            <div class="centro">
                <button class="btn azul" type="submit">Cadastre-se</button>
                <br>
                <a href="">Já possui uma conta? Entre!</a>
            </div>
      
        </div>
    </main>--%>

        <%--Fim da estrutura de cadastro para usuário voluntariado--%>
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
        <script src="../js/cadastro.js"></script>
        <script src="../js/mascaraEntrada.js"></script>
    </form>


</body>
</html>
