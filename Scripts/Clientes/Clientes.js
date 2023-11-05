var tableClientes;

$.ajax({
    url: '/Clientes/GetClientes',
    type: 'GET',
    dataType: 'json',
    success: function (result) {

        tableClientes = new Tabulator("#tableClientes", {
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
                { title: "Email", field: "Emil", resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                { title: "Celular", field: "Celular", width: 300, resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                { title: "Titulo", field: "Titulo", width: 300, resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                { title: "Mensagem", field: "Mensagem", width: 300, resizable: false, hozAlign: "left", headerHozAlign: "left", tooltip: true },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: viewIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {
                        $("#Nome").text(cell.getRow().getData().Nome)
                        $("#Email").text(cell.getRow().getData().Email)
                        $("#Celular").text(cell.getRow().getData().Celular)
                        $("#Titulo").text(cell.getRow().getData().Titulo)
                        $("#Mensagem").text(cell.getRow().getData().Mensagem)

                        $("#modalCliente").modal('show')

                    }
                },
                {
                    title: "", field: "", resizable: false, headerSort: false, formatter: deleteIcon, width: 1, hozAlign: "center", headerHozAlign: "center", cellClick: function (e, cell) {

                        if (usuarioAdm.toLocaleLowerCase() == "true") {

                            var result = confirm("Você deseja realmente excluir?");

                            if (result == true) {


                                $.ajax({
                                    url: "/Clientes/DeleteCliente",
                                    method: 'GET',
                                    dataType: "json",
                                    data: { idCliente: cell.getRow().getData().Id },
                                    success: function (result) {

                                        if (result == 1) {

                                            Command: toastr["success"]("Cliente deletado com sucesso!")

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

var deleteIcon = function (cell, formatterParams) {
    return '<i style="color:red;" class="fa-solid fa-trash" title="Excluir Cliente"></i>'
};
var viewIcon = function (cell, formatterParams) {
    return '<i class="fas fa-eye" title="Visualizar informações"></i>'
};

const input = document.getElementById("pesquisar");
input.addEventListener("keyup", function () {
    tableClientes.setFilter(filtraCampos, { value: input.value });
    if (input.value == " ") {
        tableClientes.clearFilter()
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