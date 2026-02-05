<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="prjMaosVoluntarias.perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Home | Mãos Voluntárias</title>
    <link rel="stylesheet" href="\css\style.css"/>

    <link rel="stylesheet" href="\css\popup.css"/>
    <link rel="stylesheet" href="\css\perfil.css"/>
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

        <asp:Literal ID="litPerfil" runat="server"></asp:Literal>

             <%--Perfil da ong--%>

<%--                 
    <main>
        <article class="container-perfil">
            <div class="div-azul"><img src="../img/iconeperfil128px.png" alt=""></div>
            <div class="div-contato">  <p class="p-contatos"><span class="material-symbols-outlined">link</span> www.ongincrivel.com</p>    <p class="p-contatos"><span class="material-symbols-outlined">call</span> 13 99999-9999</p></div>
        </article>

        <article class="container-perfil

            <div class="divperfil-detalhes">
                <div class="divimg-perfil"></div>
                <p class="nome-perfil">Nome do Perfil <span class="material-symbols-outlined">star</span> 5.0</p>
                <p>Mussum Ipsum, cacilds vidis litro abertis. Posuere libero varius. Nullam a nisl ut ante blandit hendrerit. Aenean sit amet nisi. Copo furadis é disculpa de bebadis, arcu quam euismod magna. Nec orci ornare consequat. Praesent lacinia ultrices consectetur. Aenean sit amet nisi. Copo furadis é disculpa de bebadis, arcu quam euismod magna. Nec orci ornare consequat. Praesent lacinia ultrices consectetur. </p>
            </div>

            <div class="verMais">
                <button class="btn azul btnmargin">Sair</button>
                <button class="btn azul">Editar</button>
            </div>

        </article>



        <article class="container-perfil">
            <h1 class="container_title">Eventos em andamento</h1>

        <div class="eventos">
            <a href="">
                <article class="evento">
                    <img src="" alt="" class="evento_capa">
                    <div class="content">
                        <div class="titulo-ong">
                            <h2 >Título do evento</h2>
                            <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                        </div>
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
            </a>
      

        </div>
        <div class="verMais">
            <button class="btn azul">Ver mais</button>
        </div> 
        </article>
        <article class="container-perfil">
            <h1 class="container_title">Eventos encerrados</h1>

            <div class="eventos">
                <a href="">
                    <article class="evento">
                        <img src="" alt="" class="evento_capa">
                        <div class="content">
                            <div class="titulo-ong">
                                <h2 >Título do evento</h2>
                                <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                            </div>
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
                </a>
                <a href="">
                    <article class="evento">
                        <img src="" alt="" class="evento_capa">
                        <div class="content">
                            <div class="titulo-ong">
                                <h2 >Título do evento</h2>
                                <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                            </div>
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
                </a>
                <a href="">
                    <article class="evento">
                        <img src="" alt="" class="evento_capa">
                        <div class="content">
                            <div class="titulo-ong">
                                <h2 >Título do evento</h2>
                                <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                            </div>
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
                </a>
                <a href="">
                    <article class="evento">
                        <img src="" alt="" class="evento_capa">
                        <div class="content">
                            <div class="titulo-ong">
                                <h2 >Título do evento</h2>
                                <h4 class="evento_autor cinzaEItalico">por Institudo tdk Sócio Ambiental e Cultural</h4>
                            </div>
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
                </a>
                         
            </div>




        <div class="verMais">
            <button class="btn azul">Ver mais</button>
        </div>
        </article>
        
    </main>--%>

             <%--Perfil voluntario--%>

         

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
        <script src="..\JS\loginCadastro.js"></script><footer>
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
        <script src="..\JS\verMaisPerfil.js"></script>
        <script src="..\JS\editarPerfil.js"></script>
    </form>
</body>
</html>
