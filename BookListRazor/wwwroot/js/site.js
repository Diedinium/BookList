// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function confirmDialog(message, yesCallback, noCallback) {
    $('#message').html(message);
    $('.modal').modal('show');

    $('#btnYes').click(function () {
        $('.modal').modal('hide');
        yesCallback();
    });
    $('#btnNo').click(function () {
        $('.modal').modal('hide');
        noCallback();
    });
}
