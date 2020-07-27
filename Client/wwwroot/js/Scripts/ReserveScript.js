var table = null;
var arrCar = [];
var arrKonsumen = [];

$(document).ready(function () {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });
        
    $('#Start').on('change', function () {
        $('#endCol').show();
        $('#End').on('change', function () {
            $('#carCol').show();
            $('#CarOption').on('change', function () {
                $('#totalCol').show();
                //alert(this.value);
                var start = new Date($('#Start').val());
                var end = new Date($('#End').val());
                var diff = new Date(end - start);
                var days = diff/1000/60/60/24;
                //alert(days);
                $.ajax({
                    url: "/cars/GetById/",
                    data: { id: this.value }
                }).then((result) => {
                    //debugger;
                    //alert(result.price);
                    var tot = parseInt(result.price * days);
                    //console.log(tot)
                    //alert(tot);
                    var total = $('#Total').val(tot);

                })
            });
        });
    });

    //debugger;
    table = $("#myTable").DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/reserves/LoadReserve",
            type: "GET",
            dataType: "json",
            dataSrc: "",
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "start_date",
                'render': function (jsonDate) {
                    //var date = new Date(jsonDate).toDateString();
                    //return date;
                    var date = new Date(jsonDate);
                    return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                }
            },
            {
                "data": "end_date",
                'render': function (jsonDate) {
                    var date = new Date(jsonDate);
                    return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                }
            },
            
            {
                "data": "total",
                'render': $.fn.dataTable.render.number(',', '.', 2, 'Rp '),
            },
            {
                "data": "tgl_bayar",
                'render': function (jsonDate) {
                    var date = new Date(jsonDate);
                    var result = ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                    if (result != "01-01-2000") {
                        return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                    } else {
                        return "Null";
                    }
                }
            },
            {
                "render": function (data, type, row) {
                    return row.carName + '<br/><small>' + row.carMerk + '</small>'
                }
            },
            { "data": "konsumenName" },
            { "data": "status" },
            {
                "sortable": false,
                "render": function (data, type, row) {
                    //console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-link btn-md btn-warning " data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + row.id_reserve + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-link btn-md btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id_reserve + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            },
        ]
    });
    ClearScreen();
});

function ClearScreen() {
    $('#Id').val('');
    $('#Start').val('');
    $('#End').val('');
    $('#Total').val('');
    $('#Bayar').val('');
    $('#endCol').hide();
    $('#carCol').hide();
    $('#totalCol').hide();
    $('#bayarCol').hide();
    $('#statusCol').hide();
    $('#update').hide();
    $('#add').show();
}

function LoadCar(element) {
    //debugger;
    if (arrCar.length === 0) {
        $.ajax({
            type: "Get",
            url: "/cars/loadcar",
            success: function (data) {
                arrCar = data;
                renderCar(element);
            }
        });
    }
    else {
        renderCar(element);
    }
}

function renderCar(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Car').hide());
    $.each(arrCar, function (i, val) {
        $option.append($('<option/>').val(val.id_car).text(val.nm_car))
    });
}

function LoadKonsumen(element) {
    //debugger;
    if (arrKonsumen.length === 0) {
        $.ajax({
            type: "Get",
            url: "/konsumens/Loadkonsumen",
            success: function (data) {
                arrKonsumen = data;
                renderKonsumen(element);
            }
        });
    }
    else {
        renderKonsumen(element);
    }
}
function renderKonsumen(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Konsumen').hide());
    $.each(arrKonsumen, function (i, val) {
        $option.append($('<option/>').val(val.id_konsumen).text(val.nama))
    });
}

LoadCar($('#CarOption'))
LoadKonsumen($('#KonsumenOption'))

