const icons = ["0", "landslide", "restaurant", "payments", "child_care", "theater_comedy", "handshake", "menu_book", "sports_soccer", "elderly", "temp_preferences_eco", "accessible", "volunteer_activism", "pets"];

if (window.location.href.indexOf('evento.aspx') != -1) {
    definirIcon()
}

if (window.location.href.indexOf('index.aspx') != -1) {
    definirIconIndex()
}



function definirIcon() {


    let spanCategoria = document.querySelector(".icone");
    let spanId = spanCategoria.id;
    for (var i = 0; i < icons.length; i++) {
        if (spanId == icons.indexOf(icons[i])) {
            spanCategoria.innerHTML = icons[i];
        }
    }
}

function definirIconIndex() {

    let spans = document.querySelectorAll("#iconeCarrossel");
    for (let span of spans) {
        let icone = span.firstElementChild
        for (var i = 0; i < icons.length; i++) {
            let id = icone.id
            if (id == icons.indexOf(icons[i])) {
                icone.innerHTML = icons[i];
            }
        }
    }
    

}


