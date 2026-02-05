const btnAddVaga = document.querySelector(".adicionar-vaga");
const descVaga = document.querySelector(".descricao");
const sideVaga = document.querySelector(".botao");

if (btnAddVaga)
    btnAddVaga.addEventListener("click", vagaForm)

console.log(descVaga);
console.log(sideVaga)

function vagaForm() {

    btnAddVaga.removeEventListener("click", vagaForm);

    deselecionar()

    btnAddVaga.innerHTML = `<div class='selecionado'><input type="text" name="" placeholder="Nome da vaga" id="txtNomeDaVaga"></div>`;
    btnAddVaga.closest(".vagas").classList.add("text-box")


    descVaga.classList.add("text-box")
    descVaga.classList.add("text-vaga")
    descVaga.innerHTML = `<div class="inputVagas" >
                                    <label for="txtDataInicio"><p>Data de ínicio:</p></label>
                                    <input type="datetime-local" name="" value="" id="txtDataInicio">            
                                </div>        
                                <div class="inputVagas">
                                    <label for="txtDataFim"><p>Data de fim:</p></label>
                                    <input type="datetime-local" name="" value="" id="txtDataFim">
                                </div>`;

    //<input type="date" name="" id="txtDataVaga">
    //    <input type="time" name="" id="txtInicioVaga">
    //        <input type="time" name="" id="txtFimVaga">

    fetch(`../libs/pegarCategoriasFuncao.aspx`).then(function (resposta) {
        return resposta.json();

    }).then(function (dados) {
        let select = `<div class="inputVagas">
                        <label for="ddlCategoriaVaga"><p>Categoria:</p></label>
                        <select name="" id="ddlCategoriaVaga">
                        <option value="0">-- Selecione: --</option>`;

        if (Array.isArray(dados)) {
            for (let i = 0; i < dados.length; i++) {
                select += `<option value='${dados[i].Codigo}'>${dados[i].Nome}</option>`;
            }
        }

        select += `</select></div>`;

        descVaga.innerHTML += select;
        descVaga.innerHTML += `<div class='inputVagas'>
                                    <label for="txtQuantidadeVagas"><p>Quantidade vagas:</p></label>
                                        <input type="number" name="" value="0" id="txtQuantidadeVagas"></br>
                                    </div>
                                    <div class="divDescricao">
                                        <label for="txtDescricaoVaga"><p>Descrição</p></label>
                                        <textarea name="" id="txtDescricaoVaga" class="scrollbar" cols="30" rows="10"></textarea>
                                    </div>`;
        descVaga.innerHTML += `<span id="msgVaga" style="font-style: italic;color: red;"></span>`;

        


    }).catch(function (error) {
        console.error(error);

    })                        
    
                                    
    //sideVaga.innerHTML = `  <div>
    //                            <input type="number" name="" id="txtQuantidadeVagas">
    //                            <input class="btn azul" type="button" value="Criar vaga" id="btnCriar">
    //                        </div>`;


    //const btnCriar = document.querySelector("#btnCriar");
    //btnCriar.addEventListener("click", criarVaga);
    const btnEditarVaga = document.querySelector('#btnEditarVaga');
    btnEditarVaga.innerHTML = `<span class='nao-selecionavel material-symbols-outlined icon-editar'>done</span>
                    <span class='btn-editar'><p>Salvar</p>`;
    btnEditarVaga.addEventListener('click', criarVaga);

}

function criarVaga() {

    const nome = document.querySelector("#txtNomeDaVaga");
    /*const data = document.querySelector("#txtDataVaga"); */
    const inicio = document.querySelector("#txtDataInicio");
    const fim = document.querySelector("#txtDataFim");
    const categoria = document.querySelector("#ddlCategoriaVaga");
    const descricao = document.querySelector("#txtDescricaoVaga");
    const quantidade = document.querySelector("#txtQuantidadeVagas");
    request = new URLSearchParams(window.location.search);
    codigoEvento = request.get('c');
    
    if (nome.value == "" || nome.value == null)
    {
        msgVaga.innerHTML = "Dê um nome para a vaga!";
        return;
    }

    if (inicio.value == "" || inicio.value == null) {
        msgVaga.innerHTML = "Defina uma data e hora de início!";
        return;
    }

    if (fim.value == "" || fim.value == null) {
        msgVaga.innerHTML = "Defina uma data e hora de fim!";
        return;
    }

    const dataHoje = new Date();
    const dt1 = new Date(inicio.value)

    if (dt1 < dataHoje) {
        msgVaga.innerHTML = "Data de inicio não pode ser anterior a de hoje!";
        return;
    }
    const dt2 = new Date(fim.value)
    if (dt2 < dataHoje) {
        msgVaga.innerHTML = "Data de fim não pode ser anterior a de hoje!";
        return;
    }
    

    if (fim.value < inicio.value)
    {
        msgVaga.innerHTML = "Hora de fim não pode ser antes da hora de início!";
        return;
    }

    if (categoria.value == 0 || categoria.value == null) {
        msgVaga.innerHTML = "Selecione uma categoria!";
        return;
    }

    if (descricao.value == "" || descricao.value == null) {
        msgVaga.innerHTML = "Preencha o campo de descrição!";
        return;
    }

    if (quantidade.value == "" || quantidade.value == null) {
        msgVaga.innerHTML = "Defina a quantidade de vagas!";
        return;
    }

    let inicioFormat = inicio.value.split("T");;
    inicioFormat = inicioFormat[0] + " " + inicioFormat[1];

    let fimFormat = fim.value.split("T");;
    fimFormat = fimFormat[0] + " " + fimFormat[1];
    
    fetch(`../libs/criarVaga.aspx?n=${nome.value}&cc=${categoria.value}&ce=${codigoEvento}&i=${inicioFormat}&f=${fimFormat}&q=${quantidade.value}&d=${descricao.value}`).then(function (resposta) {
        return resposta.json();

    }).then(function (dados) {

        if (dados["situacao"] == 'true') {

            location.reload()
            sessionStorage.setItem("idToast", "vagaCriada")
        }

        if (dados["situacao"] == 'false') {
            msgVaga.innerHTML = "Um erro ocorreu durante a criação da vaga! Tente novamente.";
        }

    }).catch(function (error) {
        console.error(error);

    })    

    console.log(nome.value + data.value + inicio.value + fim.value + categoria.value + descricao.value + quantidade.value)
}


// Preenchimento automatico;


addEventListener('keyup', function (e) {
    const nome = document.querySelector("#txtNomeDaVaga");
    const dataInicio = document.querySelector("#txtDataInicio");
    const dataFim = document.querySelector("#txtDataFim");
    const categoria = document.querySelector("#ddlCategoriaVaga");
    const quantiaVagas = document.querySelector("#txtQuantidadeVagas");
    const descricaoVaga = document.querySelector("#txtDescricaoVaga")
    if (e.key = '[') {
        nome.value = "Cozinheiro";
        dataInicio.value = "2023-12-19T16:00:00";
        dataFim.value = "2023-11-19T18:00:00";
        categoria.value = "3";
        quantiaVagas.value = "3";
        descricaoVaga.value = "Procuramos algumas pessoas que estejam dispostas a nos ajudar a cozinhar a comida que iremos entregar aos moradores de rua";
    }
})