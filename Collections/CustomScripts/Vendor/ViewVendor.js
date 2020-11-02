var Vendor = {};
var CommonModel = {};
$(document).ready(function () {
    BindData();
    $('#btnSubmit').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        AddVendor();
    });
    $('#btnClear').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        ClearFields();
    });
    $('.close').click(function (e) {
        ClearFields();
    });
});

function BindData() {
    Vendor = {
        Operation: "list"
    };
    $.ajax({
        url: "/Vendor/CRUD_Vendor",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(Vendor),
        success: function (result) {
            if ($.fn.DataTable.isDataTable('#table_id')) {
                $('#table_id').DataTable().destroy();
            }
            $('#table_id tbody').empty();
            $.each(result, function (key, item) {
                $('<tr>').html("<td>" + item.VendorName
                    + "</td><td>" + item.VendorShortName
                    + "</td><td>" + item.ModelStatus
                    + '</td><td class="cstm_btn_a"><a href="#" onclick="return Editdata(' + item.VendorId + ')" style="color:grey;" ><i class="cstm_edit"></i></a>&nbsp;&nbsp;&nbsp;'
                    + '<a href="#" onclick="return DeleteData(' + item.VendorId + ')" style="color:grey;" ><i class="cstm_trash"></i></a>'
                    + "</td>"
                ).appendTo('#table_id');
            });

            var table = $("#table_id").DataTable({
                dom: "<'row'<'col-md-6'l><'col-md-6'Bf>>" +
                    "<'row'<'col-md-6'><'col-md-6'>>" +
                    "<'row'<'col-md-12't>><'row'<'col-md-12'ip>>",

                buttons: [
                    {
                        extend: 'excel',
                        text: 'Export Excel',
                        className: 'exportExcel',
                        filename: 'Segment list',
                        exportOptions: {
                            modifier: {
                                page: 'all'
                            }
                        }
                    }
                ],
                responsive: {
                    details: {
                        type: 'column',
                        target: 'tr'
                    }
                },
                order: [1, 'asc']
            });
            $('.buttons-excel').addClass('btn btn-default');
            $("#viewclient").css("display", "block");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function AddVendor() {
    if (validateField(true)) {
        var chkflag = false;
        if ($('#chkstatus').is(":checked")) {
            chkflag = true;
        }
        Vendor = {
                VendorId: $("#hdnVendorID").val(),
                VendorName: $("#txtVendorName").val(),
                VendorShortName: $("#txtVendorShortName").val(),
                IsActive: chkflag,
                Operation: "add"
        }
        $.ajax({
            url: "/Vendor/CRUD_Vendor",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(Vendor),
            success: function (response) {
                if (response[0].Message.toLowerCase() == "Vendor Details already exists") {
                    bootbox.alert(response[0].Message);
                    return false;
                }
                else {
                    $('#VendorForm').modal('hide');
                    BindData();
                    bootbox.alert({
                        message: response[0].Message,
                        callback: function () {
                            ClearFields();
                        }
                    });
                    return true;
                }
            },
            error: function (response) {
                $(".loader").fadeOut("slow");
                window.location.href = "/Account/Login";
            },
            failure: function (response) {
                waitingDialog.hide();
                window.location.href = "/Account/Login";
            }
        });
    }
}

function ClearFields() {
    $('#hdnVendorID').val('');
    $("#txtVendorName").val('');
    $('#txtVendorName').css('border-color', 'lightgrey');
    $('#txtVendorName').attr('readonly');
    $("#txtVendorShortName").val('');
    $('#txtVendorShortName').css('border-color', 'lightgrey');
    $('#txtVendorShortName').attr('readonly');
    $('#chkstatus').attr('checked', false);
}
function validateField() {
    var isValid = true;
        if ($("#txtVendorName").val() == null || $("#txtVendorName").val() == "" || $("#txtVendorName").val() == undefined) {
            $('#txtVendorName').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#txtVendorName').css('border-color', 'lightgrey');
        }
    if ($("#txtVendorShortName").val() == null || $("#txtVendorShortName").val() == "" || $("#txtVendorShortName").val() == undefined) {
        $('#txtVendorShortName').css('border-color', 'Red');
            isValid = false;
        }
        else {
        $('#txtVendorShortName').css('border-color', 'lightgrey');
        }
    return isValid;
}

function Editdata(id) {
    bootbox.confirm({
        message: "Are you sure you want to edit?",
        buttons: {
            confirm: {
                id: 'btnYes',
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result == true) {
                Edit(id);
            }
        }
    });
}
function Edit(id) {
    $('#VendorForm').modal('show');
    var chkflag = false;
    Vendor = {
        VendorID: id,
        Operation: "edit"
    };
    $.ajax({
        url: "/Vendor/CRUD_Vendor",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(Vendor),
        success: function (response) {
            $('#hdnVendorID').val(response[0].VendorId);
            if (response[0].IsActive==1) {
                chkflag = true;
            }
            $('#chkstatus').attr('checked', chkflag);
            $('#txtVendorName').val(response[0].VendorName);
            $('#txtVendorShortName').val(response[0].VendorShortName);
            $('#VendorForm').modal('show');
        },
        error: function (response) {
            $(".loader").fadeOut("slow");
            window.location.href = "/Account/Login";
        },
        failure: function (response) {
            $(".loader").fadeOut("slow");
            window.location.href = "/Account/Login";
        }
    });
}

function Delete(id) {
    //$(".loader").fadeIn("slow");
    Vendor = {
        VendorId: id,
        Operation: "delete"
    };
    $.ajax({
        url: "/Vendor/CRUD_Vendor",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(Vendor),
        success: function (response) {
            $(".loader").fadeOut("slow");
            bootbox.alert({
                message: response[0].Message,
                callback: function () {
                    BindData();
                }
            });
            return true;
        },
        error: function (response) {
            $(".loader").fadeOut("slow");
            window.location.href = "/Account/Login";
        },
        failure: function (response) {
            $(".loader").fadeOut("slow");
            window.location.href = "/Account/Login";
        }
    });
}
function DeleteData(id) {
    bootbox.confirm({
        message: "Are you sure you want to delete?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result == true) {
                Delete(id);
            }
        }
    });
}