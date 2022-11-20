var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("pending")) {
        loadDataTable("pending");
    }
    else {
        if (url.includes("approved")) {
            loadDataTable("approved");
        }
        else {
            if (url.includes("progressing")) {
                loadDataTable("progressing");
            }
            else {
                if (url.includes("shipped")) {
                    loadDataTable("shipped");
                }
                else {
                    if (url.includes("cancelled")) {
                        loadDataTable("cancelled");
                    }
                    else {
                        if (url.includes("refunded")) {
                            loadDataTable("refunded");
                        }
                        else {
                            loadDataTable("all");
                        }
                    }
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        order: [[3, 'desc']],
        ajax: '/Order/GetAll?status=' + status,
        columns: [
            { data: 'id', width: '10%' },
            {
                data: 'orderDetails',
                render: function (data) {
                    var str = '';
                    for (var i = 0; i < data.length; i++)
                        str += '<p>' + data[i].productName + '</p>';
                    return str;
                },
                width: '60%'
            },
            {
                data: 'orderDate',
                render: function (data) {
                    const datetime = new Date(data);
                    const datetimeFormat = moment(datetime).format('DD/MM/YYYY HH:mm:ss');
                    return datetimeFormat;
                },
                width: '10%'
            },
            { data: 'status', width: '10%' },
            {
                "data": 'id',
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Order/Detail?orderId=${data}"
                        class="btn btn-primary mx-2"><i class="fa-solid fa-circle-info"></i> Chi tiết</a>
					</div>
                        `
                },
                width: '10%'
            }
        ]
    });
}

