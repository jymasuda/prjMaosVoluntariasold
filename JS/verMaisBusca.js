let verMais = document.querySelector(".verMais");
let btnVerMais = verMais.firstElementChild;
console.log(btnVerMais)

btnVerMais.addEventListener("click", function (e) {
    e.preventDefault();

    console.log(verMais.id)
    console.log(btnVerMais.id)
    console.log(Cidades)
    console.log(Categorias)
    console.log(Habilidades)
    console.log(txtBusca.value)

    fetch(`Libs/listarVerMaisBusca.aspx?p=${verMais.id}&o=${btnVerMais.id}&c=${Cidades}&ca=${Categorias}&h=${Habilidades}&q=${txtBusca.value}`).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        let eventos = document.querySelector(".eventos");
        for (let i = 0; i < dados.Eventos.length; i++) {
            console.log("Gerando Evento")
            let data = moment(dados.Eventos[i].DataInicio).format("DD[/]MM")
            eventos.innerHTML += `
                        <a href="evento.aspx?c=${dados.Eventos[i].Codigo}">
                            <article class="evento">
                                <img src="${dados.Eventos[i].Imagem}" alt="" class="evento_capa">
                                <div class="content">
                                    <h2>${dados.Eventos[i].Nome}</h2>
                                    <h4 class="evento_autor cinzaEItalico">por ${dados.Eventos[i].Empresa["Nome"]}</h4>
                                    <p class="evento_descricao">${dados.Eventos[i].Descricao}</p>
                                    <div class="evento_localizacao">
                                        <span class="material-symbols-outlined">location_on</span>
                                        <h5 class="cinzaEItalico"> ${dados.Eventos[i].Endereco}</h5>
                                    </div>
                                </div>
                                <div class="evento_data">
                                    <span class="material-symbols-outlined">calendar_month</span>
                                    <span class="data"> ${data} </span>
                                </div>
                            </article>
                        </a>`;
        }
        if (dados.Paginas[0].paginasRestantes == 0)
            verMais.innerHTML = "";
        else {        
            verMais.id = dados.Paginas[0].paginasRestantes
            btnVerMais.id = dados.Paginas[0].paginaAtual;
        }

    }).catch(function (error) {
        console.log(error);
    });

})