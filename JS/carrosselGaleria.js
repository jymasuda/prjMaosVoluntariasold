//const carrossel = document.querySelector("#carrossel");
//const options = { infinite: false };

//new Carousel(carrossel, options);
carrossel = document.querySelector("#carrossel");
if (carrossel)
    criarCarrossel();



function criarCarrossel() {
const container = document.getElementById("carrossel");
const options = { infinite: false };

new Carousel(container, options);

}


