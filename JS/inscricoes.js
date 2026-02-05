let btnRecusar = document.querySelectorAll(".btnRecusar");
let btnAceitar = document.querySelectorAll(".btnAceitar");

for (let i = 0; i < btnRecusar.length; i++) {
    btnRecusar[i].addEventListener("click", recusar);

    function recusar() {
        const email = btnRecusar[i].id;
        const request = new URLSearchParams(window.location.search);
        const codigoEvento = request.get('c');
        const codigoFuncao = btnRecusar[i].classList[0];
        fetch(`Libs/recusarInscricao.aspx?e=${email}&c=${codigoEvento}&f=${codigoFuncao}`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados["situação"] == 'true') {
                console.log(dados["situação"])
                sessionStorage.setItem("idToast", "inscricaoRecusada")
                location.reload()

            }
            else {
                console.log(dados["situação"])
            }
        }).catch(function (error) {
            console.log("Erro!!!");
        });

        return;
    }
}

for (let i = 0; i < btnAceitar.length; i++) {
    btnAceitar[i].addEventListener("click", aceitar);
    console.log("aceitar");
    function aceitar() {
        const email = btnAceitar[i].id;
        const request = new URLSearchParams(window.location.search);
        const codigoEvento = request.get('c');
        const codigoFuncao = btnRecusar[i].classList[0];
        fetch(`Libs/aceitarInscricao.aspx?e=${email}&c=${codigoEvento}&f=${codigoFuncao}`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados["situação"] == 'true') {
                console.log(dados["situação"]);
                sessionStorage.setItem("idToast", "inscricaoAceita")
                location.reload();
            }
            else {
                if (dados["situação"] == 'vagasEsgotadas') {
                    console.log(dados["situação"]);
                    return;
                }
                else {

                    return;
                }
            }
        }).catch(function (error) {
            location.reload();
        });
        return;
    }
}