function GetById(id) {
    //debugger;
    $.ajax({
        url: "/reserves/GetById/",
        data: { id: id }
    }).then((result) => {
        //debugger;
        $('#Id').val(result.id_reserve);

        var getStart = new Date(result.start_date);
        var dateStart = getStart.getFullYear() + '-' + ("0" + (getStart.getMonth() + 1)).slice(-2) + '-' + ("0" + getStart.getDate()).slice(-2);
        $('#Start').val(dateStart);

        var getEnd = new Date(result.end_date);
        var dateEnd = getEnd.getFullYear() + '-' + ("0" + (getEnd.getMonth() + 1)).slice(-2) + '-' + ("0" + getEnd.getDate()).slice(-2);
        $('#End').val(dateEnd);
        $('#Status').val(result.status);
        $('#Total').val(result.total);

        var getBayar = new Date(result.tgl_bayar);
        var cek = getBayar.getFullYear() + '-' + ("0" + (getBayar.getMonth() + 1)).slice(-2) + '-' + ("0" + getBayar.getDate()).slice(-2);
        if (cek != "2000-01-01") {
            var dateBayar = getBayar.getFullYear() + '-' + ("0" + (getBayar.getMonth() + 1)).slice(-2) + '-' + ("0" + getBayar.getDate()).slice(-2);
        } else {
            var newDate = new Date();
            var dateBayar = newDate.getFullYear() + '-' + ("0" + (newDate.getMonth() + 1)).slice(-2) + '-' + ("0" + newDate.getDate()).slice(-2);
        }
        $('#Bayar').val(dateBayar);
        $('#CarOption').val(result.carID);
        $('#CarOption').on('change', function () {
            $('#totalCol').show();
            //alert(this.value);
            var start = new Date($('#Start').val());
            var end = new Date($('#End').val());
            var diff = new Date(end - start);
            var days = diff / 1000 / 60 / 60 / 24;
            //alert(days);
            $.ajax({
                url: "/cars/GetById/",
                data: { id: this.value }
            }).then((result) => {
                var tot = parseInt(result.price * days);
                var total = $('#Total').val(tot);

            })
        });
        $('#KonsumenOption').val(result.konsumenID);
        $('#endCol').show();
        $('#totalCol').show();
        $('#carCol').show();
        $('#statusCol').show();
        $('#bayarCol').show();
        $('#add').hide();
        $('#update').show();
        $('#myModal').modal('show');
    })
}

function Save() {
    //debugger;
    var Reserve = new Object();
    Reserve.start_date = $('#Start').val();
    Reserve.end_date = $('#End').val();
    Reserve.status = "Belum";
    Reserve.total = $('#Total').val();
    Reserve.tgl_bayar = "2000-01-01";
    Reserve.carID = $('#CarOption').val();
    Reserve.konsumenID = $('#KonsumenOption').val();
    $.ajax({
        type: 'POST',
        url: "/reserves/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Reserve
    }).then((result) => {
        //debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Data inserted Successfully',
                showConfirmButton: false,
                timer: 1500,
            })
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Input', 'error');
            ClearScreen();
        }
    })
}

function Update() {
    //debugger;
    var Reserve = new Object();
    Reserve.id_reserve = $('#Id').val();
    Reserve.start_date = $('#Start').val();
    Reserve.end_date = $('#End').val();
    Reserve.status = $('#Status').val();
    Reserve.total = $('#Total').val();
    Reserve.tgl_bayar = $('#Bayar').val();
    Reserve.carID = $('#CarOption').val();
    Reserve.konsumenID = $('#KonsumenOption').val();
    $.ajax({
        type: 'POST',
        url: "/reserves/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Reserve
    }).then((result) => {
        //debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Updated Successfully',
                showConfirmButton: false,
                timer: 1500,
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Input', 'error');
            ClearScreen();
        }
    })
}

function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
        if (result.value) {
            //debugger;
            $.ajax({
                url: "/reserves/Delete/",
                data: { id: id }
            }).then((result) => {
                //debugger;
                if (result.statusCode == 200) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Delete Successfully',
                        showConfirmButton: false,
                        timer: 1500,
                    });
                    table.ajax.reload();
                } else {
                    Swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            })
        };
    });
}