let btnDeletar = document.querySelector("#deletarEvento");
let popupDeletarEvento = document.querySelector("#popupDeletarEvento");
let btnDeletarEvento = document.querySelector("#btnDeletarEvento");

request = new URLSearchParams(window.location.search);
codigoEvento = request.get('c');

if (btnDeletar)
    btnDeletar.addEventListener("click", function () {
        if (popupDeletarEvento.classList.contains = "escondido") {
            popupDeletarEvento.classList.remove("escondido");
            telaBloqueio.classList.remove("escondido");
        }

    })


if (btnDeletarEvento)
    btnDeletarEvento.addEventListener("click", function (e) {
        e.preventDefault()
        let vagas = document.querySelectorAll(".funcao p");
        let codigosVagas = [];
        if (vagas)
            for (let i = 0; i < vagas.length; i++) {
                codigosVagas.push(vagas[i].id)
            }
        console.log(codigosVagas)

        fetch(`../libs/deletarEvento.aspx?c=${codigoEvento}&v=${codigosVagas}`).then(function (resposta) {
            return resposta.json();

        }).then(function (dados) {

            if (dados["situacao"] == 'true') {
                sessionStorage.setItem("idToast", "eventoDeletado")
                window.location.replace("index.aspx");
                popupDeletarEvento.classList.add("escondido");
                telaBloqueio.classList.add("escondido");
            }

        }).catch(function (error) {
            console.error(error);

        })
        
    })

if (btnCancelar)
    btnCancelar.addEventListener("click", function (e) {
        e.preventDefault();
        popupDeletarVaga.classList.add("escondido");
        popupDeletarEvento.classList.add("escondido");
        telaBloqueio.classList.add("escondido");
    })
