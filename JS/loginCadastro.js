const body = document.querySelector('body');

const form = document.getElementById("form1");
form.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        e.preventDefault();
    }
})

// Variaveis PopupLogin
const btnLoginHeader = document.querySelector("#btnLogin");
const telaBloqueio = document.querySelector(".tela-bloqueio");
const popupLogin = document.querySelector("#popup_login");
const btnFecharLogin = document.querySelector("#btnFecharLogin");

/*Variaveis Login*/
const txtEmail = document.querySelector("#txtEmail");
const txtSenha = document.querySelector("#txtSenha");
const btnLogar = document.querySelector("#btnLogar");
const spanMsg = document.querySelector("#spanMsg");

const deslogado = document.querySelector("#deslogado");
const logado = document.querySelector("#logado");
//const logadoUsuario = document.querySelector("#logado-usuario");
//const logadoEmpresa = document.querySelector("#logado-empresa");

let btnDeslogar = null;
let popupHeader = "";

// Variaveis popup cadastrso
const btnCadastro = document.querySelector("#btnCadastro");
const popupCadastro = document.querySelector("#popup_cadastro");
const btnFecharCadastro = document.querySelector("#btnFecharCadastro");

const btnOrganizacao = document.querySelector("#btnOrganizacao");
const btnVoluntario = document.querySelector("#btnVoluntario");
const linkLogin = document.querySelector(".link-login");
const linkCadastro = document.querySelector(".link-cadastro");

// Popup Login
if (btnLoginHeader && btnFecharLogin) {
    btnLoginHeader.addEventListener("click", abrirPopup);
    btnFecharLogin.addEventListener("click", fecharPopup);

    function abrirPopup(e) {
        e.preventDefault();
        if (telaBloqueio.classList.contains("escondido")) {
            telaBloqueio.classList.remove("escondido");
            popupLogin.classList.remove("escondido");
            body.classList.add('removeScroll');
        }
    }

    function fecharPopup(e) {
        e.preventDefault();
        if (!telaBloqueio.classList.contains("escondido")) {
            telaBloqueio.classList.add("escondido");
            popupLogin.classList.add("escondido");
            body.classList.remove('removeScroll');
            txtEmail.value = "";
            txtSenha.value = "";
        }
    }
}

/*Verificar o tipo do login, se é usuario/empresa */
function verificarTipoLogin() {

    fetch(`Libs/verificalogin.aspx`).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {

        if (dados["situacao"] == 'usuario') {
            popupHeader = document.querySelector(".popup-header");

            let nome = dados["nome"].charAt(0).toUpperCase() + dados["nome"].slice(1);
            const primeiroNome = nome.split(" ");

            logado.innerHTML = `<div class='nao-selecionavel' href='' id='abrir-popup-header'>
                                   <p class="nome-usuario">`+ primeiroNome[0] + `</p>
                                <span class="txt-conta" href="">
                                    <div class='crop-foto-perfil-header' id='fotoPerfil-header'><img src="${dados["foto"]}" alt=""></div>
                                    <span class="material-symbols-outlined">expand_more</span>
                                </span> 
                                </div>`;
            popupHeader.innerHTML = `<div class='perfil-popup'><span class='material-symbols-outlined' > account_circle</span> <a href='perfil.aspx'><p class='texto-popup'>Meu perfil</p></a> </div>
                                    <div class='perfil-popup'><span class='material-symbols-outlined' > group</span> <a href='minhasinscricoes.aspx'><p class='texto-popup'>Minhas inscrições</p></a> </div>
                                    <div class='perfil-popup'><span class='material-symbols-outlined' > star</span> <a href='avaliacaoEmpresa.aspx'><p class='texto-popup'>Avaliações</p></a> </div>
                                    <div class='perfil-popup' id='btn-deslogar'><span class='material-symbols-outlined'>logout</span><a href=''><p class='texto-popup'>Sair</p></a></div>`;
            btnDeslogar = document.querySelector("#btn-deslogar");
            spanAbrirPopupHeader = document.querySelector("#abrir-popup-header");

            btnDeslogar.addEventListener("click", deslogar);

            spanAbrirPopupHeader.addEventListener("click", function () {
                if (popupHeader.classList.contains("escondido")) {
                    popupHeader.classList.remove("escondido");
                } else {
                    popupHeader.classList.add("escondido");
                }

            })


            deslogado.classList.add("escondido");
            logado.classList.remove("escondido");
        }
        else if (dados["situacao"] == 'empresa') {
            popupHeader = document.querySelector(".popup-header");

            let nome = dados["nome"].charAt(0).toUpperCase() + dados["nome"].slice(1);
            const primeiroNome = nome.split(" ");

            logado.innerHTML = `<div class='nao-selecionavel' href='' id='abrir-popup-header'>
                                   <p class="nome-usuario">`+ primeiroNome[0] + `</p>
                                <span class="txt-conta" href="">
                                    <div class='crop-foto-perfil-header' id='fotoPerfil-header'><img src="${dados["foto"]}" alt=""></div>
                                    <span class="material-symbols-outlined">expand_more</span>
                                </span> 
                                </div>`;
            popupHeader.innerHTML = `<div class="perfil-popup">
                                        <span class="material-symbols-outlined">account_circle</span>
                                        <a href="perfil.aspx"><p class="texto-popup">Meu perfil</p></a>
                                    </div>
                                    <div class="perfil-popup">
                                        <span class="material-symbols-outlined">event</span>
                                        <a href="meuseventos.aspx"><p class="texto-popup">Eventos</p></a>
                                    </div>
                                    <div class="perfil-popup">
                                        <span class="material-symbols-outlined">edit</span>
                                        <a href="criacaoEventos.aspx"><p class="texto-popup">Criação de eventos</p></a>
                                    </div>
                                    <div class="perfil-popup" id='btn-deslogar'>
                                        <span class="material-symbols-outlined">logout</span>
                                        <a href="" ><p class="texto-popup">Sair</p></a>
                                    </div>`;

            btnDeslogar = document.querySelector("#btn-deslogar");
            spanAbrirPopupHeader = document.querySelector("#abrir-popup-header");

            btnDeslogar.addEventListener("click", deslogar);

            spanAbrirPopupHeader.addEventListener("click", function () {
                if (popupHeader.classList.contains("escondido")) {
                    popupHeader.classList.remove("escondido");
                } else {
                    popupHeader.classList.add("escondido");
                }

            })


            deslogado.classList.add("escondido");
            logado.classList.remove("escondido");
        }
        else {

        }

    });
}
verificarTipoLogin()

