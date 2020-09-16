﻿// Não conta textarea com editor de texto
function countChar(elm, total) {
    // Valor Default - Caso necessário obter por Ajax
    if (total == undefined || total == null) {
        total = 160;
    }

    var len = elm.value.length;
    if (len >= total) {
        elm.value = elm.value.substring(0, total);
    } else {
        $(elm).parent().find('div[name="charNum"]').text(1 + len + '/' + total + ' caracteres');
    }
}

// Conta os caracteres
$('textarea').attr('onkeyup', "countChar(this, 160)");

// Cria o div que mostra o contador
$('textarea').parent().append('<div name="charNum"></div>');