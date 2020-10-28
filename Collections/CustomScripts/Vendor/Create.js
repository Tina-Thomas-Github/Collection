var InvestmentFormModel = {};
var CommonModel = {};

$(document).ready(function () {
    BindData();
    //Binddropdown();
    $('#btnSubmit').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        AddInvestmentForm();
    });

    $('#btnClear').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        ClearFields();
    });

    $('.close').click(function (e) {
        ClearFields();
    });

    //$(".loader").fadeOut("slow");
});

function BindData() {
    InvestmentFormModel = {
        Operation: "list"
    };
    $.ajax({
        url: "/Vendor/CRUD_InvestmentFormMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(InvestmentFormModel),
        success: function (result) {
            if ($.fn.DataTable.isDataTable('#table_id')) {
                $('#table_id').DataTable().destroy();
            }
            $('#table_id tbody').empty();
            $.each(result, function (key, item) {
                $('<tr>').html("<td class='hide'>" + item.ID
                    + "</td><td>" + ""//rowIndex
                    + "</td><td>" + item.CustomerNo
                    + "</td><td>" + item.CustomerName
                    + "</td><td>" + item.PhoneNo
                    + "</td><td>" + item.RevisedDue
                    + "</td><td>" + item.ExitTYpe
                    //+ "</td><td>" + item.ModelStatus
                    + "</td>"
                    + '<td><a class="btn btn -default btn - split btn- sm" href="#" onclick="return Editdata(' + item.InvestmentTypeID + ')" style="border: 1px solid; " ><i class="fa fa - pen"></i> Edit</a>'
                    //| <a class="btn btn -default btn - split btn - sm" href="#" onclick="DeleteData(' + item.Segment_id + ')" style="border: 1px solid; "><i class="fa fa - trash"></i> Delete</a>
                    +"</td>"
                ).appendTo('#table_id');
            });

            var table = $("#table_id").DataTable({
                //destroy: true,
                //dom: "<'row'<'col-md-6'l><'col-md-6'Bf>>" +
                //    "<'row'<'col-md-6'><'col-md-6'>>" +
                //    "<'row'<'col-md-12't>><'row'<'col-md-12'ip>>",
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
                rownumbers: true,
                responsive: {
                    details: {
                        type: 'column',
                        target: 'tr'
                    }
                },
                //columnDefs: [{
                //    searchable: false,
                //    orderable: false,
                //    targets: 0
                //}],
                order: [1, 'asc']
            });

            $(document).ready(function () {
                var groupColumn = 2;
                var table = $('#example').DataTable({
                    "columnDefs": [
                        { "visible": false, "targets": groupColumn }
                    ],
                    "order": [[groupColumn, 'asc']],
                    "displayLength": 25,
                    "drawCallback": function (settings) {
                        var api = this.api();
                        var rows = api.rows({ page: 'current' }).nodes();
                        var last = null;

                        api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                            if (last !== group) {
                                $(rows).eq(i).before(
                                    '<tr class="group"><td colspan="5">' + group + '</td></tr>'
                                );

                                last = group;
                            }
                        });
                    }
                });

                // Order by the grouping
                $('#example tbody').on('click', 'tr.group', function () {
                    var currentOrder = table.order()[0];
                    if (currentOrder[0] === groupColumn && currentOrder[1] === 'asc') {
                        table.order([groupColumn, 'desc']).draw();
                    }
                    else {
                        table.order([groupColumn, 'asc']).draw();
                    }
                });
            });


            //table.on('order.dt search.dt', function () {
            //    table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            //        cell.innerHTML = i + 1;
            //    });
            //}).draw();
            //$('#table_id th:nth-child(1)').hide();
            //$('#table_id td:nth-child(1)').hide();
            //$('.buttons-excel').addClass('btn btn-success');
            $("#viewclient").css("display", "block");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); 
}

function AddInvestmentForm() {
    if (validateField(true)) {
        var chkflag = false;
        if ($('#chkstatus').is(":checked")) {
             chkflag = true;
        }
        
        InvestmentFormModel = {
            InvestmentTypeID: $("#hdninvtypeid").val(),
            InvestmentType: $("#txtInvestmentType").val(),
            IsActive: chkflag,
            Operation: "add"
        };
        $.ajax({
            url: "/Master/CRUD_InvestmentFormMaster",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(InvestmentFormModel),
            success: function (response) {
                //$(".loader").fadeOut("slow");
                if (response[0].Message.toLowerCase() == "Investment Form already exists") {
                    bootbox.alert(response[0].Message);
                    return false;
                }
                else {
                    bootbox.alert({
                        message: response[0].Message,
                        callback: function () {
                            ClearFields();
                            BindData();
                            $('#InvestmentFormMaster').modal('hide');
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

function Edit(id) {
    //$(".loader").fadeIn("slow");
    //ClearFields();
    $('#InvestmentFormMaster').modal('show');
    
    InvestmentFormModel = {
        InvestmentTypeID: id,
        Opertion: "edit"
    };
        $.ajax({
            url: "/Master/CRUD_InvestmentFormMaster",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(InvestmentFormModel),
            success: function (response) {
                // $(".loader").fadeOut("slow");
                $('#hdninvtypeid').val(response[0].InvestmentTypeID);
                $('#txtInvestmentType').val(response[0].InvestmentType);
                var chkflag = false;
                if (response[0].IsActive) {
                     chkflag = true;
                }
                $('#chkstatus').attr('checked', chkflag);
             
               
               $('#InvestmentFormMaster').modal('show');
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
    InvestmentFormModel = {
        InvestmentTypeID: id,
        Opertion: "delete"
    };
    $.ajax({
        url: "/Master/CRUD_InvestmentFormMaster",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(InvestmentFormModel),
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

function ClearFields() {
    $("#txtInvestmentType").val('');
    $('#txtInvestmentType').css('border-color', 'lightgrey');
    
    $('#hdninvtypeid').val('');
    $('#chkstatus').attr('checked', true);
}

function validateField() {
    var isValid = true;
    if ($("#txtInvestmentType").val() == null || $("#txtInvestmentType").val() == "" || $("#txtInvestmentType").val() == undefined) {
        $('#txtInvestmentType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtInvestmentType').css('border-color', 'lightgrey');
    }
    
    return isValid;
}

function Editdata(id) {
    bootbox.confirm({
        message: "Are you sure you want to edit?",
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
                Edit(id);
            }
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