var tableAutor;
var tipoAcaoAutor = "INSERIR";
var idAutor = 0;

$.ajax({
    url: '/Autores/GetAutores',
    type: 'GET',
    dataType: 'json',
    success: function (result) {

        tableAutor = new Tabulator("#tableAutores", {
            pagination: "local",
            paginationSize: 20,
            initialSort: [{ column: "nome", dir: "asc" }],
            height: "100%",
            movableColumns: true,
            layout: "fitColumns",
            data: result,
            locale: "pt-br",
            langs: {
                "pt-br": {
                    "pagination": {
                        "page_size": "Registros por página:",
                        "page_title": "Página",
                        "first": "Primeira",
                        "first_title": "Primeira Página",
                        "last": "Última",
                        "last_title": "Última Página",
                        "prev": "Anterior",
                        "prev_title": "Página Anterior",
                        "next": "Próxima",
                        "next_title": "Próxima Página",
                    },
                },
            },
            columns: [
                { title: "Nome", field: "nome", resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                { title: "Email", field: "email", width: 300, resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                { title: "Data de nascimento", field: "dtNascimentoFormatado", width: 300, resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: editIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {
                        idAutor = cell.getRow().getData().Id

                        if (usuarioAdm.toLocaleLowerCase() == "true") {

                            tipoAcaoAutor = "EDITAR"

                            $("#nome").val(cell.getRow().getData().nome)
                            $("#email").val(cell.getRow().getData().email)
                            $("#dtNascimento").val(cell.getRow().getData().dtNascimento)

                            $("#modalAutor").modal('show')

                        } else {
                            Command: toastr["error"]("Você não tem permissão de editar!")
                        }

                    }
                },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: deleteIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {

                        if (usuarioAdm.toLocaleLowerCase() == "true") {

                            var result = confirm("Você deseja realmente excluir?");

                            if (result == true) {


                                $.ajax({
                                    url: "/Autores/DeleteAutor",
                                    method: 'GET',
                                    dataType: "json",
                                    data: { idAutor: cell.getRow().getData().Id },
                                    success: function (result) {

                                        if (result == 1) {

                                            Command: toastr["success"]("Autor deletado com sucesso!")

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
                            }


                        } else {
                            Command: toastr["error"]("Você não tem permissão de excluir!")
                        }

                    }
                }
            ]
        })
    },
    error: function (xhr, textStatus, errorThrown) {
        // Aqui você pode lidar com erros na requisição
        console.log(xhr.statusText);
    }
});

var editIcon = function (cell, formatterParams) {
    return '<i style="color:#0F2752;" title="Editar Autor" class="fa-solid fa-pen-to-square"></i>'
};

var deleteIcon = function (cell, formatterParams) {
    return '<i style="color:red;" class="fa-solid fa-trash" title="Excluir Autor"></i>'
};

$("#btnSalvar").on("click", function () {

    let nomeAutor = $("#nome").val()
    let email = $("#email").val()
    let dtNascimento = $("#dtNascimento").val()


    if (nomeAutor.trim() == '') {
        Command: toastr["warning"]("Nome é obrigatório.")
        $("#nome").focus()
        return
    }


    if (email.trim() == '') {
        Command: toastr["warning"]("E-mail é obrigatório.")
        $("#email").focus()
        return
    }

    if (dtNascimento.trim() == '') {
        Command: toastr["warning"]("Data de nascimento é obrigatório.")
        $("#dtNascimento").focus()
        return
    }

    salvarEditarAutor(tipoAcaoAutor, nomeAutor, email,dtNascimento)

})

const input = document.getElementById("pesquisar");
input.addEventListener("keyup", function () {
    tableAutor.setFilter(filtraCampos, { value: input.value });
    if (input.value == " ") {
        tableAutor.clearFilter()
    }
});

function filtraCampos(data, parametros) {
    var match = false;
    const regex = RegExp(parametros.value, 'i');

    for (var key in data) {
        if (regex.test(data[key]) == true) {
            match = true;
        }
    }
    return match;
}

$(".btnNovo").on("click", function () {

    tipoAcaoAutor = "INSERIR"

    $("#nome").val("")
    $("#email").val("")
    $("#dtNascimento").val("")
})

function salvarEditarAutor(tipo, nomeAutor, email, dtNascimento) {

    if (tipo == "INSERIR") {

        $.ajax({
            url: "/Autores/PostAutor",
            method: 'GET',
            dataType: "json",
            data: { nomeAutor: nomeAutor, email: email, dtNascimento: dtNascimento},
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"]("Autor criado com sucesso!")

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

    } else {

        $.ajax({
            url: "/Autores/EditarAutor",
            method: 'GET',
            dataType: "json",
            data: { nomeAutor: nomeAutor, email: email, dtNascimento: dtNascimento, idAutor: idAutor},
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"]("Autor editado com sucesso!")

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

    }

}