const btnVerMais = document.querySelectorAll(".verMais");

for (let btn of btnVerMais) {
    btn.firstElementChild.addEventListener("click", function (e) {
        e.preventDefault();
        let botao = btn.firstElementChild;
        let offset = botao.id
        
        fetch(`Libs/listarVerMaisPerfil.aspx?t=${btn.id}&p=${offset}`).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            let eventos = btn.previousElementSibling
            for (let i = 0; i < dados.Eventos.length; i++) {

                let nota = dados.Notas[i]
                nota = String(nota).padEnd(3, '.0');
                nota = String(nota).replace(".", ",")
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
                                <div class="evento_avaliacao">
                                    <span class="material-symbols-outlined">star</span>
                                    <span class="data"> ${nota} </span>
                                </div>
                            </article>
                        </a>`;
            }
            if (dados.Paginas[0].paginasRestantes == 0)
               btn.innerHTML = "";
            else {
                let idNovo = btn.id.split(" ");
                btn.id = idNovo[0] + " " + dados.Paginas[0].paginasRestantes
                botao.id = dados.Paginas[0].offset;
            }

        }).catch(function (error) {
            console.log(error);
        });
    })
}

console.log(btnVerMais);