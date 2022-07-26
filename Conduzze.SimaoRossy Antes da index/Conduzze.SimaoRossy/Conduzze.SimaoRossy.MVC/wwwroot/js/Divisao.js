var table = null;

$(document).ready(function () {
    createDataTable();
});

function createDataTable() {
    table = $("#tableDivisao").DataTable({
        "paging": true,
        "ordering": false,
        "search": false,
        "pageLength": 5,
        "iDisplayLength": 5,
        "lengthMenu": [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]],
        "info": false,
        "order": [[1, "asc"]],
        "language": {
            "emptyTable": "Nenhum registro encontrado",
            "lengthMenu": "Mostrar _MENU_ registros",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "search": "Pesquisar:",
            "zeroRecords": "Nenhum registros encontrado",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            },
        },
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }]
    });

    /////remover o campo padrao de busca a table
    $("#tableDivisao_filter").addClass('d-none');
}

function ModalCriarDivisao() {
    $("#ipt_descricao").val("");
    $("#slct_estruturaFuncional").val("");
    $("#modal_createDivisao").modal('show');
}


function ValidarFuncionario() {
    $(".span_alert").addClass("d-none")
    $("input").css("border", " 1px solid #ced4da")
    $("select").css("border", " 1px solid #ced4da")

    var error = 0;

    $(".ipt_required").each(function () {
        if (!$(this).val() || $(this).val() == "0") {
            $(this).parent().find(".span_alert").removeClass("d-none")
            $(this).css("border", "1px solid red")
            error++;
        }
    })

    if (error == 0) {
        save()
    }
}

function save() {
    var descricao = $("#ipt_descricao").val();
    var departamentoId = $("#slct_estruturaFuncional option:selected").val();
    
    var formdata = new FormData();
    formdata.append("Descricao", descricao);
    formdata.append("DepartamentoId", departamentoId);

    $.ajax({
        url: '/Divisao/Salvar',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.status == true) {
                location.href = '/Divisao/Index'
            }
        }
    })

    $("#modal_createDivisao").modal('hide');
}

function excluirDivisao(element) {

    var idDivisao = $(element).parent().parent().attr("data-idDivisao");

    var formdata = new FormData();
    formdata.append("id", idDivisao);

    $.ajax({
        url: '/Divisao/Delete',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            location.href = '/Divisao/Index';
        },
        error: function (data) {
            $("#modal_ex").modal('hide');
            $("#modal_ex_body").html('');
            $("#modal_ex_body").append('<p>' + data.responseText.split('!')[0] + '</p>');
            $("#modal_ex").modal('show');
        }
    })
}