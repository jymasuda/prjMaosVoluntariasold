<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="evento.aspx.cs" Inherits="prjMaosVoluntarias.evento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Evento | Mãos Voluntárias</title>
    <link rel="stylesheet" href="\css\style.css"/>
    <link rel="stylesheet" href="\css\evento.css"/>
    <link rel="stylesheet" href="\css\popup.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,1,0"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0/dist/carousel/carousel.css"/>
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

        <asp:Literal ID="litEvento" runat="server"></asp:Literal>
        <%--Início da área dinâmica visualização do evento - Como usuário voluntariado--%>
        <%--<main>--%>
        <%--<article>
            <div class="titulo-evento">
                <h1>Multirão de limpeza na praia de santos</h1>
            </div>
            <div class="informacoes-evento">
                <div class="informacao data-hora">
                    <span class="nao-selecionavel material-symbols-outlined">schedule</span>
                    <div class="cinza-italico">
                        <div class="input-datetime"><p>Data de início: 02/04/2006 às 12:00 </p></div>
                        <div class="input-datetime"><p>Data de fim: 09/04/2006 às 12:00</p></div>
                    </div>
                </div>
        
                <div class="informacao endereco">
                    <span class="nao-selecionavel material-symbols-outlined">location_on</span>
                    <div>
                        <p class="cinza-italico">Endereço: Rua Conselheiro Nébias Número: 981 Apartamento: 106</p>
                    </div>
                </div>
                <div class="informacao categoria">
                    <div>
                        <span class="nao-selecionavel material-symbols-outlined icone">landslide</span>
                    </div>
                    <p class="cinza-italico">Ações Emergenciais</p>
                </div>
                <div class="informacao nome-ong">
                    <img src="../img/banner.jpeg" alt="">
                    <p class="cinza-italico">Instituto Sócio Ambiental e Cultural</p>
                </div>
            </div>  
        </article>
        
        <article class="sobre-evento">
            <div class="texto-evento">
                <div class="sobre-editar">
                    <h1>Sobre o evento</h1>
                    <span class="span-editar sobre escondido">
                        <span class="nao-selecionavel material-symbols-outlined icon-editar">edit</span>
                        <span class="btn-editar"><input type="button" value="Editar" id="btnEditar"></span> 
                    </span>
                </div>
                
                <p>Mussum Ipsum, cacilds vidis litro abertis. Paisis, filhis, espiritis santis.Viva Forevis aptent taciti sociosqu ad litora torquent.Manduma pindureta quium dia nois paga.A ordem dos tratores não altera o pão duris.

                    Nullam volutpat risus nec leo commodo, ut interdum diam laoreet. Sed non consequat odio.Interagi no mé, cursus quis, vehicula ac nisi.Suco de cevadiss deixa as pessoas mais interessantis.Praesent malesuada urna nisi, quis volutpat erat hendrerit non. Nam vulputate dapibus.</p>
            </div>
            <div class="img-evento">
                <img  src="../img/teste1.jpg" alt="">
            </div>
        </article>

        <article>
            <div class="titulo-vaga">
                <div class="titulo-vaga-texto">
                    <h1>Vagas disponíveis:</h1>
                    <p>Inscrições disponíveis até: 05/10/2023 às 23:00</p>
                </div>

                <span class="span-editar editar-vaga escondido">
                    <span class="nao-selecionavel material-symbols-outlined icon-editar">edit</span>
                    <span class="btn-editar"><input type="button" value="Editar" id="btnEditar"/</span> 
                </span>
            </div>
            
            
            <div class="vaga">
                <div class="vagas">
                    <div class="selecionado" >
                        <p>Costureiro</p>
                    </div>
                    <div>
                        <p>Decorador</p>
                    </div>
                </div>
    
                <div class="descricao">
                    <p class="descricao-data">24/06 10:00 até 12:00 </p>
                    <p class="descricao-info">Realizar serviços diversos de costura, utilizando máquinas e materiais apropriados.Realizar serviços diversos de costura, utilizando máquinas e materiais apropriados.</p>
                    <p class="descricao-aviso">Lembre-se, ao se inscrever em uma vaga, você assume que irá comparecer na data e hora comprometidos.</p>
                </div>
                <div class="botao">
                    <div>
                        <p>5 vagas restantes</p>
                        <input class="btn azul" type="button" value="Quero me inscrever" id="btnInscrever"/>
                    </div>
                </div>
            </div>
        </article>--%>

       <%-- <article class="galeria">
            <div class="texto-galeria"><h1>Galeria</h1></div>
            <div class="imagens-galeria">
                <div class="imagem-galeria crop"><img src="../img/teste2.jpg" alt=""/></div>
                <div class="imagem-galeria "><img src="../img/teste2.jpg" alt=""/></div>
                <div class="imagem-galeria "><img src="../img/teste2.jpg" alt=""/></div>
                <div class="imagem-galeria "><img src="../img/teste2.jpg" alt=""/></div>
            </div>
        </article>--%>
    <%--</main>--%>
         <%--Fim da área dinâmica visualização do evento - Como usuário voluntariado--%>

        <%--Início da área dinâmica visualização do evento - Como dono do evento, edição--%>
