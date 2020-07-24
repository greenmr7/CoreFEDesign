var table = null;
var arrMerk = [];

$(document).ready(function () {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })

    //debugger;
    table = $("#myTable").DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/cars/LoadCar",
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
                "render": function (data, type, row) {
                    return row.nm_car + '<br/><small>'+ row.merkName +'</small>'
                }
            },
            { "data": "year" },
            { "data": "transmition" },
            {
                "sortable": false,
                "render": function (data, type, row) {
                    //console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-link btn-md btn-warning " data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + row.id_car + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-link btn-md btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id_car + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
        ]
    });
});

function ClearScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Year').val('');
    $('#Transmisi').val('');
    $('#update').hide();
    $('#add').show();
}

function LoadMerk(element) {
    //debugger;
    if (arrMerk.length === 0) {
        $.ajax({
            type: "Get",
            url: "/merks/LoadMerk",
            success: function (data) {
                arrMerk = data;
                renderMerk(element);
            }
        });
    }
    else {
        renderMerk(element);
    }
}

function renderMerk(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Merk').hide());
    $.each(arrMerk, function (i, val) {
        $option.append($('<option/>').val(val.id_merk).text(val.merk))
    });
}

LoadMerk($('#MerkOption'))

function GetById(id) {
    //debugger;
    $.ajax({
        url: "/cars/GetById/",
        data: { id: id }
    }).then((result) => {
        //debugger;
        $('#Id').val(result.id_car);
        $('#Name').val(result.nm_car);
        $('#Year').val(result.year);
        $('#Transmisi').val(result.transmition);
        $('#MerkOption').val(result.merkID);
        $('#add').hide();
        $('#update').show();
        $('#myModal').modal('show');
    })
}

function Save() {
    //debugger;
    var Car = new Object();
    Car.nm_car = $('#Name').val();
    Car.transmition = $('#Transmisi').val();
    Car.year = $('#Year').val();
    Car.merkID = $('#MerkOption').val();
    $.ajax({
        type: 'POST',
        url: "/cars/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Car
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
    var Car = new Object();
    Car.id_car = $('#Id').val();
    Car.nm_car = $('#Name').val();
    Car.transmition = $('#Transmisi').val();
    Car.year = $('#Year').val();
    Car.merkID = $('#MerkOption').val();
    $.ajax({
        type: 'POST',
        url: "/cars/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Car
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
                url: "/cars/Delete/",
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