//Variaveis
if (document.querySelector('#btnEditarInformacoes') != null) {


    let btnEditarInformacoes = document.querySelector('#btnEditarInformacoes');
    let btnEditarVaga = document.querySelector('#btnEditarVaga');


    let btnSalvarInformacoes;
    let btnSalvarVagas;

    let txtTitulo;
    let dtInicio;
    let dtFim;
    let txtEndereco;
    let nomeCategoria;
    let ddlCategoria;

    let txtDescricao;

    let btnAdicionarVaga;
    let txtVagaNome;
    let dtVagaData;
    let dtVagaInicio;
    let dtVagaFim;
    let ddlVagaCategoria;
    let txtVagaDescricao;
    let txtVagaInscricoes;



    /*let tituloInformacoes = document.querySelector('#tituloInformacoes')*/
    let tituloEvento = document.querySelector('.titulo-evento')
    let informacoesEvento = document.querySelector('.informacoes-evento')
    let sobreEvento = document.querySelector('.sobre-evento')
    /*let vaga = document.querySelector('#artVaga')*/
  /*  let tituloVaga = document.querySelector('.titulo-vaga')*/
    let listaVagas = document.querySelector('.vagas')
    let descVaga = document.querySelector(".descricao");
    let sideVaga = document.querySelector(".botao");

    btnEditarInformacoes.addEventListener('click', editarInformacoes)
    btnEditarVaga.addEventListener('click', editarVaga)





    //funcoes
    function SalvarInformações() {
        const request = new URLSearchParams(window.location.search);
        const parametro = request.get('c');
        window.location.href = `evento.aspx?c=${parametro}`;
    }


    function editarInformacoes(e) {
        e.preventDefault();

        let titulo = document.querySelector(".titulo-evento");
        titulo = titulo.firstElementChild.innerHTML;

        let endereco = document.querySelector(".endereco");
        endereco = endereco.lastElementChild;
        endereco = endereco.firstElementChild.innerHTML;
        endereco = endereco.split(": ");

        // Pegando o nome da categoria

        let categoria = document.querySelector(".categoria");
        let categoriaCodigo = categoria.firstElementChild;
        categoriaCodigo = categoriaCodigo.firstElementChild.id;
        //categoriaCodigo = categoriaCodigo.id;

        // Splits para formatar data de forma correta
        let data = document.querySelectorAll(".input-datetime")
        let dataITexto = data[0].firstElementChild.innerHTML;
        let dataISplit = dataITexto.split(": ");
        let dataISplit2 = dataISplit[1].split(" às ");
        let dataIFormat = dataISplit2[0].split("/")
        let dataIForma2 = `${dataIFormat[2]}-${dataIFormat[1]}-${dataIFormat[0]}`;
        const dataInicio = `${dataIForma2}T${dataISplit2[1]}`;

        dataITexto = data[1].firstElementChild.innerHTML;
        dataISplit = dataITexto.split(": ");
        dataISplit2 = dataISplit[1].split(" às ");
        dataIFormat = dataISplit2[0].split("/")
        dataIForma2 = `${dataIFormat[2]}-${dataIFormat[1]}-${dataIFormat[0]}`;
        const dataFim = `${dataIForma2}T${dataISplit2[1]}`;

        //let dataFim = data[1].firstElementChild.innerHTML;
        // Terminar: Colocar o valor dos input datetime-local e deixar a categoria já selecionada

        let descricao = document.querySelector(".texto-evento")
        descricao = descricao.lastElementChild.innerHTML;

        let imagem = document.querySelector('.img-evento');
        imagem = imagem.lastElementChild.src;
        

        tituloEvento.classList.add('text-box');
        tituloEvento.innerHTML = `<input type="text" name="" placeholder="Título do evento." value="${titulo}" id="txtTitulo">
                <span class='span-editar' id='btnSalvarInformacoes'>
                    <span class='nao-selecionavel material-symbols-outlined icon-editar'>done</span>
                    <span class='btn-editar'><p>Salvar</p>
                </span>`

        btnSalvarInformacoes = document.querySelector('#btnSalvarInformacoes');

        let informacoesConteudo = `<div class="informacao data-hora-textbox" id="text-box-data-hora">
                    <div class="cinza-italico ">
                        <div>
                            <p>Data de início:</p>
                            <div class="input-datetime" >
                                <input type="datetime-local" name="" value="${dataInicio}" id="dtInicio">
                            </div>
                        </div>
                        <div>
                            <p>Data de fim:</p>
                            <div class="input-datetime">
                                <input type="datetime-local" name="" value="${dataFim}" id="dtFim">
                            </div>
                        </div>
                    </div>
                </div>
        
                <div class="informacao endereco-textbox" id="text-box-endereco">
                    
                    <div>
                        <p class="cinza-italico">Endereço: </p>
                        <input type="text" name="" value='${endereco[1]}' id="txtEndereco">
                    </div>
                </div>
                <div class="informacao categoria-textbox">
                    <div>
                        <p class="cinza-italico">Categoria: </p>`

        fetch(`../libs/pegarCategorias.aspx`).then(function (resposta) {
            return resposta.json();

        }).then(function (dados) {
            informacoesConteudo += `<select name="" id="ddlCategoria">
                        <option value="0" disabled>-- Selecione: --</option>`;

            if (Array.isArray(dados)) {
                for (let i = 0; i < dados.length; i++) {
                    if (dados[i].Codigo == categoriaCodigo)
                        informacoesConteudo += `<option class='option' selected value='${dados[i].Codigo}'>${dados[i].Nome}</option>`;
                    else
                        informacoesConteudo += `<option class='option' value='${dados[i].Codigo}'>${dados[i].Nome}</option>`;
                }
            }

            informacoesConteudo += `</select> </div>
                                </div>
                                `;

            informacoesEvento.innerHTML = informacoesConteudo;
            const msgErro = document.createElement("span")
            msgErro.className = "msg-erro"
            informacoesEvento.after(msgErro)




        }).catch(function (error) {
            console.error(error);

        })


        sobreEvento.innerHTML = `<div class="texto-evento text-box">
                <div class="sobre-editar">
                    <h1>Sobre o evento</h1>
                </div>
                <textarea name="" id="txtDescricaoEvento" class="scrollbar" >${descricao}</textarea>
            </div>

            <div class="img-evento">
                <div id='editar-foto'>
                    <i class="material-symbols-outlined">photo_camera</i>
                    <label id='lblFotoEvento' for='inputImagem'>Editar foto</label>
                    <input type='file' name='inputImagem' id='inputImagem' >
                </div>
                <span id='spanFotoEvento' ><img  src="${imagem}" alt=""></span>
            </div>`;


        const inputFotoEvento = document.querySelector('#inputImagem');
        const spanFotoEvento = document.querySelector('#spanFotoEvento');
        let uploadedImage;
        if (inputFotoEvento) {
            inputFotoEvento.addEventListener("change", function (event) {
                const reader = new FileReader();
                reader.addEventListener("load", () => {
                    uploadedImage = reader.result;

                    spanFotoEvento.innerHTML = `<img src='${uploadedImage}'>`
                });
                reader.readAsDataURL(this.files[0]);

            });
        }

        btnSalvarInformacoes.addEventListener('click', function () {

            
            if (txtTitulo = document.querySelector('#txtTitulo')) {

                txtTitulo = document.querySelector('#txtTitulo').value;
                dtInicio = document.querySelector('#dtInicio').value;
                dtFim = document.querySelector('#dtFim').value;
                dtHoje = new Date();
                txtEndereco = document.querySelector('#txtEndereco').value;
                var e = document.querySelector('#ddlCategoria');
                ddlCategoria = e.options[e.selectedIndex].value;
                txtDescricao = document.querySelector('#txtDescricaoEvento').value;

                const btnFoto = document.querySelector('#inputImagem');
                var arquivo = btnFoto.files[0];
                var formData = new FormData();
                formData.append('file', arquivo);


                const request = new URLSearchParams(window.location.search);
                const parametro = request.get('c');
                
                let msg = document.querySelector(".msg-erro");

                if ((txtTitulo == null) || (txtTitulo == '')) {
                    msg.innerHTML = "Preencha o campo de título do evento!";
                    return;
                }

                if ((dtInicio == null) || (dtInicio == '')) {
                    msg.innerHTML = "Preencha o campo da data de inicio!";
                    return;
                }

                dtInicio = new Date(document.querySelector('#dtInicio').value);
                if ((dtInicio < dtHoje)) {
                    msg.innerHTML = "Data de inicio não pode ser anterior ao dia de hoje!";
                    return;
                }
                dtInicio = document.querySelector('#dtInicio').value;

                if ((dtFim == null) || (dtFim == '')) {
                    msg.innerHTML = "Preencha o campo da data de fim!";
                    return;
                }

                if ((txtEndereco == null) || (txtEndereco == '')) {
                    msg.innerHTML = "Preencha o campo de endereço!";
                    return;
                }

                dtFim = new Date(document.querySelector('#dtFim').value);

                if (dtFim < dtHoje) {
                    msg.innerHTML = "Data de fim não pode ser anterior ao dia de hoje!";
                    return;
                }
                dtFim = document.querySelector('#dtFim').value;

                if ((txtDescricao == null) || (txtDescricao == '')) {
                    msg.innerHTML = "Preencha o campo de descrição!";
                    return;
                }


                fetch(`Libs/editarEvento.aspx?v=informacao&c=${parametro}&t=${txtTitulo}&i=${dtInicio}&f=${dtFim}&e=${txtEndereco}&ca=${ddlCategoria}&d=${txtDescricao}`, {
                    method: 'POST',
                    body: formData
                }).then(function (resposta) {
                    return resposta.json();
                }).then(function (dados) {

                    if (dados["situação"] == 'true') {
                        SalvarInformações();
                    }

                }).catch(function (error) {
                    console.log(error);
                });

            }

        })
    }

    function selecionarCategoria() {
        
    }

    function editarVaga(e) {
        e.preventDefault();
        btnEditarVaga.removeEventListener('click', editarVaga);

        let codigoCategoriafuncao = document.querySelector('.codigoFuncaoCategoria').id;

        const vaga = document.querySelector(".selecionado");
        const codigoFuncao = vaga.firstElementChild.id;

        const descricaoV = document.querySelector('.descricao-info').innerHTML;

        

        let vagasRestantes = document.querySelector('#vagasRestantes').innerHTML;
        vagasRestantes = vagasRestantes.split(' ');

        btnEditarVaga.innerHTML = `<span class='nao-selecionavel material-symbols-outlined icon-editar'>done</span>
                    <span class='btn-editar'><p>Salvar</p>`;

        listaVagas.classList.add('text-box');


        let selecionado = document.querySelector('.selecionado')
        const nomeDaVaga = selecionado.firstElementChild.innerHTML;
        selecionado.innerHTML = `<input type="text" name="" placeholder="Nome da vaga" value="${nomeDaVaga}" id="txtNomeDaVaga">`;



        descVaga.classList.add("text-box")
        descVaga.classList.add("text-vaga")

        let datahoras = document.querySelector('.descricao-data').innerHTML;
        console.log(datahoras)
        datahoras = datahoras.split(' ');
        dataDDMM = datahoras[0];
        hora1 = datahoras[1];
        hora2 = datahoras[3];
        dataDDMM = dataDDMM.split('/')
        YY = new Date().getFullYear().toString();
        dataYYMMDD = `${YY}-${dataDDMM[1]}-${dataDDMM[0]}`

        descVaga.innerHTML = `<div class="inputVagas" >
                                    <label for="txtDataInicio"><p>Data de ínicio:</p></label>
                                    <input type="datetime-local" name="" value="${dataYYMMDD}T${hora1}" id="txtDataInicio">            
                                </div>        
                                <div class="inputVagas">
                                    <label for="txtDataFim"><p>Data de fim:</p></label>
                                    <input type="datetime-local" name="" value="${dataYYMMDD}T${hora2}" id="txtDataFim">
                                </div>`;
                                
            
        fetch(`../libs/pegarCategoriasFuncao.aspx`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {


            let select = `<div class="inputVagas">
                        <label for="ddlCategoriaVaga"><p>Categoria:</p></label>
                        <select name="" id="ddlCategoriaVaga">
                        <option value="0" disabled>-- Selecione: --</option>`;
            if (Array.isArray(dados)) {
                for (let i = 0; i < dados.length; i++) {
                    if (codigoCategoriafuncao == dados[i].Codigo) {    
                        select += `<option selected value='${dados[i].Codigo}'>${dados[i].Nome}</option>`;
                    }
                    else {
                        select += `<option value='${dados[i].Codigo}'>${dados[i].Nome}</option>`;
                    }
                }
            }

            select += `</select></div>`;

            descVaga.innerHTML += select;
            descVaga.innerHTML += `<div class='inputVagas'>
                                    <label for="txtQuantidadeVagas"><p>Quantidade vagas:</p></label>
                                        <input type="number" name="" value="${vagasRestantes[0]}" id="txtQuantidadeVagas"></br>
                                    </div>
                                    <div class="divDescricao">
                                        <label for="txtDescricaoVaga"><p>Descrição</p></label>
                                        <textarea name="" id="txtDescricaoVaga" class="scrollbar" cols="30" rows="10">${descricaoV}</textarea>
                                    </div>`;
            descVaga.innerHTML += `<span id="msgVaga" style="font-style: italic;color: red;"></span>`;



        }).catch(function (error) {
            console.error(error);
        })


        //sideVaga.innerHTML = `<div>  
        //                    </div>`;




        /*btnSalvarVaga = document.querySelector('#btnSalvarVaga');*/
        
        btnEditarVaga.addEventListener('click', function () {
            if (txtVagaNome = document.querySelector('#txtNomeDaVaga')) {

                btnAdicionarVaga = document.querySelector('.adicionar-vaga');
                txtVagaNome = document.querySelector('#txtNomeDaVaga').value;
                //aaaaaa
                dtVagaInicio = document.querySelector('#txtDataInicio').value;
                dtVagaFim = document.querySelector('#txtDataFim').value;
                let data = new Date()
                
                //b
                //dtVagaData = document.querySelector('#txtDataVaga').value;
                //let data = new Date()
                //dtVagaInicio = document.querySelector('#txtInicioVaga').value;
                //dtVagaFim = document.querySelector('#txtFimVaga').value;
                //aaa
                var e = document.querySelector('#ddlCategoriaVaga');
                ddlVagaCategoria = e.options[e.selectedIndex].value;

                txtVagaDescricao = document.querySelector('#txtDescricaoVaga').value;
                txtVagaInscricoes = document.querySelector('#txtQuantidadeVagas').value;

                let msgVaga = document.querySelector('#msgVaga')

                if ((txtVagaNome == null) || (txtVagaNome == '')) {
                    msgVaga.innerHTML = "Preencha o nome da vaga!";
                    return;
                }
                //let dataEvento = dtVagaInicio.split("T");
                //dataEvento = dataEvento[0];

                let dataCompleta = new Date(dtVagaInicio); 
                if ((dataCompleta < data)) {
                    msgVaga.innerHTML = "Data não pode ser anterior ao dia de hoje!";
                    return;
                }
                
                data = document.querySelectorAll(".input-datetime")
                let dataITexto = data[0].firstElementChild.innerHTML;
                let dataISplit = dataITexto.split(": ");
                let dataISplit2 = dataISplit[1].split(" às ");
                let dataIFormat = dataISplit2[0].split("/")
                let dataIForma2 = `${dataIFormat[2]}-${dataIFormat[1]}-${dataIFormat[0]}`;
                let dataInicio = `${dataIForma2}T${dataISplit2[1]}`
                dataInicio = new Date(dataInicio)
                
                if ((dataCompleta < dataInicio)) {
                    msgVaga.innerHTML = "Data não pode ser anterior a data de início!";
                    return;
                }

                if ((dtVagaInicio == null) || (dtVagaInicio == '')) {
                    msgVaga.innerHTML = "Preencha a hora de início da vaga!";
                    return;
                }

                if ((dtVagaFim == null) || (dtVagaFim == '')) {
                    msgVaga.innerHTML = "Preencha a hora de fim da vaga!";
                    return;
                }

                if (dtVagaInicio > dtVagaFim) {
                    msgVaga.innerHTML = "Hora de inicio não pode ser superior a de fim!";
                    return;
                }

                if (dtVagaInicio == dtVagaFim) {
                    msgVaga.innerHTML = "Hora de inicio e de termino não podem ser iguais!";
                    return;
                }

                if ((txtVagaDescricao == null) || (txtVagaDescricao == '')) {
                    msgVaga.innerHTML = "Preencha a descrição da vaga!";
                    return;
                }

                if ((txtVagaInscricoes == null) || (txtVagaInscricoes == '')) {
                    msgVaga.innerHTML = "Preencha aquantidade de vagas!";
                    return;
                }

                const request = new URLSearchParams(window.location.search);
                const parametro = request.get('c');

                let inicio = dtVagaInicio.split("T");;
                inicio = inicio[0] + " " + inicio[1];
                
                let fim = dtVagaFim.split("T");;
                fim = fim[0] + " " + fim[1];

                fetch(`../libs/editarFuncaoVaga.aspx?c=${codigoFuncao}&ce=${parametro}&n=${txtVagaNome}&i=${inicio}&f=${fim}&ca=${ddlVagaCategoria}&de=${txtVagaDescricao}&qi=${txtVagaInscricoes}`).then(function (resposta) {
                    return resposta.json();
                }).then(function (dados) {

                    if (dados["situacao"] == 'true') {
                        /*msgVaga.innerHTML = "foi um sucesso"*/
                        location.reload()
                        sessionStorage.setItem("idToast", "vagaEditada")
                    } else {
                        msgVaga.innerHTML = "Um erro ocorreu durante a edição da vaga! Tente novamente.";
                    }


                }).catch(function (error) {
                    console.error(error);

                })
            }



        })
    }
}