/* Realizar o login */
if (btnLogar)
    btnLogar.addEventListener("click", logar);

if (popupLogin)
    popupLogin.addEventListener("keydown", function (e) {
        if (e.key == 'Enter') {
            logar(e);
        }
    });

window.onkeydown = function (e) {
    if (e.key == 'Enter' && !telaBloqueio.classList.contains('escondido')) {
        logar(e);
    }
    if (e.key == 'Escape' && !popupLogin.classList.contains('escondido')) {
        fecharPopup(e);
    }
    if (e.key == 'Escape' && !popupCadastro.classList.contains('escondido')) {
        fecharCadastro(e);
    }
}



function logar(e) {
    e.preventDefault();

    if (txtEmail.value == "") {
        spanMsg.classList.remove("escondido");
        spanMsg.textContent = "Insira seu email.";
        return
    };

    if (txtSenha.value == "") {
        spanMsg.classList.remove("escondido");
        spanMsg.textContent = "Insira sua senha.";
        return
    };

    spanMsg.textContent = "";

    const email = txtEmail.value;
    const senha = txtSenha.value;

    fetch(`Libs/verificalogin.aspx`).then(function (resposta) { // Valicação se já existe uma sessao
        return resposta.json();
    }).then(function (dados) {
        if (dados["situacao"] == 'false') {

            fetch(`Libs/login.aspx?e=${email}&s=${senha}`).then(function (resposta) {// verifica login e senha e realiza o login
                return resposta.json();
            }).then(function (dados) {
                if (dados["situação"] == 'true') {
                    console.log(dados["situação"])
                    console.log(dados["tipologin"])
                    verificarTipoLogin()
                    fecharPopup(e)
                    window.location.assign('index.aspx')
                }
                else {
                    spanMsg.classList.remove("escondido");
                    spanMsg.textContent = "Email e/ou senha errados!";
                }
            }).catch(function (error) {
                console.log(error);
            });

        }
        else {
            fecharPopup(e)
            window.location.assign('index.aspx')
        }

    });

    // Arrumar mensagem de erro e tirar os console log
}
// Botao login
if (linkCadastro)
    linkCadastro.addEventListener('click', function (e) {
        e.preventDefault();
        console.log('aaaaaaaa')
        fecharPopup(e);
        abrirCadastro(e);
    })

/* Deslogar e tirar a sessao*/

//btnDeslogar.addEventListener("click", deslogar);

function deslogar() {
    fetch(`Libs/logout.aspx`).then(function () {
        window.location.replace('index.aspx')
    })

}

// Popup Cadastro
if (btnCadastro && btnFecharCadastro) {
    btnCadastro.addEventListener("click", abrirCadastro);
    btnFecharCadastro.addEventListener("click", fecharCadastro);

    function abrirCadastro(e) {
        e.preventDefault();
        if (telaBloqueio.classList.contains("escondido")) {
            telaBloqueio.classList.remove("escondido");
            popupCadastro.classList.remove("escondido");
            body.classList.add('removeScroll');
        }
    }

    function fecharCadastro(e) {
        if (!telaBloqueio.classList.contains("escondido")) {
            telaBloqueio.classList.add("escondido");
            popupCadastro.classList.add("escondido");
            body.classList.remove('removeScroll');
        }
    }
}

// Botoes cadastro
if (btnVoluntario)
    btnVoluntario.addEventListener('click', function (e) {
        e.preventDefault();
        window.location.href = "cadastro.aspx?t=usuario";
    })

if (btnOrganizacao)
    btnOrganizacao.addEventListener('click', function (e) {
        e.preventDefault();
        window.location.href = "cadastro.aspx?t=empresa";
    })

if (linkLogin)
    linkLogin.addEventListener('click', function (e) {
        e.preventDefault();
        fecharCadastro(e);
        abrirPopup(e);
    })