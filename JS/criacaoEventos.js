let fileToRead = document.getElementById("fuDocumento");
let label = document.getElementById("txtLabel");

fileToRead.addEventListener("change", function (event) {
    let files = fileToRead.files;
    if (files.length) {
        label.innerHTML = files[0].name;
    }

}, false);

// Preenchimento automatico (Remover esse código eventualmente/Pós apresentação)

const txtNome = document.querySelector('#txtNome');
const txtEndereco = document.querySelector('#txtEndereco')
const txtDataInicio = document.querySelector('#txtDataInicio')
const ddlCidade = document.querySelector('#ddlCidade')
const txtDataFim = document.querySelector('#txtDataFinal')
const ddlCategoria = document.querySelector('#ddlCategoria')
const txtDataLimite = document.querySelector('#txtDataLimite')
const txtDescricao = document.querySelector('#txtDescricao')

addEventListener('keyup', function (e) {
    if (e.key = '[') {
        txtNome.value = 'Entrega de comida para moradores de rua';
        txtEndereco.value = 'Rua Brasilia, Santos, 198';
        txtDataInicio.value = '2023-12-19T16:00:00';
        ddlCidade.value = '8';
        txtDataFim.value = '2023-12-19T21:00:00';
        ddlCategoria.value = '2';
        txtDataLimite.value = '2023-12-15T23:59';
        txtDescricao.value = 'Um evento de entrega de comida para moradores de rua é uma iniciativa humanitária que reúne voluntários e organizações para fornecer refeições quentes e itens essenciais para pessoas em situação de vulnerabilidade. Durante o evento, os voluntários preparam ou coletam alimentos, roupas e produtos de higiene, e distribuem esses recursos diretamente para os moradores de rua, oferecendo apoio e solidariedade em um esforço para aliviar as dificuldades que enfrentam. Esse tipo de evento tem como objetivo atender às necessidades imediatas das pessoas sem-teto e promover um senso de comunidade e compaixão.';
    }
});