let btnAdcImg = document.querySelector('.adicionar-imagem');
let inputImagemGaleria = document.querySelector('#inputAdcImgGaleria');

let btnDelImg = document.querySelectorAll('.deletar-img');
let imagensGaleria = document.querySelectorAll('.imagem-galeria')

let codigoImagem;

inputImagemGaleria.addEventListener('change', adicionarImagem)

function adicionarImagem() {

    const request = new URLSearchParams(window.location.search);
    const parametro = request.get('c');

    var arquivo = inputImagemGaleria.files[0];
    var formData = new FormData();
    formData.append('file', arquivo);

    fetch(`../libs/adicionarImagemEvento.aspx?p=${parametro}`, {
        method: 'POST',
        body: formData
    }).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {

        if (dados["situacao"] == 'true') {
            location.reload()
        }

    }).catch(function (error) {
        console.error(error);
    })
}
let popupDeletarImagem = document.querySelector("#popupDeletarImagem")
let btnDeletarImg = document.querySelector("#btnDeletarImagem");

if (btnDelImg) {
    for (let btn of btnDelImg) {
        btn.addEventListener("click", function (e) {
            e.preventDefault()
            codigoImagem = btn.parentNode.id;
            popupDeletarImagem.classList.remove("escondido");
            telaBloqueio.classList.remove("escondido");
        })

    }
}

    btnDeletarImg.addEventListener("click", function (e) {
        e.preventDefault()
        fetch(`../libs/deletarImagemEvento.aspx?c=${codigoImagem}`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {

            if (dados["situacao"] == 'true') {
                location.reload()
            }

        }).catch(function (error) {
            console.error(error);
        })

    })
    
