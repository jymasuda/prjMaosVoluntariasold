//Variaveis popup
    const  btnLocal = document.querySelector("#btnLocal");
    const  filtroLocal = document.querySelector(".local-aberto");
    const  btnCategoria = document.querySelector("#btnCategoria");
    const  filtroCategoria = document.querySelector(".categoria-aberto");
    const  btnHabilidade = document.querySelector("#btnHabilidade");
    const filtroHabilidade = document.querySelector(".habilidades-aberto");

// Variaveis botão
    const btnAplicarCidade = document.querySelector("#btnAplicarCidade");
    const btnAplicarCategoria = document.querySelector("#btnAplicarCategoria");
    const btnAplicarHabilidade = document.querySelector("#btnAplicarHabilidade");
    const btnLimparCidade = document.querySelector("#btnLimparCidade")
    const btnLimparCategoria = document.querySelector("#btnLimparCategoria")
    const btnLimparHabilidade = document.querySelector("#btnLimparHabilidade")
    const btnBuscar = document.querySelector("#btnBarraPesquisa")
    

// Variaveis do filtro
    const txtBusca = document.querySelector("#txtBusca");
    let chckCidade = document.querySelectorAll("#chckCidade");
    let chckCategoria = document.querySelectorAll("#chckCategoria");
    let chckHabilidade = document.querySelectorAll("#chckHabilidade");

    let Cidades = [];
    let Categorias = [];
    let Habilidades = [];

// Variaveis dos filtros ativos
let filtrosAtivosCidade = document.querySelectorAll(".cidadeAtivo");
let filtrosAtivosCategoria = document.querySelectorAll(".categoriaAtivo");
let filtrosAtivosHabilidade = document.querySelectorAll(".habilidadeAtivo");


//Função popup
function fecharLocal() {
    if (btnLocal.classList.contains("ativo")) {
        filtroLocal.classList.add("escondido");
        btnLocal.classList.remove("ativo")
    }
}

function fecharCategoria() {
    if (btnCategoria.classList.contains("ativo")) {
        filtroCategoria.classList.add("escondido");
        btnCategoria.classList.remove("ativo")
    }
}

function fecharHabilidade() {
    if (btnHabilidade.classList.contains("ativo")) {
        filtroHabilidade.classList.add("escondido");
        btnHabilidade.classList.remove("ativo")
    }
}



if (btnLocal) {
    btnLocal.addEventListener("click", function (e) {
        e.preventDefault();
        fecharCategoria(); fecharHabilidade();
        filtroLocal.classList.toggle("escondido");
        btnLocal.classList.toggle("ativo")
    })
}


if (btnCategoria) {
    btnCategoria.addEventListener("click", function (e) {
        e.preventDefault();
        fecharLocal(); fecharHabilidade();
        filtroCategoria.classList.toggle("escondido");
        btnCategoria.classList.toggle("ativo")
    })
}

if (btnHabilidade) {
    btnHabilidade.addEventListener("click", function (e) {
        e.preventDefault();
        fecharLocal(); fecharCategoria();
        filtroHabilidade.classList.toggle("escondido");
        btnHabilidade.classList.toggle("ativo")
    })
}

// Definir quais checkboxes foram marcadas: Cidade

request = new URLSearchParams(window.location.search);
codigoCidade = request.get('c');
codigoCategoria = request.get('ca');
codigoHabilidade = request.get('h');

if (codigoCidade != null)
    conferirChckCidade();

if (codigoCategoria != null)
    conferirChckCategoria();

if (codigoHabilidade != null)
    conferirChckHabilidade();

for (let i = 0; i < chckCidade.length; i++) {
    chckCidade[i].addEventListener("change", function (e) {
        if (e.currentTarget.checked) {
            Cidades.push(`${chckCidade[i].value}`);
        }
        else {
            Cidades = Cidades.filter((a) => a != chckCidade[i].value)
        }

    })
}
function conferirChckCidade() {
    for (var cidade of chckCidade) {
        if (cidade.checked) {
            Cidades.push(cidade.value);
        }
        else {
            Cidades = Cidades.filter((a) => a != cidade.value)
        }
    }
}


// Definir quais checkboxes foram marcadas: Categoria

