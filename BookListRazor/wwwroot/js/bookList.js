var dataTable;

$(function () {
    loadDataTable();
});

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
                    return `<a href="/BookList/Edit?id=${data}" class="btn btn-primary mr-1 float-right">Edit</a><a class="btn btn-danger text-white mr-1 float-right">Delete</a>`;
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