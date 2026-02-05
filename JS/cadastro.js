
const body = document.querySelector('body');

const form = document.getElementById("form1");
form.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        e.preventDefault();
    }
})

//Geral
const spanMsg = document.querySelector("#spanMsg")

const txtNome = document.querySelector("#txtNome");
const txtEmail = document.querySelector("#txtEmail");
const txtSenha = document.querySelector("#txtSenha");
const txtSenhaConfirmar = document.querySelector("#txtSenhaConfirmar");

const btnCadastrar = document.querySelector("#btnCadastrar");

//Usuário
/*const nomeUsuario = document.querySelector("txtNomeUsuario");*/
/*const emailUsuario = document.querySelector("txtEmailUsuario");*/
/*const txtSenhaUsuario = document.querySelector("txtSenhaUsuario");*/
const txtCPF = document.querySelector("#txtCPF");
const txtRG = document.querySelector("#txtRG");
const fileDocumento = document.querySelector("#fileDocumento");

// Empresa
/*const nomeEmpresa = document.querySelector("txtNomeEmpresa");*/
/*const emailEmpresa = document.querySelector("txtEmailEmpresa");*/
const txtCNPJ = document.querySelector("#txtCNPJ");
const txtSite = document.querySelector("#txtSite");
const txtTelefone = document.querySelector("#txtTelefone");

//Funcoes de validação

function TestaCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf == '') return false;
    // Elimina CPFs invalidos conhecidos	
    if (cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999")
        return false;
    // Valida 1o digito	
    add = 0;
    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(9)))
        return false;
    // Valida 2o digito	
    add = 0;
    for (i = 0; i < 10; i++)
        add += parseInt(cpf.charAt(i)) * (11 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(10)))
        return false;
    return true;
}

function validacaoEmail(field) {
    usuario = field.value.substring(0, field.value.indexOf("@"));
    dominio = field.value.substring(field.value.indexOf("@") + 1, field.value.length);

    if ((usuario.length >= 1) &&
        (dominio.length >= 3) &&
        (usuario.search("@") == -1) &&
        (dominio.search("@") == -1) &&
        (usuario.search(" ") == -1) &&
        (dominio.search(" ") == -1) &&
        (dominio.search(".") != -1) &&
        (dominio.indexOf(".") >= 1) &&
        (dominio.lastIndexOf(".") < dominio.length - 1)) {
        return true;
    }
    else {
        return false;
    }
}

function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') return false;

    if (cnpj.length != 14)
        return false;

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;

    return true;

}

function telefone_validation(telefone) {

    telefone = telefone.replace(/\D/g, '');

    if (!(telefone.length >= 10 && telefone.length <= 11)) return false;

    if (telefone.length == 11 && parseInt(telefone.substring(2, 3)) != 9) return false;

    for (var n = 0; n < 10; n++) {

        if (telefone == new Array(11).join(n) || telefone == new Array(12).join(n)) return false;
    }

    var codigosDDD = [11, 12, 13, 14, 15, 16, 17, 18, 19,
        21, 22, 24, 27, 28, 31, 32, 33, 34,
        35, 37, 38, 41, 42, 43, 44, 45, 46,
        47, 48, 49, 51, 53, 54, 55, 61, 62,
        64, 63, 65, 66, 67, 68, 69, 71, 73,
        74, 75, 77, 79, 81, 82, 83, 84, 85,
        86, 87, 88, 89, 91, 92, 93, 94, 95,
        96, 97, 98, 99];

    if (codigosDDD.indexOf(parseInt(telefone.substring(0, 2))) == -1) return false;

    if (new Date().getFullYear() < 2017) return true;
    if (telefone.length == 10 && [2, 3, 4, 5, 7].indexOf(parseInt(telefone.substring(2, 3))) == -1) return false;

    return true;
}

let label = document.getElementById("txtLabelDocumento");

if (fileDocumento)
    fileDocumento.addEventListener("change", function (event) {
        let files = fileDocumento.files;
        if (files.length) {
            label.innerHTML = files[0].name;
        }

    }, false);

//Cadastrar


// formato de arquivo pdf e falar que ando nao e imagem é invalido - Verificar se email existe - validar rg - codigo de verificacao - url da empresa - celular da empresa

