// Pegar o evento e nome do Botão Adcionar
//$(document).ready(function () {
//    $('#add-item-button').on('click', addItem);
//});

//// Ação do botão Adicionar
//function addItem() {
//    $('#add-item-error').hide();
//    var novoNome = $('#add-item-title').val();
//    $.post('/Usuarios/AddItem', { Nome: novoNome },
//        function () { window.location = '/Usuarios'; })
//        .fail(function (data) {
//            if (data && data.responseJSON) {
//                var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
//                $('#add-item-error').text(firstError);
//                $('#add-item-error').show();
//            }
//        });
//}

