let btnPronto = document.querySelectorAll("#btnPronto");
let txtDescricao = document.querySelectorAll("#txtComentario")
let txtQuantidade = document.querySelectorAll("#inputAvaliacao")

for (let i = 0; i < btnPronto.length; i++) {
    btnPronto[i].addEventListener("click", avaliar);

    function avaliar() {
        const emailUsuario = btnPronto[i].classList[0];
        const emailEmpresa = btnPronto[i].classList[2];
        const request = new URLSearchParams(window.location.search);
        const codigoEvento = request.get('c');
        const codigoFuncao = btnPronto[i].classList[1];
        if (txtDescricao[i] == null)
            txtDescricao[i].value = " ";
        let descricao = txtDescricao[i].value;
        const quantidade = txtQuantidade[i].value;

        console.log(emailUsuario, codigoFuncao, codigoEvento, descricao, quantidade)

        fetch(`Libs/avaliarVoluntario.aspx?e=${emailEmpresa}&u=${emailUsuario}&c=${codigoEvento}&f=${codigoFuncao}&d=${descricao}&q=${quantidade}`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados["situacao"] == 'true') {
                console.log(dados["situacao"]);
                location.reload();
                return;
            }
            else {
                location.reload();
                return;
            }
        }).catch(function (error) {
            location.reload();
        });
        return;
    }
}