$.ajax({
    url: "/Admin/GetInformacoesPagina",
    method: 'GET',
    dataType: "json",
    success: function (result) {

        $("#casosProcessos").text(result.casosProcessos)
        $("#casosEncerrados").text(result.casosEncerrados)
        $("#clientesConfiaveis").text(result.clientesConfiaveis)
        $("#equipeEspecialistas").text(result.equipeEspecialistas)

    },
    error: function (message) {
        Command: toastr["error"]("Ocorreu um erro: " + message + ".")
    }
})

$('.editable').on('blur', function () {
    var idElemento = $(this).attr('id');
    var novoConteudo = $(this).text().trim();
});


$("#salvarTodos").on("click", function () {

    let casosProcessos = $("#casosProcessos").text()
    let casosEncerrados = $("#casosEncerrados").text()
    let clientesConfiaveis = $("#clientesConfiaveis").text()
    let equipeEspecialistas = $("#equipeEspecialistas").text()



    $.ajax({
        url: "/Admin/AtualizaInformacoesGeral",
        method: 'GET',
        dataType: "json",
        data: { casosProcessos: casosProcessos, casosEncerrados: casosEncerrados, clientesConfiaveis: clientesConfiaveis, equipeEspecialistas: equipeEspecialistas},
        success: function (result) {

            Command: toastr["success"]("Informações atualizado com sucesso.")

        },
        error: function (message) {
            Command: toastr["error"]("Ocorreu um erro: " + message + ".")
        }
    })

})