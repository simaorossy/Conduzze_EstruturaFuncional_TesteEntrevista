var table = null;

$(document).ready(function () {
    createDataTable();
});

function createDataTable() {
    table = $("#tableDepartamento").DataTable({
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
    $("#tableDepartamento_filter").addClass('d-none');
}

function ModalCriarDepartamento() {
    $("#ipt_desc").val("");
    $("#Modal_CreateDepartamento").modal('show');
}

function ValidarDepartamento() {
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
    var nome = $("#ipt_descricao").val();
    
    var formdata = new FormData();
    formdata.append("Descricao", nome);
   

    $.ajax({
        url: '/Departamento/Salvar',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.status == true) {
                location.href = '/Departamento/Index'
            }
        }
    })

    $("#Modal_CreateDepartamento").modal('hide');
}

function excluirDepartamento(element) {

    var idDepartamento = $(element).parent().parent().attr("data-idDepartamento");

    var formdata = new FormData();
    formdata.append("id", idDepartamento);

    $.ajax({
        url: '/Departamento/Delete',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            location.href = '/Departamento/Index';
        },
        error: function (data) {
            $("#modal_ex").modal('hide');
            $("#modal_ex_body").html('');
            $("#modal_ex_body").append('<p>' + data.responseText.split('!')[0] + '</p>');
            $("#modal_ex").modal('show');
        }
    })
}