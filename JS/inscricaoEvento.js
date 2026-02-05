let request = new URLSearchParams(window.location.search);
let codigoEvento = request.get('c');

let btnInscrever = document.querySelector("#btnInscrever");
let btnInscrito = document.querySelector("#btnInscrito");
if (btnInscrever)
    if (btnInscrever.id == "btnInscrever") {

        btnInscrever.addEventListener('click', realizarInscricao)
        btnInscrever.removeEventListener('click', cancelarInscricao)
    }

if (btnInscrito)
    if (btnInscrito.id == "btnInscrito") {
        btnInscrito.addEventListener('click', cancelarInscricao)
        btnInscrito.removeEventListener('click', realizarInscricao)
    }


function realizarInscricao(e) {
    e.preventDefault();

    const vaga = document.querySelector(".selecionado");
    const dataInicio = vaga.id;
    console.log(dataInicio);
    const codigoFuncao = vaga.firstElementChild.id;
    console.log(codigoFuncao);
    btnInscrever = document.querySelector("#btnInscrever");
    if (btnInscrever.id == "btnInscrever") {

        fetch(`Libs/realizarInscricao.aspx?c=${codigoFuncao}&ce=${codigoEvento}&d=${dataInicio}`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados["situacao"] == 'true') {
                console.log(dados)
                if (dados["logado"] == 'true') {
                    console.log(dados["situacao"]);

                    btnInscrever.id = "btnInscrito";
                    btnInscrever.classList.add("vazado2");
                    btnInscrever.classList.remove("azul");
                    btnInscrever.value = "Já inscrito";

                    btnInscrito = document.querySelector("#btnInscrito");
                    btnInscrito.addEventListener('mouseover', mudarValueOver);
                    btnInscrito.addEventListener('mouseout', mudarValueOut);

                    btnInscrito.removeEventListener('click', realizarInscricao);
                    btnInscrito.addEventListener('click', cancelarInscricao)

                    console.log(dados["logado"])

                   /* enviarEmail();*/
                    criarToast("inscricaoRealizada");
                }                
                if (dados["logado"] == 'false') {
                    abrirPopup(e);
                }
            }
            else {
                console.log(dados["situacao"]);
            }
        }).catch(function (error) {
            console.log(error);
        });

        
    }
}

function enviarEmail() {
    fetch(`Libs/enviarEmail.aspx?c=${codigoEvento}&t=inscricaoRealizada`).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados["situacao"] == 'true') {
            console.log("Email enviado com sucesso!")
        }
        if (dados["situacao"] == 'false') {
            console.log("Email não foi enviado!!!!!!!!")
        }
    }).catch(function (error) {
        console.log(error);
    });
}


function cancelarInscricao() {
   
    const vaga = document.querySelector(".selecionado");
    const codigoFuncao = vaga.firstElementChild.id;

    btnInscrito = document.querySelector("#btnInscrito");
    fetch(`Libs/cancelarInscricao.aspx?c=${codigoFuncao}&ce=${codigoEvento}`).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados["situacao"] == 'true') {
            btnInscrito.id = "btnInscrever";
            btnInscrito.classList.remove("vazado2");
            btnInscrito.classList.add("azul");
            btnInscrito.value = "Quero me inscrever";

            btnInscrever = document.querySelector("#btnInscrever");
            btnInscrever.removeEventListener('mouseover', mudarValueOver);
            btnInscrever.removeEventListener('mouseout', mudarValueOut);

            btnInscrever.removeEventListener('click', cancelarInscricao)
            btnInscrever.addEventListener('click', realizarInscricao);
            criarToast("inscricaoCancelada");
        }
        else {
            console.log(dados["situacao"]);
        }
    }).catch(function (error) {
        console.log(error);
    });
}

function mudarValueOver() {
    btnInscricao.value = "Cancelar Inscrição";
}

function mudarValueOut() {
    btnInscricao.value = "Já inscrito";
}