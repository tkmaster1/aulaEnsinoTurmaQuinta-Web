/* Arquivo .js que contém todas funções necessárias para a página de Fornecedor */

$.fn.modal.Constructor.prototype.enforceFocus = function () { };

//Faz com que o Scroll do modal volte após clicar em fechar
$(document).ready(function () {
    $('.modal').css('overflow-y', 'auto');
});

$(function () {
    $('#cboTipoPessoa').select2();
    $('#cboSituacaoStatus').select2();
});

$(document).ready(function () {

    $('#dtFornecedor').DataTable({
        "columnDefs": [
            { "orderable": false, "targets": 4 },
            { "className": 'dt-center', "targets": [1, 2, 3, 4] }
        ],
        "searching": true,
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Exibir _MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });

    $('#btnCreateFornecedor').on('click', function () {
        $("#modalFornecedor").load("/Fornecedor/Create", function () {
            $("#modalFornecedor").modal({ backdrop: 'static', keyboard: false });
        });
    });

    $(document).on('click', '.btnEditarFornecedor', function (e) {
        e.preventDefault();

        var id = $(this).data('id');

        $("#modalFornecedor").load("/Fornecedor/Edit?id=" + id, function () {
            $("#modalFornecedor").modal({ backdrop: 'static', keyboard: false });
        });
    });

    $(document).on('click', '.btnDetalheFornecedor', function (e) {
        e.preventDefault();

        var id = $(this).data('id');

        $("#modalFornecedor").load("/Fornecedor/Detalhe?id=" + id, function () {
            $("#modalFornecedor").modal({ backdrop: 'static', keyboard: false });
        });
    });

    $(document).on('click', '.btnExcluirFornecedor', function (e) {
        e.preventDefault();

        var id = $(this).data('id');
        var nome = $(this).data('nome');
        var msg = "<p class='success-message'>Deseja excluir realmente este Fornecedor: <b>" + nome + "</b>?</p>";
        var codHidden = "<input type='hidden' id='hdCodigoFornecedor' value=\"" + id + "\"/>";

        $('#dvCodigo').html(codHidden);
        $('#modal-body-Fornecedor').html(msg);
        $("#modalExcluirFornecedor").modal({ backdrop: 'static', keyboard: false });

        $(document).on('click', '.delete-confirm', function (e) {
            e.preventDefault();

            $.ajax({
                type: 'GET',
                url: '/Fornecedor/Excluir',
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        $("#modalExcluirFornecedor").modal('hide');
                        bootbox.alert(result.mensagem);
                        fnFiltrarConteudo();
                    } else {
                        $('#modalExcluirFornecedor').html(result.mensagem);
                        return false;
                    }
                },
                error: function (er) {
                    bootbox.alert(er);
                    return false;
                }
            });
        });

    });

    $(document).on('click', '.btnReativarFornecedor', function (e) {
        e.preventDefault();

        var id = $(this).data('id');
        var nome = $(this).data('nome');
        var msgReativar = "<p class='success-message'>Deseja reativar realmente este Fornecedor: <b>" + nome + "</b>?</p>";
        var codReativarHidden = "<input type='hidden' id='hdCodigoReativarFornecedor' value=\"" + id + "\"/>";

        $('#dvCodigoReativarFornecedor').html(codReativarHidden);
        $('#modal-body-ReativarFornecedor').html(msgReativar);
        $("#modalReativarFornecedor").modal({ backdrop: 'static', keyboard: false });

        $(document).on('click', '.reativar-confirm', function (e) {
            e.preventDefault();

            $.ajax({
                type: 'GET',
                url: '/Fornecedor/Reativar',
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        $("#modalReativarFornecedor").modal('hide');
                        bootbox.alert(result.mensagem);
                        fnFiltrarConteudo();
                    } else {
                        $('#modalReativarFornecedor').html(result.mensagem);
                        return false;
                    }
                },
                error: function (er) {
                    bootbox.alert(er);
                    return false;
                }
            });
        });

    });

});

