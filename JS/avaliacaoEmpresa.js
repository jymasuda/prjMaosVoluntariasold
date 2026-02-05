let btnPronto = document.querySelectorAll("#btnPronto");
let txtDescricao = document.querySelectorAll("#txtComentario")
let txtQuantidade = document.querySelectorAll("#inputAvaliacao")

for (let i = 0; i < btnPronto.length; i++) {
    btnPronto[i].addEventListener("click", avaliar);

    function avaliar() {
        const emailUsuario = btnPronto[i].classList[0];
        const codigo = btnPronto[i].classList[1];
        let descricao;
        if (txtDescricao[i].value == null || txtDescricao[i] == "")
            descricao = "";
        else
            descricao = txtDescricao[i].value;
        const quantidade = txtQuantidade[i].value;

        fetch(`Libs/avaliarEmpresa.aspx?u=${emailUsuario}&c=${codigo}&d=${descricao}&q=${quantidade}`).then(function (resposta) {
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