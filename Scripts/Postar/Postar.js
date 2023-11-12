// Evento de clique no botão
$("#btnPostar").on("click", function () {
    var conteudoFormatado = tinymce.activeEditor.getContent();
    var titulo = $("#titulo").val();

    if (titulo.trim() == '') {
        toastr.warning("Preencha o título!");
        $("#titulo").focus();
        return;
    }

    if (conteudoFormatado.trim() == '') {
        toastr.warning("Conteúdo está vazio!");
        return;
    }

    handleFileInputChange();

    alert(conteudoFormatado);
});

// Evento de mudança no campo de arquivo
$('#imageInput').change(handleFileInputChange);

// Função para manipular a mudança no campo de arquivo
function handleFileInputChange() {
    var fileInput = $('#imageInput')[0];
    if (fileInput.files && fileInput.files[0]) {
        var fileType = fileInput.files[0].type;
        if (!fileType.startsWith('image/')) {
            toastr.warning("Escolha um arquivo de imagem válido.");
            $('#imageInput').val('');
        }
    }
}