function fnFiltrarConteudo() {

    var formData = new FormData(formFornecedorFiltro);

    var pNomeFornecedor = "";
    if (!($('#iptNome').val() == null || $('#iptNome').val() == "")) {
        pNomeFornecedor = $('#iptNome').val();
    }
    formData.append('Nome', pNomeFornecedor);

    var pDocumento = "";
    if (!($('#iptDocumento').val() == null || $('#iptDocumento').val() == "")) {
        pDocumento = $('#iptDocumento').val();
    }
    formData.append('Documento', pDocumento);

    var pTipoPessoa = "";
    if (!($('#cboTipoPessoa option:selected').val() == "-- Selecione --" ||
        $('#cboTipoPessoa option:selected').val() == "" ||
        $('#cboTipoPessoa option:selected').val() == null)) {
        pTipoPessoa = $('#cboTipoPessoa option:selected').val();
    }
    formData.append('TipoPessoa', pTipoPessoa);

    var pSituacaoStatus = "";
    if (!($('#cboSituacaoStatus option:selected').val() == "-- Selecione --" ||
        $('#cboSituacaoStatus option:selected').val() == "" ||
        $('#cboSituacaoStatus option:selected').val() == null)) {
        pSituacaoStatus = $('#cboSituacaoStatus option:selected').val();
    }
    formData.append('StatusPesquisa', pSituacaoStatus);

    $.ajax({
        type: "POST",
        url: "/Fornecedor/Pesquisar",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (result) {
            if (result.length != 0) {
                fnMostrarConteudo(result);
            } else {
                $('#dtFornecedor').dataTable().fnClearTable();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            fnMensagemAlerta(xhr);
        }
    });
}

function fnMostrarConteudo(data) {

    $('#dtFornecedor').DataTable({
        bJQueryUI: true,
        data: data,
        columns: [
            { 'data': 'nome' },
            { 'data': 'documentoFormatado' },
            { 'data': 'tipoPessoaFormatado' },
            { 'data': 'statusFormatado' },
            {
                'data': '', "width": "15%",
                "render": function (data, type, row, meta) {
                    var botoesGrid = "";

                    if (!row.status) {

                        botoesGrid += ("<button type='button' class='btn btn-info btn-sm btnDetalheFornecedor' id='btnDetalheFornecedor' data-id=" + row.codigo + " data-toggle='modal'><i class='fa fa-search' data-toggle='tooltip' title='Detalhe'></i></button>" +
                            "&nbsp;<button type=\"button\" class=\"btn btn-warning btn-sm btnReativarFornecedor\" data-id=" + row.codigo + " data-nome='" + row.nome +
                            "' data-toggle=\"modal\"><i class=\"fa fa-refresh fa-spin\" data-toggle=\"tooltip\" title=\"Reativar\"></i></button>");

                    } else {

                        botoesGrid += ("<button type='button' class='btn btn-info btn-sm btnDetalheFornecedor' id='btnDetalheFornecedor' data-id=" + row.codigo + " data-toggle='modal'><i class='fa fa-search' data-toggle='tooltip' title='Detalhe'></i></button>" +
                            "&nbsp;<button type='button' class='btn btn-primary btn-sm btnEditarFornecedor' id='btnEditarFornecedor' data-id=" + row.codigo + " data-toggle='modal'><i class='fa fa-edit' data-toggle='tooltip' title='Editar'></i></button>" +
                            "&nbsp;<button type='button' class='btn btn-danger btn-sm btnExcluirFornecedor' data-id=" + row.codigo + " data-nome='" + row.nome + "' data-toggle='modal'><i class='fa fa-trash' data-toggle='tooltip' title='Excluir'></i></button>");

                    }

                    return botoesGrid;
                }
            }
        ],
        deferRender: true,
        "columnDefs": [
            { "orderable": false, "targets": 4 },
            { "className": 'dt-center', "targets": [1, 2, 3, 4] }
        ],
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            if (aData['status'] === 'false') {
                $('td', nRow).css('background-color', 'Orange');
            }
        },
        "searching": true,
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Exibir _MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        },
        "bDestroy": true
    });

}

function fnLimparCampos() {
    $('#iptNome').val('');
    $('#iptDocumento').val('');
    $('#cboTipoPessoa').val('0').change();
    $('#cboSituacaoStatus').val('').change();
    $('#dtFornecedor').dataTable().fnClearTable();
}