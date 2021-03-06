﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function deleteItem(data, button) {
    DisplayToast('Book deleted', data.responseMessage, 'rgb(97, 217, 124)');
    $(button).closest('tr').fadeOut(500).queue(function () {
        $(button).closest('tr').remove();
    });
}

function deleteItemFail(xhr) {
    DisplayToast('Error', xhr.responseJSON.message + ": " + xhr.responseJSON.detailedMessage, 'rgb(223, 70, 85)');
}

function confirmDialog(message, yesCallback, noCallback) {
    $('#message').html(message);
    $('#confirmModal').modal('show');

    $('#btnYes').click(function () {
        $('#confirmModal').modal('hide');
        yesCallback();
    });
    $('#btnNo').click(function () {
        $('#confirmModal').modal('hide');
        noCallback();
    });
}

function DisplayToast(title, msg, border) {
    let toastContainer = $('#toastContainer');
    let toast = $('#toastTemplate').clone();

    toast.find('strong').html(title);
    toast.find('.toast-body').html(msg);
    toast.css('border-color', border);

    toastContainer.append(toast);
    toast.toast('show');
}

function confirmDelete(button, bookName) {
    confirmDialog(
        `Are you sure you want to delete "${bookName}"`,
        function () {
            $(button).closest('form').submit();
        },
        function () {
            // Do nothing on no callback
        });
}
