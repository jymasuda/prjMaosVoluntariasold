let btnRecusar = document.querySelectorAll(".btnRecusar");

for (let i = 0; i < btnRecusar.length; i++) {
    btnRecusar[i].addEventListener("click", recusar);

    function recusar() {
        const email = btnRecusar[i].classList[0];
        const codigoFuncao = btnRecusar[i].id ;
        const codigoEvento = btnRecusar[i].classList[1];
        fetch(`Libs/recusarInscricao.aspx?e=${email}&c=${codigoEvento}&f=${codigoFuncao}`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados["situação"] == 'true') {
                console.log(dados["situação"])
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