<%--<main>
        <article>
            <div class="titulo-evento text-box">
                <input type="text" name="txtTitulo" placeholder="Título do evento." value="Multirão de limpeza na praia de santos" id="txtTitulo">
            </div>
            <div>

            </div>
            <div class="informacoes-evento">
                <div class="informacao data-hora-textbox" id="text-box-data-hora">

                    <div class="cinza-italico ">
                        <div>
                            <p>Data de início:</p>
                            <div class="input-datetime" >
                                <input type="datetime-local" name="dtInicio" id="dtInicio">
                            </div>
                        </div>
                        <div>
                            <p>Data de fim:</p>
                            <div class="input-datetime">
                                <input type="datetime-local" name="dtFim" id="dtFfim">
                            </div>
                        </div>
                    </div>
                </div>
        
                <div class="informacao endereco-textbox" id="text-box-endereco">
                    <!-- <span class="nao-selecionavel material-symbols-outlined">location_on</span> -->
                    <div>
                        <p class="cinza-italico">Endereço: </p>
                        <input type="text" name="txtEndereco" id="txtEndereco">
                    </div>
                </div>
                <div class="informacao categoria-textbox">
                    <div>
                        <p class="cinza-italico">Categoria: </p>
                        <select name="ddlCategoria" id="ddlCategoria">
                            <option value="01">Ações emergenciais</option>
                            <option value="02">Ações emergenciais</option>
                            <option value="03">Ações emergenciais</option>
                        </select>
                    </div>
                </div>
                <!-- <div class="informacao nome-ong">
                    <img src="../img/banner.jpeg" alt="">
                    <p class="cinza-italico">Instituto Sócio Ambiental e Cultural</p>
                </div> -->
            </div>  
        </article>
        
        <article class="sobre-evento">
            <div class="texto-evento text-box">
                <div class="sobre-editar">
                    <h1>Sobre o evento</h1>
                    <span class="span-editar sobre escondido">
                        <span class="nao-selecionavel material-symbols-outlined icon-editar">edit</span>
                        <span class="btn-editar"><input type="button" id="btnEditar" value="Editar"></span> 
                    </span>
                </div>
                <textarea name="txtDescricaoEvento" id="txtDescricaoEvento" class="scrollbar" >Mussum Ipsum, cacilds vidis litro abertis. Paisis, filhis, espiritis santis.Viva Forevis aptent taciti sociosqu ad litora torquent.Manduma pindureta quium dia nois paga.A ordem dos tratores não altera o pão duris.
                    Nullam volutpat risus nec leo commodo, ut interdum diam laoreet. Sed non consequat odio.Interagi no mé, cursus quis, vehicula ac nisi.Suco de cevadiss deixa as pessoas mais interessantis.Praesent malesuada urna nisi, quis volutpat erat hendrerit non. Nam vulputate dapibus.</textarea>
            </div>
            <div class="img-evento">
                <img  src="../img/teste1.jpg" alt="">
            </div>
        </article>

        <article>
            <div class="titulo-vaga">
                <div class="titulo-vaga-texto">
                    <h1>Vagas disponíveis:</h1>
                    <p>Inscrições disponíveis até: 05/10/2023 às 23:00</p>
                </div>

                <span class="span-editar editar-vaga escondido">
                    <span class="nao-selecionavel material-symbols-outlined icon-editar">edit</span>
                    <span class="btn-editar"><input type="button" id="btnEditar" value="Editar"></span> 
                </span>
            </div>
            
            
            <div class="vaga">
                <div class="vagas text-box scrollbar">
                    <div class="adicionar-vaga">
                        <span id="adicionar-vaga-icon" class="nao-selecionavel material-symbols-outlined">add</span>
                        <span>Adic. Vaga</span>
                    </div>
                    <div class="selecionado" >
                        <p>Costureiro</p>
                        <span class="material-symbols-outlined" id="deletar">delete</span>
                    </div>
                    <div>
                        <p>Decorador</p>             
                        <span class="material-symbols-outlined" id="deletar">delete</span>
                    </div>
                    <div>
                        <p>Decorador</p>             
                        <span class="material-symbols-outlined" id="deletar">delete</span>
                    </div>
                    <div>
                        <p>Decorador</p>             
                        <span class="material-symbols-outlined" id="deletar">delete</span>
                    </div>
                    <div><input type="text" name="txtNomeVaga" placeholder="Nome da vaga" id="txtNomeDaVaga"></div>
                </div>
    
                <div class="descricao text-box text-vaga">
                    <input type="date" name="" id="txtDataVaga">
                    <input type="time" name="" id="txtHoraVaga">
                    <select name="" id="ddlCategoriaVaga">
                        <option value="">Selecione</option>
                        <option value="">Costura</option>
                        <option value="">Culinaria</option>
                    </select>
                    <!-- <input type="text" name="" id="txtDescricaoVaga" value="Realizar serviços diversos de costura, utilizando máquinas e materiais apropriados.Realizar serviços diversos de costura, utilizando máquinas e materiais apropriados." > -->
                    <textarea name="" id="txtDescricaoVaga" class="scrollbar" cols="30" rows="10">Realizar serviços diversos de costura, utilizando máquinas e materiais apropriados.Realizar serviços diversos de costura, utilizando máquinas e materiais apropriados.</textarea>
                </div>
                
                <div class="botao">
                    <div>
                        <input type="number" name="txtQtVagas" id="txtQtVagas">
                        <input class="btn azul" type="button" id="btnInscricoes" value="Inscrições">
                    </div>
                </div>
            </div>
        </article>

        <article class="galeria">
            <div class="texto-galeria">
                <h1>Galeria</h1>
                <span class="adicionar-imagem">
                    <span class="nao-selecionavel material-symbols-outlined">add</span>
                    <p>Adic. Imagem</p>
                </span>
            </div>
            <div class="imagens-galeria">
                <div class="imagem-galeria crop"><img src="../img/teste2.jpg" alt=""></div>
                <div class="imagem-galeria "><img src="../img/teste2.jpg" alt=""></div>
                <div class="imagem-galeria "><img src="../img/teste2.jpg" alt=""></div>
                <div class="imagem-galeria "><img src="../img/teste2.jpg" alt=""></div>
            </div>
        </article>
    </main>--%>
        <%--Fim da área dinâmica visualiação do evento - Como dono do evento, edição--%>

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
        <!-- PopUp Deletar Evento -->
        <div class="popup escondido" id="popupDeletarEvento">
        <div class="logo-popup">
            <img src="../img/logotipo.png" alt="Logotipo Mãos Voluntárias">
            <hr noshade class="separador">
            <p>Deletar evento</p>
        </div>

        <div class="deletar-evento">

            <div class="end">
                <span class="material-symbols-outlined">close</span>
            </div>
    
            <div class="txt-deletar">
                <div class="centro">
                    <h1>Atenção!</h1>
                </div>
                

                <h2>Você realmente deseja excluir esse evento? 
                    Ao confirmar a deleção, essa ação não poderá ser retrocedida. O evento será deletado e todas as informações, vagas e inscrições relacionadas a ela também serão deletadas.</h2>

                
                <div class="centro">
                    <button class="btn vazado azul" type="submit" id="btnCancelar">Cancelar</button>
                    <button class="btn azul" type="submit" id="btnDeletarEvento">Deletar</button>
                    <br>
                </div>
            </div>
        </div>
    </div>
                <!-- PopUp Deletar Vaga -->
        <div class="popup escondido" id="popupDeletarVaga">
        <div class="logo-popup">
            <img src="../img/logotipo.png" alt="Logotipo Mãos Voluntárias">
            <hr noshade class="separador">
            <p>Deletar vaga</p>
        </div>

        <div class="deletar-evento">

            <div class="end">
                <span class="material-symbols-outlined">close</span>
            </div>
    
            <div class="txt-deletar">
                <div class="centro">
                    <h1>Atenção!</h1>
                </div>
                

                <h2>Você realmente deseja excluir essa vaga? 
                    Ao confirmar a deleção, essa ação não poderá ser retrocedida. Todas inscrições e informações da vaga serão deletadas.</h2>

                
                <div class="centro">
                    <button class="btn vazado azul" type="submit" id="btnCancelar">Cancelar</button>
                    <button class="btn azul" type="submit" id="btnDeletarVaga">Deletar</button>
                    <br>
                </div>
            </div>
        </div>
    </div>
        <!-- PopUp Deletar Imagem -->
        <div class="popup escondido" id="popupDeletarImagem">
        <div class="logo-popup">
            <img src="../img/logotipo.png" alt="Logotipo Mãos Voluntárias">
            <hr noshade class="separador">
            <p>Deletar Imagem</p>
        </div>

        <div class="deletar-evento">

            <div class="end">
                <span class="material-symbols-outlined">close</span>
            </div>
    
            <div class="txt-deletar">
                <div class="centro">
                    <h1>Atenção!</h1>
                </div>
                

                <h2>Você realmente deseja excluir essa imagem? 
                    Ao confirmar a deleção, essa ação não poderá ser retrocedida.</h2>

                
                <div class="centro">
                    <button class="btn vazado azul" type="submit" id="btnCancelar">Cancelar</button>
                    <button class="btn azul" type="submit" id="btnDeletarImagem">Deletar</button>
                    <br>
                </div>
            </div>
        </div>
    </div>
        <script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0/dist/carousel/carousel.umd.js"></script>
        <script src="..\JS\carrosselGaleria.js"></script>
        <script src="..\JS\loginCadastro.js"></script>
        <script src="..\JS\icones.js"></script>
        <script src="..\JS\toast.js"></script>
        <script src="..\JS\editarEvento.js"></script>
        <script src="..\JS\inscricaoEvento.js"></script>
        <script src="..\JS\listaVaga.js"></script>
        <script src="..\JS\adicaoVaga.js"></script>
        <script src="..\JS\deletarVaga.js"></script>
        <script src="..\JS\deletarEvento.js"></script>
        
    </form>
</body>
</html>
