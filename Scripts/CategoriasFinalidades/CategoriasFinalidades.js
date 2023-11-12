var tableCategoria;
var tipoAcaoCategoria = "INSERIR";
var idCategoria = 0;
var tipoAcaoFinalidade = "INSERIR";
var idFinalidade = 0;
var tableFinalidades;

$.ajax({
    url: '/CategoriasFinalidades/GetCategorias',
    type: 'GET',
    dataType: 'json',
    success: function (result) {

        tableCategoria = new Tabulator("#tableCategorias", {
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
                { title: "Descrição", field: "descricao", resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: finalidadesIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {

                        idCategoria = cell.getRow().getData().id

                        Finalidades(idCategoria)

                        $("#modalFinalidade").modal('show')
                    }
                },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: editIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {

                        if (usuarioAdm.toLocaleLowerCase() == "true") {

                            $.ajax({
                                url: "/CategoriasFinalidades/VerificaCategoriaPost",
                                method: "GET",
                                dataType: "json",
                                data: { idCategoria: cell.getRow().getData().id },
                                success: function (resultCategoria) {

                                    if (resultCategoria > 0) {

                                        Command: toastr["warning"]("Não é permitido alterar a categoria, pois ela está vinculada a uma postagem.")
                                        return;

                                    } else {

                                        tipoAcaoCategoria = "EDITAR"
                                        idCategoria = cell.getRow().getData().id

                                        $("#descricao").val(cell.getRow().getData().descricao)

                                        $("#modalCategoria").modal('show')

                                    }

                                },
                                error: function (message) {
                                    Command: toastr["error"]("Ocorreu um erro: " + message + ".")
                                }
                            })

                        } else {
                            Command: toastr["error"]("Você não tem permissão de alterar!")
                        }

                    }
                },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: deleteIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {

                        if (usuarioAdm.toLocaleLowerCase() == "true") {

                            var result = confirm("Você deseja realmente excluir?");

                            if (result == true) {

                                $.ajax({
                                    url: "/CategoriasFinalidades/VerificaCategoriaPost",
                                    method: "GET",
                                    dataType: "json",
                                    data: { idCategoria: cell.getRow().getData().id },
                                    success: function (resultCategoria) {

                                        if (resultCategoria > 0) {

                                            Command: toastr["warning"]("Não é permitido excluir a categoria, pois ela está vinculada a uma postagem.")
                                            return;

                                        } else {

                                            $.ajax({
                                                url: "/CategoriasFinalidades/DeleteCategoria",
                                                method: 'GET',
                                                dataType: "json",
                                                data: { id: cell.getRow().getData().id },
                                                success: function (result) {

                                                    if (result == 1) {

                                                        Command: toastr["success"]("Categoria excluído com sucesso!")

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
        console.log(xhr.statusText);
    }
});

var editIcon = function (cell, formatterParams) {
    return '<i style="color:#0F2752;" title="Editar categoria" class="fa-solid fa-pen-to-square"></i>'
};


var finalidadesIcon = function (cell, formatterParams) {
    return '<i style="color:#0F2752;" class="fas fa-list-ol" title="Ver Finalidades"></i>'
};

var deleteIcon = function (cell, formatterParams) {
    return '<i style="color:red;" class="fa-solid fa-trash" title="Excluir categoria"></i>'
};

$("#btnSalvar").on("click", function () {

    let descricao = $("#descricao").val()

    if (descricao.trim() == '') {
        Command: toastr["warning"]("Descrição é obrigatório.")
        $("#descricao").focus()
        return
    }

    salvarEditarCategoria(tipoAcaoCategoria, descricao)

})

const input = document.getElementById("pesquisar");
input.addEventListener("keyup", function () {
    tableCategoria.setFilter(filtraCampos, { value: input.value });
    if (input.value == " ") {
        tableCategoria.clearFilter()
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

    tipoAcaoCategoria = "INSERIR"

    $("#descricao").val("")
})

$(".btnNovoFinalidade").on("click", function () {

    tipoAcaoFinalidade = "INSERIR"
    $("#tituloModalFinalidade").text("Adicionar finalidade")
    $("#descricaoFinalidade").val("")
})

function salvarEditarCategoria(tipo, descricao) {

    if (tipo == "INSERIR") {

        $.ajax({
            url: "/CategoriasFinalidades/PostCategoria",
            method: 'GET',
            dataType: "json",
            data: { descricao: descricao },
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"](" Nova categoria criada!")

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
            url: "/CategoriasFinalidades/EditarCategoria",
            method: 'GET',
            dataType: "json",
            data: { id: idCategoria, descricao: descricao },
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"]("Categoria alterado com sucesso!")

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

$("#btnSalvarFinalidade").on("click", function () {

    let descricao = $("#descricaoFinalidade").val()

    if (descricao.trim() == '') {
        Command: toastr["warning"]("Descrição é obrigatório.")
        $("#descricao").focus()
        return
    }

    salvarEditarFinalidade(tipoAcaoFinalidade, descricao)

})

function Finalidades(id) {
    $.ajax({
        url: '/CategoriasFinalidades/GetFinalidades',
        data: { idCategoria: id },
        type: 'GET',
        dataType: 'json',
        success: function (result) {

            tableFinalidades = new Tabulator("#tableFinalidades", {
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
                    { title: "Descrição", field: "descricao", resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                    {
                        title: "", field: "", resizable: false, headerSort: false, formatter: editIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {

                            if (usuarioAdm.toLocaleLowerCase() == "true") {


                                $.ajax({
                                    url: "/CategoriasFinalidades/VerificaFinalidadePost",
                                    method: "GET",
                                    dataType: "json",
                                    data: { idFinalidade: cell.getRow().getData().id },
                                    success: function (resultFinalidade) {

                                        if (resultFinalidade > 0) {

                                            Command: toastr["warning"]("Não é permitido alterar a finalidade, pois ela está vinculada a uma postagem.")
                                            return;

                                        } else {

                                            tipoAcaoFinalidade = "EDITAR"

                                            idFinalidade = cell.getRow().getData().id

                                            $("#descricaoFinalidade").val(cell.getRow().getData().descricao)
                                            $("#tituloModalFinalidade").text("Alterar finalidade")
                                            $("#modalCriaFinalidade").modal('show')
                                          
                                        }

                                    },
                                    error: function (message) {
                                        Command: toastr["error"]("Ocorreu um erro: " + message + ".")
                                    }
                                })                         

                            } else {
                                Command: toastr["error"]("Você não tem permissão de alterar!")
                            }

                        }
                    },
                    {
                        title: "", field: "", resizable: false, headerSort: false, formatter: deleteIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {

                            if (usuarioAdm.toLocaleLowerCase() == "true") {

                                var result = confirm("Você deseja realmente excluir?");

                                if (result == true) {

                                    $.ajax({
                                        url: "/CategoriasFinalidades/VerificaFinalidadePost",
                                        method: "GET",
                                        dataType: "json",
                                        data: { idFinalidade: cell.getRow().getData().id },
                                        success: function (resultFinalidade) {

                                            if (resultFinalidade > 0) {

                                                Command: toastr["warning"]("Não é permitido excluir a finalidade, pois ela está vinculada a uma postagem.")
                                                return;

                                            } else {

                                                $.ajax({
                                                    url: "/CategoriasFinalidades/DeletarFinalidade",
                                                    method: 'GET',
                                                    dataType: "json",
                                                    data: { id: cell.getRow().getData().id },
                                                    success: function (result) {

                                                        if (result == 1) {

                                                            Command: toastr["success"]("Finalidade excluído com sucesso!")

                                                            Finalidades(idCategoria)

                                                        } else {
                                                            Command: toastr["error"]("Ocorreu um erro: " + result + ".")
                                                        }

                                                    },
                                                    error: function (message) {
                                                        Command: toastr["error"]("Ocorreu um erro: " + message + ".")
                                                    }
                                                })
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
            console.log(xhr.statusText);
        }
    });

}

function salvarEditarFinalidade(tipo, descricao) {

    if (tipo == "INSERIR") {

        $.ajax({
            url: "/CategoriasFinalidades/PostFinalidade",
            method: 'GET',
            dataType: "json",
            data: { idCategoria: idCategoria, descricao: descricao },
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"](" Nova finalidade criada!")

                    Finalidades(idCategoria)
                    $("#modalCriaFinalidade").modal('hide')

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
            url: "/CategoriasFinalidades/EditarFinalidade",
            method: 'GET',
            dataType: "json",
            data: { id: idFinalidade, descricao: descricao },
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"]("Finalidade alterado com sucesso!")

                    Finalidades(idCategoria)
                    $("#modalCriaFinalidade").modal('hide')

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

const input2 = document.getElementById("pesquisarFinalidade");
input2.addEventListener("keyup", function () {
    tableFinalidades.setFilter(filtraCampos2, { value: input2.value });
    if (input2.value == " ") {
        tableFinalidades.clearFilter()
    }
});

function filtraCampos2(data, parametros) {
    var match = false;
    const regex = RegExp(parametros.value, 'i');

    for (var key in data) {
        if (regex.test(data[key]) == true) {
            match = true;
        }
    }
    return match;
}