if (txtCPF) {
    txtCPF.addEventListener("keyup", function (e) {
        var v = e.target.value.replace(/\D/g, "");

        v = v.replace(/(\d{3})(\d)/, "$1.$2");

        v = v.replace(/(\d{3})(\d)/, "$1.$2");

        v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2");

        e.target.value = v;
    });

}

if (txtCNPJ) {
    txtCNPJ.addEventListener("keyup", function (e) {
        var v = e.target.value.replace(/\D/g, "");

        v = v.replace(/^(\d{2})(\d)/, "$1.$2");

        v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");

        v = v.replace(/\.(\d{3})(\d)/, ".$1/$2");

        v = v.replace(/(\d{4})(\d)/, "$1-$2");

        e.target.value = v;
    });
}

if (txtRG) {
    txtRG.addEventListener("keyup", function (e) {

    })
}

if (txtTelefone) {
    txtTelefone.addEventListener("keyup", function (e) {
        var v = e.target.value.replace(/\D/g, "");

        v = v.replace(/^(\d\d)(\d)/g, "($1)$2");

        v = v.replace(/(\d{5})(\d)/, "$1-$2");

        e.target.value = v;
    })
}


