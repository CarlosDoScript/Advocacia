var tableEstoque;
var tipoAcaoUsuario = "INSERIR";
var idUsuario = 0;

$.ajax({
    url: '/Usuarios/GetUsuarios',
    type: 'GET',
    dataType: 'json',
    success: function (result) {

        tableEstoque = new Tabulator("#tableUsuarios", {
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
                { title: "Nome", field: "Nome", resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                { title: "Nome de login", field: "NomeLogin", resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                { title: "Email", field: "Email", width: 300, resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                {
                    title: "Administrador", field: "adm", width: 150, resizable: false, hozAlign: "left", headerHozAlign: "left", formatter: function (cell, formatterParams, onRendered) {

                        if (cell.getRow().getData().adm == true) {
                            return "Sim"
                        } else {
                            return "Não"
                        }

                    }
                },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: editIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {
                        idUsuario = cell.getRow().getData().Id

                        if (usuarioAdm.toLocaleLowerCase() == "true") {

                            tipoAcaoUsuario = "EDITAR"

                            $("#Nome").val(cell.getRow().getData().Nome)
                            $("#NomeLogin").val(cell.getRow().getData().NomeLogin)
                            $("#Email").val(cell.getRow().getData().Email)
                            $("#senha").val(cell.getRow().getData().Senha)
                            $('#checkboxAdministrador').prop('checked', cell.getRow().getData().adm);

                            $("#modalUsuario").modal('show')

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
                                    url: "/Usuarios/DeleteUsuario",
                                    method: 'GET',
                                    dataType: "json",
                                    data: { idUsuario: cell.getRow().getData().Id },
                                    success: function (result) {

                                        if (result == 1) {

                                            Command: toastr["success"]("Usuário deletado com sucesso!")

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
    return '<i style="color:#0F2752;" title="Editar Usuário" class="fa-solid fa-pen-to-square"></i>'
};

var deleteIcon = function (cell, formatterParams) {
    return '<i style="color:red;" class="fa-solid fa-trash" title="Excluir Usuário"></i>'
};

$("#btnSalvar").on("click", function () {

    let nomeUsuario = $("#Nome").val()
    let nomeLogin = $("#NomeLogin").val()
    let email = $("#Email").val()
    let senha = $("#senha").val()
    let adm = $('#checkboxAdministrador').is(':checked')


    if (nomeUsuario.trim() == '') {
        Command: toastr["warning"]("Nome é obrigatório.")
        $("#Nome").focus()
        return
    }

    if (nomeLogin.trim() == '') {
        Command: toastr["warning"]("Nome de usuário é obrigatório.")
        $("#NomeLogin").focus()
        return
    }

    if (email.trim() == '') {
        Command: toastr["warning"]("E-mail é obrigatório.")
        $("#Email").focus()
        return
    }

    if (senha.trim() == '') {
        Command: toastr["warning"]("Senha é obrigatório.")
        $("#senha").focus()
        return
    }

    salvarEditarUsuario(tipoAcaoUsuario, nomeUsuario, nomeLogin, email, senha, adm)

})

const input = document.getElementById("pesquisar");
input.addEventListener("keyup", function () {
    tableEstoque.setFilter(filtraCampos, { value: input.value });
    if (input.value == " ") {
        tableEstoque.clearFilter()
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

    tipoAcaoUsuario = "INSERIR"

    $("#Nome").val("")
    $("#NomeLogin").val("")
    $("#Email").val("")
    $("#senha").val("")
    $('#checkboxAdministrador').prop('checked', false);

})

function salvarEditarUsuario(tipo, nomeUsuario, nomeLogin, email, senha, adm) {

    if (tipo == "INSERIR") {

        $.ajax({
            url: "/Usuarios/PostUsuarios",
            method: 'GET',
            dataType: "json",
            data: { nome: nomeUsuario, nomeLogin: nomeLogin, email: email, senha: senha, adm: adm },
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"]("Usuário criado com sucesso!")

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
            url: "/Usuarios/EditarUsuarios",
            method: 'GET',
            dataType: "json",
            data: { nome: nomeUsuario, nomeLogin: nomeLogin, email: email, senha: senha, adm: adm, idUsuario: idUsuario },
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"]("Usuário editado com sucesso!")

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