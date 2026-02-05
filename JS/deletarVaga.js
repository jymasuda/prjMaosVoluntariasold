let btnsDeletar = document.querySelectorAll("#deletar");
let popupDeletarVaga = document.querySelector("#popupDeletarVaga");
let btnDeletarVaga = document.querySelector("#btnDeletarVaga")
const btnCancelar = document.querySelector("#btnCancelar");

let codigoFuncao;


if (btnsDeletar)
    for (let btn of btnsDeletar)
    {
        btn.addEventListener("click", function () {
            codigoFuncao = btn.previousElementSibling.id;
            console.log(codigoFuncao)

            popupDeletarVaga.classList.remove("escondido");
            telaBloqueio.classList.remove("escondido");
        })
    }

if (btnDeletarVaga)
    btnDeletarVaga.addEventListener("click", function () {

        fetch(`../libs/deletarVaga.aspx?c=${codigoFuncao}`).then(function (resposta) {
            return resposta.json();

        }).then(function (dados) {

            if (dados["situacao"] == 'true') {
                location.reload();
                popupDeletarVaga.classList.add("escondido");
                telaBloqueio.classList.add("escondido");
                sessionStorage.setItem("idToast", "vagaDeletada")
            }

        }).catch(function (error) {
            console.error(error);

        })
    })
