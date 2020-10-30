var Vendor = {};
var CommonModel = {};
$(document).ready(function () {
    //BindData();
    $('#btnSubmit').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        SendMail();
    });
    //$('#btnClear').click(function (e) {
    //    e.preventDefault();
    //    e.stopPropagation();
    //    ClearFields();
    //});
    //$('.close').click(function (e) {
    //    ClearFields();
    //});
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
                responsive: {
                    details: {
                        type: 'column',
                        target: 'tr'
                    }
                },
                order: [1, 'asc']
            });
            $("#viewclient").css("display", "block");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function SendMail() {
    //if (validateField(true)) {
        $.ajax({
            type: "post",
            url: /DataWarehouse/Export,
            data: JSON.stringify({ 'GridHtml': $("#table_id").html() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (Data) {
                if (Data) {
                    //setTimeout(function () {
                    //if (Data.isSend) {
                        bootbox.alert("Data Shared Succesfully.");
                        return false;
                   // }
                    //else {
                        //bootbox.alert("Something went wrong");
                        //return false;
                    //}
                    //});
                }
            }

        });
       
        //Vendor = {
        //        VendorId: $("#hdnVendorID").val(),
        //        VendorName: $("#txtVendorName").val(),
        //        VendorShortName: $("#txtVendorShortName").val(),
        //        IsActive: chkflag,
        //        Operation: "add"
        //}
        //$.ajax({
        //    url: "/Vendor/CRUD_Vendor",
        //    type: "POST",
        //    contentType: "application/json;charset=utf-8",
        //    dataType: "json",
        //    data: JSON.stringify(Vendor),
        //    success: function (response) {
        //        //$(".loader").fadeOut("slow");
        //        if (response[0].Message.toLowerCase() == "Vendor Details already exists") {
        //            bootbox.alert(response[0].Message);
        //            return false;
        //        }
        //        else {
        //            bootbox.alert({
        //                message: response[0].Message,
        //                callback: function () {
        //                    ClearFields();
        //                    BindData();
        //                    $('#VendorForm').modal('hide');
        //                }
        //            });
        //            return true;
        //        }
        //    },
        //    error: function (response) {
        //        $(".loader").fadeOut("slow");
        //        window.location.href = "/Account/Login";
        //    },
        //    failure: function (response) {
        //        waitingDialog.hide();
        //        window.location.href = "/Account/Login";
        //    }
        //});
    }
