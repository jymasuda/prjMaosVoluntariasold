const tipoToast = {
    timer: 500000000,
    cadastroRealizado: { titulo: "Cadastro realizado com sucesso!", texto: "Não se esqueça de realizar seu login!" },
    eventoCriado: { titulo: "Criação do evento feita com sucesso!", texto: "Caso alguma informação esteja incorreta, é possível edita-las clicando no botão de editar." },
    eventoDeletado: { titulo: "Evento deletado com sucesso!", texto: "Ficamos triste de ver um evento partir, mas estamos ansiosos para ver seus próximos eventos." },
    vagaCriada: { titulo: "Nova vaga adicionada com sucesso!", texto: "Caso alguma informação esteja incorreta, é possível edita-las clicando no botão de editar." },
    vagaEditada: { titulo: "Vaga editada com sucesso!", texto: "Caso alguma informação esteja incorreta, é possível edita-las novamente clicando no botão de editar." },
    vagaDeletada: { titulo: "Vaga deletada com sucesso!", texto: "" },
    inscricaoAceita: { titulo: "Está inscrição foi aceita!", texto: "No caso do cancelamento da mesma pelo usuário, você será notificado por email." },
    inscricaoRecusada: { titulo: "Está inscrição foi recusada!", texto: "A inscrição não aparecerá mais na aba de inscrições, e o voluntário será notificado por email sobre a rejeição." },
    inscricaoRealizada: { titulo: "Inscrição realizada com sucesso!", texto: "Fique atento a qualquer atualização pelo email ou pagina de minhas inscrições" },
    inscricaoCancelada: { titulo: "Sua inscrição foi cancelada!", texto: "" }

}
const main = document.querySelector("main");

if (sessionStorage.getItem('idToast') != null )
    criarToast(sessionStorage.getItem('idToast'));

let id = document.cookie.split("toastId=")

if (document.cookie != null && document.cookie != "toastId=" && document.cookie != "") {
    criarToast(id[1]);
}

function fechar() {
    let toast = document.querySelector(".toast");
    //fazer um for que faz tudo do quyery selctor allfor (var i = 0; i < 9; i++) {
    //    console.log(i);
    toast.classList.add('escondido');
        
    //}

    console.log('fechar toast')
    console.log(toast)
}

function removerToast(toast) {
   toast.remove()
}

function criarToast(id) {
    if (document.querySelector(".toast")) {
        console.log('toast existe nao existe sla');

        let toast = document.querySelector(".toast");
        removerToast(toast);
    }
        
    
    
    const toast = document.createElement("div")
    toast.className = `toast ${id}`
    toast.innerHTML = `<div>
                            <p class="txt-toast">${tipoToast[id].titulo}</p>
                            <p>${tipoToast[id].texto}</p>
                        </div>
                            <span id='btnOk' class="${id} nao-selecionavel material-symbols-outlined">check_circle</span>`;
    main.appendChild(toast);
    let btnOk = toast.lastElementChild;
    btnOk.addEventListener('click', fechar)
    setTimeout(() => removerToast(toast), tipoToast.timer)
    sessionStorage.removeItem("idToast");
    document.cookie = "toastId=;";
}