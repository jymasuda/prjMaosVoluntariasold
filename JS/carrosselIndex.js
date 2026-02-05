const container2 = document.getElementById("carosselHeader");
const options2 = {
    Autoplay: {
        timeout: 3000,
        showProgress: false
    },
};

new Carousel(container2, options2, { Autoplay });


const container = document.getElementById("grid_icones");
const options = { infinite: true, slidesPerPage: 3 };

if (container)
    new Carousel(container, options);


let btnVerMais = document.querySelector("#btnVerMais");
if (btnVerMais)
    btnVerMais.addEventListener('click', function (e) {
        e.preventDefault();
        location.href = "busca.aspx";
    })

let btnAddEvento = document.querySelector("#btnAddEvento")
if (btnAddEvento)
    btnAddEvento.addEventListener('click', function (e) {
        e.preventDefault();
        location.href = "criacaoEventos.aspx";
    })

let btnVerPendencias = document.querySelector("#btnVerPendencias")
if (btnVerPendencias)
    btnVerPendencias.addEventListener('click', function (e) {
        e.preventDefault();
        location.href = "meuseventos.aspx";
    })

let btnVagas = document.querySelector("#btnVagas");
btnVagas.addEventListener('click', function (e) {
    e.preventDefault()
    location.href = "busca.aspx";
})