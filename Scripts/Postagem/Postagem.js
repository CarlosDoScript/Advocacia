$(document).ready(function () {
    // Selecione o elemento h1 e ajuste seu conteúdo
    $("h1.text-black").each(function () {
        // Obtém o conteúdo do h1
        var conteudo = $(this).text();

        // Separa as palavras por espaços
        var palavras = conteudo.split(" ");

        // Define o comprimento mínimo para a quebra de linha (ajuste conforme necessário)
        var comprimentoMinimo = 10;

        // Itera sobre as palavras e adiciona quebras de linha, se necessário
        for (var i = 0; i < palavras.length; i++) {
            if (palavras[i].length > comprimentoMinimo) {
                palavras[i] = "<br>" + palavras[i];
            }
        }

        // Cria um novo conteúdo com quebras de linha
        var novoConteudo = palavras.join(" ");

        // Define o novo conteúdo no h1
        $(this).html(novoConteudo);
    });
});

$("#btnEnviar").on("click", function () {

    let nome = $("#nomeCompleto").val()
    let email = $("#email").val()
    let celular = $("#celular").val()
    let titulo = $("#titulo").val()
    let mensagem = $("#mensagem").val()

    if (nome.trim() == '') {
        Command: toastr["warning"]("Preencha o nome.")
        $("#nomeCompleto").focus()
        return
    }

    if (email.trim() == '') {
        Command: toastr["warning"]("Preencha o e-mail.")
        $("#email").focus()
        return
    }

    if (celular.trim() == '') {
        Command: toastr["warning"]("Preencha o celular.")
        $("#celular").focus()
        return
    }

    if (titulo.trim() == '') {
        Command: toastr["warning"]("Preencha o título.")
        $("#titulo").focus()
        return
    }

    if (mensagem.trim() == '') {
        Command: toastr["warning"]("Preencha a mensagem.")
        $("#mensagem").focus()
        return
    }

    $.ajax({
        url: "/Contact/PostPessoa",
        method: 'POST',
        dataType: "json",
        data: { nome: nome, email: email, celular: celular, titulo: titulo, mensagem: mensagem},
        success: function (result) {

            if (result == 1) {

                Command: toastr["success"]("Informações enviado com sucesso!")

                setTimeout(function () {
                    location.reload(true);
                }, 3000);

            } else {
                Command: toastr["error"]("Ocorreu um erro: " + result + ".")
            }


        },
        error: function (message) {
            Command: toastr["error"]("Ocorreu um erro: " + message + ".")
        }
    })

});

