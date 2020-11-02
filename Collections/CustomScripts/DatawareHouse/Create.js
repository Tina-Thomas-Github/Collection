var MasterData = {};
var CommonModel = {};
$(document).ready(function () {
    BindData();
    $('#btnSubmit').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        AddCampaign();
    });
    $('#btnClear').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        ClearFields();
    });
});

function BindData() {
    MasterData = {
        Operation: "list"
    };
    $.ajax({
        url: "/DataWarehouse/Create",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(MasterData),
        success: function (result) {
            if ($.fn.DataTable.isDataTable('#table_id')) {
                $('#table_id').DataTable().destroy();
            }
            $('#table_id tbody').empty();
            $.each(result, function (key, item) {
                $('<tr>').html("<td>" + item.cust_no
                    + "</td><td>" + item.cust_name
                    + "</td><td>" + item.email_address
                    + "</td><td>" + item.phone_no
                    + "</td><td>" + item.RevisedDue
                    + "</td><td>" + item.ExitType
                    + '</td><td class="action"><a href=""><img src="~/Images/vendors/edit.svg" /></a> <a href=""><img src="~/Images/vendors/delete.svg" /></a>&nbsp;&nbsp;&nbsp;'
                    + '<a href="#" onclick="return DeleteData(' + item.cust_no + ')" style="color:grey;" ><i class="cstm_trash"></i></a>'
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