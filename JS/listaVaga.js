const vagas = document.querySelectorAll(".funcao");
const data = document.querySelector(".descricao-data");
const descricao = document.querySelector(".descricao-info");
const qtVagas = document.querySelector("#vagasRestantes");

request = new URLSearchParams(window.location.search);
codigoEvento = request.get('c');

let btnInscricao = document.querySelector("#btnInscrever")
if (btnInscricao == null)
    btnInscricao = document.querySelector("#btnInscrito")
if (btnInscricao == null)
    btnInscricao = document.querySelector("#btn");

let btnInscricoes = document.querySelector("#btnInscicoes");
if (btnInscricoes) {
    btnInscricoes.addEventListener('click', function (e) {
        e.preventDefault();
        location.href = "inscricoes.aspx?c=" + codigoEvento;
    })

}


addEvento();

for (let vaga of vagas) {
    vaga.addEventListener("click", function () {

        console.log("vvaga")

        if (vaga.classList.contains("selecionado")) {
            return;
        }

        const dataInicio = vaga.id
        const nomeVaga = vaga.firstElementChild.innerHTML;
       

        fetch(`../libs/exibirVaga.aspx?d=${dataInicio}&n=${nomeVaga}&c=${codigoEvento}`).then(function (resposta) {
            return resposta.json();

        }).then(function (dados) {


            if (dados["situacao"] == 'true') {

                data.innerHTML = dados["data"];
                descricao.innerHTML = dados["descricao"];
                qtVagas.innerHTML = dados["qtvaga"] + " vagas restantes";
                deselecionar();
                vaga.classList.add("selecionado")

                const codigoFuncao = vaga.firstElementChild.id;
                definirBotao(codigoFuncao, dataInicio);
            }
            
            if (dados["situacao"] == 'false') {
                console.log(dados["situacao"] + " Erro!")
            }

        }).catch(function (error) {
            console.error(error);

        })

    })
}

function definirBotao(codigoFuncao, data) {

    fetch(`../libs/conferirInscricao.aspx?ce=${codigoEvento}&c=${codigoFuncao}&d=${data}`).then(function (resposta) {
        return resposta.json();

    }).then(function (dados) {

        btnInscricao = null;
        btnInscricao = document.querySelector("#btnInscrever")
        if (btnInscricao == null)
            btnInscricao = document.querySelector("#btnInscrito")
        if (btnInscricao == null)
            btnInscricao = document.querySelector("#btn");

        console.log(dados["vagas"])

        if (dados["vagas"] == 'False') {
            btnInscricao.id = "btn";
            btnInscricao.classList.add("azul");
            btnInscricao.classList.remove("vazado2");
            btnInscricao.value = "Sem vagas disponíveis";
            if (!btnInscricao.disabled)
                btnInscricao.disabled = true
            return;
        }

        if (dados["inscrito"] == 'true') {

            if (btnInscricao.id == "btnInscrever" || btnInscricao.id == "btn") { 
                console.log(dados)
                if (btnInscricao.disabled)
                btnInscricao.disabled = false;
                btnInscricao.id = "btnInscrito";
                btnInscricao.classList.add("vazado2");
                btnInscricao.classList.remove("azul");
                btnInscricao.value = "Já inscrito";

                btnInscricao.addEventListener('click', cancelarInscricao)

                addEvento();

            }

        }

        if (dados["inscrito"] == 'false') {

            if (btnInscricao.id == "btnInscrito" || btnInscricao.id == "btn") { 
                console.log(dados)
                if (btnInscricao.disabled)
                btnInscricao.disabled = false;
                btnInscricao.id = "btnInscrever";
                btnInscricao.classList.add("azul");
                btnInscricao.classList.remove("vazado2");
                btnInscricao.value = "Quero me inscrever";


                addEvento();

                btnInscricao.addEventListener('click', realizarInscricao)

                    }
        }



            }).catch(function (error) {
                console.error(error);

            })
        }

function addEvento() {

    if (btnInscricao)
        if (btnInscricao.id == "btnInscrito") {

            btnInscricao.addEventListener('mouseover', mudarValueOver)
            btnInscricao.addEventListener('mouseout', mudarValueOut)
            btnInscricao.removeEventListener('click', realizarInscricao);
            btnInscricao.addEventListener('click', cancelarInscricao)
        }

    if (btnInscricao)
        if (btnInscricao.id == "btnInscrever") {

            btnInscricao.removeEventListener('mouseover', mudarValueOver)
            btnInscricao.removeEventListener('mouseout', mudarValueOut)
            btnInscricao.removeEventListener('click', cancelarInscricao)
            btnInscricao.addEventListener('click', realizarInscricao);
        }

}

function deselecionar() {
    for (let vaga of vagas) {
        vaga.classList.remove("selecionado");
    }
}