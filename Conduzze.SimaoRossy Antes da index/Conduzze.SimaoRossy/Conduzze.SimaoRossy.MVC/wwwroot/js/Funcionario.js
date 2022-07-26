var table = null;

$(document).ready(function () {
    createDataTable();
});

function createDataTable() {
    table = $("#tableFuncionario").DataTable({
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
    $("#tableFuncionario_filter").addClass('d-none');
}

function ModalCriarFuncionario() {
    $("#ipt_id").val("0");
    $("#ipt_nome").val("");
    $("#slct_estruturaFuncional").val("");
    $("#modal_createFuncionario").modal('show');
}

$("#slct_filtroEstruturaFuncional").change(function () {
    $("#tableFuncionario_filter").find('input').val($(this).val())
    $("#tableFuncionario_filter").find('input').keyup();
})

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
    var id = $("#ipt_id").val();
    var nome = $("#ipt_nome").val();
    var departamentoId = $("#slct_estruturaFuncional option:selected").attr("data-iddepartamento");
    var divisaoId = $("#slct_estruturaFuncional option:selected").attr("data-iddivisao");
    var setorId = $("#slct_estruturaFuncional option:selected").attr("data-idsetor");

    var formdata = new FormData();
    formdata.append("Id", id);
    formdata.append("Nome", nome);
    formdata.append("DepartamentoId", departamentoId);
    formdata.append("DivisaoId", divisaoId);
    formdata.append("SetorId", setorId);

    $.ajax({
        url: '/Funcionario/Salvar',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.status == true) {
                location.href = '/Funcionario/Index'
            }
        }
    })

    $("#modal_createFuncionario").modal('hide');
}

function excluirFuncionario(element) {

    var idFuncionario = $(element).parent().parent().attr("data-idFuncionario");

    var formdata = new FormData();
    formdata.append("idFuncionario", idFuncionario);

    $.ajax({
        url: '/Funcionario/Delete',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            location.href = '/Funcionario/Index';
        },
        error: function (data) {
            $("#modal_ex").modal('hide');
            $("#modal_ex_body").html('');
            $("#modal_ex_body").append('<p>' + data.responseText.split('!')[0] + '</p>');
            $("#modal_ex").modal('show');
        }
    })
}


function editarFuncionario(element) {

    var idFuncionario = $(element).parent().parent().attr("data-idFuncionario");

    var formdata = new FormData();
    formdata.append("idFuncionario", idFuncionario);

    $.ajax({
        url: '/Funcionario/Funcionario',
        data: formdata,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (data) {
            $("#ipt_id").val(data.id);
            $("#ipt_nome").val(data.nome);

            $("#slct_estruturaFuncional option").each(function () {
                //console.log($(this).attr("data-iddepartamento") + "," + $(this).attr("data-iddivisao") + "," + $(this).attr("data-idsetor") + "Comparar com = " + data.departamentoId + "," + data.divisaoId + "," + data.setorId)
                //console.log($(this))
                if (
                    $(this).attr("data-iddepartamento") == data.departamentoId &&
                    $(this).attr("data-iddivisao") == data.divisaoId &&
                    $(this).attr("data-idsetor") == data.setorId 
                ) {
                    $(this).prop("selected" , true);
                }
            })           
        },
        error: function (data) {
            console.log(data);
        }
    })


    $("#modal_createFuncionario").modal('show');
}
