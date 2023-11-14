
function excluirPostagem(idPostagem, nomeImagemGerada) {

    var result = confirm("Você deseja realmente excluir?");

    if (result == true) {

        $.ajax({
            url: "/Postagens/DeletePostagem",
            method: 'GET',
            dataType: "json",
            data: { idPostagem: idPostagem, nomeImagemGerada: nomeImagemGerada },
            success: function (result) {

                if (result == 1) {

                    Command: toastr["success"]("Postagem deletado com sucesso!")

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

