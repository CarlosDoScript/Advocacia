




$("#btnPostar").on("click", function () {
    var conteudoFormatado = tinymce.activeEditor.getContent();
    var titulo = $("#titulo").val()

    if (titulo.trim() == '') {
        Command: toastr["warning"]("Preencha o título!")
        $("#titulo").focus()
        return
    }

    if (conteudoFormatado.trim() == '') {
        Command: toastr["warning"]("Contéudo esta vazio!")
        return
    }    

    alert(conteudoFormatado);


});
