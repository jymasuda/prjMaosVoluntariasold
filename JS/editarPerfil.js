const foto = document.querySelector('#fotoPerfil');
const divPerfil = document.querySelector('.divperfil-detalhes')
const nomePerfil = document.querySelector('.nome-perfil')
const descricao = document.querySelector('.descricao-perfil');
let btnEditar = document.querySelector('.btnEditar').firstElementChild;

btnEditar.addEventListener('click', Editar);

console.log(nomePerfil)
function Editar(e) {
    e.preventDefault();
    if (btnEditar.innerHTML == 'Editar') {
        let descricaoOG = descricao.innerHTML;

        foto.innerHTML = `<label id='lblFotoPerfil' for='btnFotoPerfil'>
<span class="material-symbols-outlined spanInserirImg">photo_camera</span>
                                <img src='${foto.firstElementChild.src}'>
                          </label>
                          <input type='file' class='escondido' name='btnFotoPerfil' id='btnFotoPerfil'>`;
        nomePerfilSplit = nomePerfil.innerHTML.split('<span');
        divPerfil.innerHTML = `<input type="text" id="txtNome" value="${nomePerfilSplit[0]}">
                               <textarea id='txtDescricao'>${descricaoOG}</textarea>
                                <span id='spanMsg'></span>
                                <style>#spanMsg{color:red;}</style>`;

        btnEditar.innerHTML = `Salvar`;


        const btnFoto = document.querySelector('#btnFotoPerfil');
        const lblFoto = document.querySelector('#lblFotoPerfil');
        let uploadedImage;
        if (btnFoto) {
            btnFoto.addEventListener("change", function (event) {
                const reader = new FileReader();
                reader.addEventListener("load", () => {
                    console.log('deu certo load')
                    uploadedImage = reader.result;

                    lblFoto.innerHTML = `<span class="material-symbols-outlined spanInserirImg">photo_camera</span><img src='${uploadedImage}'>`
                });
                reader.readAsDataURL(this.files[0]);

            });
        }
    } else if (btnEditar.innerHTML == 'Salvar') {
        const novaFoto = document.querySelector('#btnFotoPerfil');

        var arquivo = novaFoto.files[0];
        var formData = new FormData();
        formData.append('file', arquivo);

        const novoNome = document.querySelector('#txtNome').value;
        const novaDescricao = document.querySelector('#txtDescricao').value;


        fetch(`Libs/editarPerfil.aspx?n=${novoNome}&d=${novaDescricao}`, {
            method: 'POST',
            body: formData
        }).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados["situacao"] == 'true') {
                console.log('true')
                window.location.reload();
            }
            else {
                console.log(dados["situacao"])
            }
        }).catch(function (error) {
            console.log(error);
        });

    }

}