function cadastrar(e) {
    e.preventDefault();
    const request = new URLSearchParams(window.location.search);
    const parametro = request.get('t');

    if (parametro != null) {

        if (parametro == "usuario") {

            if (txtNome.value == "" || txtNome.value == null) {
                spanMsg.innerHTML = "Nome deve ser preenchido.";
                return;
            }

            if (txtEmail.value == "" || txtEmail.value == null) {
                spanMsg.innerHTML = "Email deve ser preenchido.";
                return;
            }

            if (validacaoEmail(txtEmail) == false) {
                spanMsg.innerHTML = "Email não é válido.";
                return;
            }


            fetch(`Libs/verificarEmail.aspx?e=${txtEmail.value}&t=usuario`).then(function (resposta) {
                return resposta.json();
            }).then(function (dados) {

                if (dados["situacao"] == 'true') {
                    spanMsg.innerHTML = "Este email já está cadastrado!";
                    return;
                }

            }).catch(function (error) {
                console.log(error);
            });


            if (txtSenha.value == "" || txtSenha.value == null) {
                spanMsg.innerHTML = "Senha deve ser preenchida.";
                return;
            }

            if (txtSenhaConfirmar.value == "" || txtSenhaConfirmar.value == null) {
                spanMsg.innerHTML = "Senha deve ser confirmada.";
                return;
            }

            if (txtSenha.value != txtSenhaConfirmar.value) {
                spanMsg.innerHTML = "As senhas não são iguais. Tente novamente.";
                return;
            }

            if (txtCPF.value == "" || txtCPF.value == null) {
                spanMsg.innerHTML = "CPF deve ser confirmado.";
                return;
            }

            let cpf = txtCPF.value;
            cpf = cpf.replace('.', '');
            cpf = cpf.replace('.', '');
            cpf = cpf.replace('-', '');

            if (TestaCPF(cpf) == false) {
                spanMsg.innerHTML = "CPF inválido.";
                return;
            }

            if (txtRG.value == "" || txtRG.value == null) {
                spanMsg.innerHTML = "RG deve ser confirmado.";
                return;
            }

            if (fileDocumento.value == "" || fileDocumento.value == null) {
                spanMsg.innerHTML = "Insira um arquivo.";
                return;
            }

            var arquivo = fileDocumento.files[0];
            var formData = new FormData();
            formData.append('file', arquivo);

            fetch(`Libs/realizarCadastro.aspx?n=${txtNome.value}&e=${txtEmail.value}&s=${txtSenha.value}&cpf=${txtCPF.value}&rg=${txtRG.value}`, {
                method: 'POST',
                body: formData
            }).then(function (resposta) {
                return resposta.json();
            }).then(function (dados) {

                if (dados["situacao"] == 'true') {
                    sessionStorage.setItem('idToast', 'cadastroRealizado')
                    window.location.replace("index.aspx");
                }
                if (dados["situacao"] == 'false') {
                    spanMsg.innerHTML = "Um erro ocorreu durante o cadastro, tente novamente mais tarde."
                }
            }).catch(function (error) {
                console.log(error);
            });

        }

        if (parametro == "empresa") {

            if (txtNome.value == "" || txtNome.value == null) {
                spanMsg.innerHTML = "Nome deve ser preenchido.";
                return;
            }

            if (txtEmail.value == "" || txtEmail.value == null) {
                spanMsg.innerHTML = "Email deve ser preenchido.";
                return;
            }

            if (validacaoEmail(txtEmail) == false) {
                spanMsg.innerHTML = "Email não é válido.";
                return;
            }

            fetch(`Libs/verificarEmail.aspx?e=${txtEmail.value}&t=empresa`).then(function (resposta) {
                return resposta.json();
            }).then(function (dados) {

                if (dados["situacao"] == 'true') {
                    spanMsg.innerHTML = "Este email já está cadastrado!";
                    return;
                }

            }).catch(function (error) {
                console.log(error);
            });

            if (txtSenha.value == "" || txtSenha.value == null) {
                spanMsg.innerHTML = "Senha deve ser preenchida.";
                return;
            }

            if (txtSenhaConfirmar.value == "" || txtSenhaConfirmar.value == null) {
                spanMsg.innerHTML = "Senha deve ser confirmada.";
                return;
            }

            if (txtSenha.value != txtSenhaConfirmar.value) {
                spanMsg.innerHTML = "As senhas não são iguais. Tente novamente.";
                return;
            }

            if (txtCNPJ.value == "" || txtCNPJ.value == null) {
                spanMsg.innerHTML = "CNPJ deve ser preenchido.";
                return;
            }

            if (validarCNPJ(txtCNPJ.value) == false) {
                spanMsg.innerHTML = "CNPJ inválido.";
                return;
            }

            if (txtSite.value == "" || txtSite.value == null) {
                spanMsg.innerHTML = "Site deve ser preenchido.";
                return;
            }

            if (txtTelefone.value == "" || txtTelefone.value == null) {
                spanMsg.innerHTML = "Telefone deve ser preenchido.";
                return;
            }

            if (telefone_validation(txtTelefone.value) == false) {//testar se funciona(nao testei rs)
                spanMsg.innerHTML = "Telefone inválido.";
                return;
            }

            fetch(`Libs/realizarCadastro.aspx?n=${txtNome.value}&e=${txtEmail.value}&s=${txtSenha.value}&cnpj=${txtCNPJ.value}&st=${txtSite.value}&t=${txtTelefone.value}`).then(function (resposta) {
                return resposta.json();
            }).then(function (dados) {

                if (dados["situacao"] == 'true') {
                    sessionStorage.setItem('idToast', 'cadastroRealizado')
                    window.location.replace("index.aspx");
                }
                else {
                    spanMsg.innerHTML = "Um erro ocorreu durante o cadastro, tente novamente mais tarde."
                }
            }).catch(function (error) {
                console.log(error);
            });
        }
    }
    else {
        window.location.href = "index.aspx";
    }
}

btnCadastrar.addEventListener('click', cadastrar);

const main = document.querySelector('.cadastro');


window.onkeydown = function (e) {
    if (e.key == 'Enter') {
        cadastrar(e);
    }
}



// Preenchimento automatico (Remover esse código eventualmente/Pós apresentação)

addEventListener('keyup', function (e) {
    if (e.key = '[') {
        txtNome.value = "ISAC - Vila dos Pescadores";
        txtEmail.value = "contato.isacvp@gmail.com";
        txtSenha.value = "123";
        txtSenhaConfirmar.value = "123";
        txtCNPJ.value = "23.762.098/0001-10";
        txtSite.value = "isacvp.com.br";
        txtTelefone.value = "(13) 2424-2373";
    }
});