$.ajax({
    url: '/Postar/GetCategorias',
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        $('#categorias').empty();
        var select = $('#categorias');
        select.append('<option disabled selected> Selecione uma categoria </option>')
        $(data).each(function (index, categoria) {
            select.append('<option value="' + categoria.id + '">' + categoria.descricao + '</option>');
        });        
    },
    error: function (message) {
        Command: toastr["error"]("Ocorreu um erro: " + message + ".")
    }
});
$('#categorias').change(function () {

    var idCategoria = $(this).val();

    $('#finalidades').empty();

    if (idCategoria !== '') {
        $.ajax({
            type: "GET",
            url: "/Postar/GetFinalidades",
            data: { idCategoria: idCategoria },
            dataType: "json",
            success: function (data) {
                $.each(data, function (index, finalidade) {
                    $('#finalidades').append('<option value="' + finalidade.id + '">' + finalidade.descricao + '</option>');
                });
            },
            error: function (message) {
                Command: toastr["error"]("Ocorreu um erro: " + message + ".")
            }
        });
    }
});
$.ajax({
    url: '/Postar/GetAutores',
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        $('#autores').empty();
        var select = $('#autores');
        $(data).each(function (index, autor) {
            select.append('<option value="' + autor.Id + '">' + autor.nome + '</option>');
        });
    },
    error: function (message) {
        Command: toastr["error"]("Ocorreu um erro: " + message + ".")
    }
});




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


$('#imageInput').change(handleFileInputChange);

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