for (let i = 0; i < chckCategoria.length; i++) {
    chckCategoria[i].addEventListener("change", function (e) {
        if (e.currentTarget.checked) {
            Categorias.push(`${chckCategoria[i].value}`);
        }
        else {
            Categorias = Categorias.filter((a) => a != chckCategoria[i].value)
        }
    })
}
function conferirChckCategoria() {
    for (var categoria of chckCategoria) {
        if (categoria.checked) {
            Categorias.push(categoria.value);
        }
        else {
            Categorias = Categorias.filter((a) => a != categoria.value)
        }
    }
}

// Definir quais checkboxed foram marcadas: Habilidade
    for (let i = 0; i < chckHabilidade.length; i++) {
        chckHabilidade[i].addEventListener("change", function (e) {
            if (e.currentTarget.checked) {
                Habilidades.push(`${chckHabilidade[i].value}`);
            }
            else {
                Habilidades = Habilidades.filter((a) => a != chckHabilidade[i].value)
            }
        })
    }

function conferirChckHabilidade() {
    for (var habilidade of chckHabilidade) {
        if (habilidade.checked) {
            Habilidades.push(habilidade.value);
        }
        else {
            Habilidades = Habilidades.filter((a) => a != habilidade.value)
        }
    }
}

// Limpar checkboxes
btnLimparCidade.addEventListener('click', function (e) {
    e.preventDefault()
    chckCidade.forEach(checkbox => checkbox.checked = false)
    Cidades = []
    buscar()

    filtroLocal.classList.toggle("escondido");
    btnLocal.classList.toggle("ativo");


})

btnLimparCategoria.addEventListener('click', function (e) {
    e.preventDefault()
    chckCategoria.forEach(checkbox => checkbox.checked = false)
    Categorias = []
    buscar()

    filtroCategoria.classList.toggle("escondido");
    btnCategoria.classList.toggle("ativo");

})

btnLimparHabilidade.addEventListener('click', function (e) {
    e.preventDefault()
    chckHabilidade.forEach(checkbox => checkbox.checked = false)
    Habilidades = []
    buscar()

    filtroHabilidade.classList.toggle("escondido");
    btnHabilidade.classList.toggle("ativo");

})

btnAplicarCidade.addEventListener('click', function (e) {
    e.preventDefault();
    buscar()

    filtroLocal.classList.toggle("escondido");
    btnLocal.classList.toggle("ativo");
})

btnAplicarCategoria.addEventListener('click', function (e) {
    e.preventDefault();
    buscar()

    filtroCategoria.classList.toggle("escondido");
    btnCategoria.classList.toggle("ativo");

})

btnAplicarHabilidade.addEventListener('click', function (e) {
    e.preventDefault();

    buscar()

    filtroHabilidade.classList.toggle("escondido");
    btnHabilidade.classList.toggle("ativo");
    
})

btnBuscar.addEventListener('click', function (e) {
    e.preventDefault();
    buscar()
    
})

function buscar() {
    window.location.replace(`busca.aspx?q=${txtBusca.value}&c=${Cidades}&ca=${Categorias}&h=${Habilidades}`);
}

//Remover filtro ativo
if (filtrosAtivosCidade)
    for (let filtro of filtrosAtivosCidade) {

        filtro.lastElementChild.addEventListener("click", function () {
            for (let chck of chckCidade) {
                if (chck.value == filtro.lastElementChild.id) {
                    chck.checked = false
                    conferirChckCidade();
                    buscar();
                }
            }
        })
    }

if (filtrosAtivosCategoria)
    for (let filtro of filtrosAtivosCategoria) {

        filtro.lastElementChild.addEventListener("click", function () {
            for (let chck of chckCategoria) {
                if (chck.value == filtro.lastElementChild.id) {
                    chck.checked = false
                    conferirChckCategoria();
                    buscar();
                }
            }
        })
    }

if (filtrosAtivosHabilidade)
    for (let filtro of filtrosAtivosHabilidade) {

        filtro.lastElementChild.addEventListener("click", function (e) {
            e.preventDefault()
            for (let chck of chckHabilidade) {
                if (chck.value == filtro.lastElementChild.id) {
                    chck.checked = false
                    conferirChckHabilidade();
                    buscar();
                }
            }
        })
    }