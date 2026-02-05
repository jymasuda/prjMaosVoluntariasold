<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="avaliacao.aspx.cs" Inherits="prjMaosVoluntarias.avaliacao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Avaliar Usuários | Mãos Voluntárias</title>
    <link rel="stylesheet" href="\css\style.css"/>
    <link rel="stylesheet" href="\css\popup.css"/>
    <link rel="stylesheet" href="\css\avaliacao.css"/>
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
        <div class="titulo">
            <h1 class="bold">Avaliar Participantes</h1>
            <asp:Literal ID="litTitulo" runat="server"></asp:Literal>
        </div>
        <article class="inscricoes">
            <section class="area-voluntarios">
                <asp:Literal ID="litAvaliacao" runat="server"></asp:Literal>
                <%--<div>
                        <button class="collapsible">
                            <div class="voluntario">
                                <div class="icon-usuario">
                                    <div class="crop-icon"><img src="/img/icon.png"></div>
                                    <h2>Ana Carolina Sena Camargo Masuda</h2>
                                </div>
                                <div class="avaliacao-usuario">
                                    <span class="nao-selecionavel estrela material-symbols-outlined">star</span>
                                    <input type="number" name="inputAvaliacao" id="inputAvaliacao" min="1" max="5" value="5">
                                </div>
                                <div class="vaga">
                                    <p>Costureiro(a)</p>
                                </div>
                            </div>
                         </button>
                         <div class="collapsible content">
                            <div class="area-comentario">
                                <div class="label">
                                    <label for="txtComentario">Comentário </label>
                                    <p>(Opcional)</p>
                                </div>
                                <div class="textbox">
                                    <textarea name="txtComentario" id="txtComentario" cols="30" rows="10" placeholder="Adicione um comentário sobre este voluntário"></textarea>
                                    <button class="btn header vazado" id="btnPronto">
                                        <span class="pronto nao-selecionavel material-symbols-outlined">done</span>
                                        Confirmar
                                    </button>
                                </div>
                            </div>                       
                         </div>   
                </div>--%>
            </section>
        </article>
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

        <script>
            const inputAvaliacao = document.querySelectorAll("#inputAvaliacao")
            for (let i = 0; i < inputAvaliacao.length; i++) 
            {
                inputAvaliacao[i].addEventListener("keyup", function()
                {
                let num = inputAvaliacao[i].value
                if(inputAvaliacao[i].value > 5 || inputAvaliacao[i].value < 1)
                    return

                inputAvaliacao[i].value = num
                });

                inputAvaliacao[i].addEventListener("mouseup", function()
                {
                let num = inputAvaliacao[i].value
                if(inputAvaliacao[i].value > 5 || inputAvaliacao[i].value < 1)
                    return

                inputAvaliacao[i].value = num
                });
            }
        </script>
        <script src="../js/loginCadastro.js"></script>
        <script src="../js/avaliacaoUsuario.js"></script>
        <script src="../js/collapsible.js"></script>


    </form>
</body>
</html>
