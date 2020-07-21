var dataTable;

$(function () {
    loadDataTable();
    //TestToast('Test title', 'Test message but now longer lol', 'rgb(97, 217, 124)');
    $(document).on('click', '.delete', function (e) {
        e.preventDefault();
        let href = `/api/Book?id=${$(this).attr('data-delete-id')}`;
        let parentToRemove = $(this).parent().parent();

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
                        DisplayToast('Book Deleted', response.responseMessage, 'rgb(97, 217, 124)');
                        parentToRemove.fadeOut(500).queue(function () {
                            parentToRemove.remove();
                        });
                    },
                    failure: function () {
                        DisplayToast('Error', 'Failed to delete book.', 'rgb(223, 70, 85)')
                    }
                });
            },
            function () {
                // Do nothing if cancelled.
            }
        );
    });
});

// Requires title, message and border colour (as rgb or hex) to be passed
function DisplayToast(title, msg, border) {
    let toastContainer = $('#toastContainer');
    let toast = $('#toastTemplate').clone();

    toast.find('strong').html(title);
    toast.find('.toast-body').html(msg);
    toast.css('border-color', border);

    toastContainer.append(toast);
    toast.toast('show');
}

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        order: [],
        ajax: {
            url: "/api/book",
            type: "GET",
            dataType: "json"
        },
        columns: [
            { data: "name", width: "30%" },
            { data: "author", width: "25%" },
            { data: "isbn", width: "20%", className: "text-break" },
            {
                data: "id",
                render: function (data) {
                    return `<a href="/BookList/Edit?id=${data}" class="btn btn-primary mr-1 float-right">Edit</a><button class="btn btn-danger mr-1 float-right delete" data-delete-id="${data}">Delete</button>`;
                },
                width: "25%",
                className: "pr-0",
                orderable: false
            }
        ],
        language: {
            emptyTable: "No data found"
        },
        width: "100%"
    });
}