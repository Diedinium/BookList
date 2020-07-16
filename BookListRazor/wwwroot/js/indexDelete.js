$(function () {
    $('.delete').on('click', function (e) {
        e.preventDefault();
        let href = $(this).attr('href');
        let parentToRemove = $(this).parent().parent();
        let alert = $('.alert');

        confirmDialog('Are you sure you want to delete this?',
            function () {
                $.ajax({
                    type: "DELETE",
                    url: href,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val())
                    },
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        alert.html(response.responseMessage);
                        alert.removeClass('d-none');
                        alert.addClass('alert-success');
                        parentToRemove.fadeOut(500).queue(function () {
                            parentToRemove.remove();
                        });
                        setTimeout(function () {
                            alert.fadeOut(500);
                            setTimeout(function () {
                                alert.addClass('d-none');
                            }, 500);
                        }, 8000);
                    },
                    failure: function () {
                        alert.html("Failed to delete book.");
                        alert.removeClass('d-none');
                        alert.addClass('alert-danger');
                        setTimeout(function () {
                            alert.fadeOut(500);
                            setTimeout(function () {
                                alert.addClass('d-none');
                            }, 500);
                        }, 8000);
                    }
                });
            }
        )
    });
});