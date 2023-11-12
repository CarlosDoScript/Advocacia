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
    let arquivo = document.querySelector('input[name="imagemPost"]');
    let arquivoImagem = arquivo.files[0];
    var categoria = $("#categorias").val();
    var finalidade = $("#finalidades").val();
    var autor = $("#autores").val();

    if (titulo.trim() == '') {
        toastr.warning("Preencha o título!");
        $("#titulo").focus();
        return;
    }

    if (!arquivoImagem) {
        toastr.warning("Selecione uma imagem para capa!");
        document.getElementById("imageInput").focus();
        return;
    }

    if ($('#categorias').val() == '' || $('#categorias').val() == null) {
        toastr.warning("Selecione uma categoria!");
        $('#categorias').focus()
        return;
    }

    if ($('#finalidades').val() == '' || $('#finalidades').val() == null) {
        toastr.warning("Selecione uma finalidade!");
        $('#finalidades').focus()
        return;
    }

    if (autor.trim() == '') {
        toastr.warning("Selecione o autor!");
        $("#autores").focus();
        return;
    }

    if (conteudoFormatado.trim() == '') {
        toastr.warning("Conteúdo está vazio!");
        return;
    }

    conteudoFormatado = encodeURIComponent(conteudoFormatado);


    const formData = new FormData();
    formData.append('titulo', titulo);
    formData.append('arquivoImagem', arquivo.files[0]);
    formData.append('categoria', categoria);
    formData.append('finalidade', finalidade);
    formData.append('autor', autor);
    formData.append('conteudo', conteudoFormatado);
    formData.append('conteudoOriginal', conteudoOriginal);

    $.ajax({
        url: "/Postar/CriaPublicacao",
        method: "POST",
        contentType: false,
        processData: false,
        cache: false,
        data: formData,
        success: function (result) {
            if (result > 0) {

                Command: toastr["success"]("Post criado com sucesso!")

                setTimeout(function () {
                    location.reload(true);
                }, 3000);

            } else {
                toastr.error("Ocorreu um erro: " + result);
            }
        },
        error: function (xhr, status, error) {
            toastr.error("Ocorreu um erro: " + error);
        }
    });




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