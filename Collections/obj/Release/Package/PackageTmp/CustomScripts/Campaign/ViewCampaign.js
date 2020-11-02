var Campaign = {};
var CommonModel = {};
var MasterData = {};

$(document).ready(function () {
    BindData();
});

function BindData() {
    Campaign = {
        Operation: "list"
    };
    $.ajax({
        url: "/Campaign/ViewCampaign",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(Campaign),
        success: function (result) {
            $('#card_id').empty();
            $.each(result, function (key, item) {
                var url = '/home/dashboard';
                var html = '<div class="col-md-3"><div class="box active"><div class="top_section cardtitle">';
                html += '<span class="strt_date">' + item.StartDate.slice(0, 10) + '</span>';
                //html += '</span>';
                //html += '<span class="time">' + item.StartTime;
                html += '<span class="time"><div class="button_vendor">Vendor';
                html += '<i class="fa fa-users" aria-hidden="true"></i><span class="badge">' + item.VendorCount;
                html += '</span></div></span></div>';
                html += '<div class="middle_section"><small data-toggle="tooltip" data-placement="top" title="' + item.CampaignName;
                html += '">' + item.CampaignName;
                html += '</small><h3 class="cardheader">' + item.CustomerCount;
                html += '</h3></div><div class="bottom_section"><div class="upload_cstm"><label class="control-label strt_upload">Upload</label>';
                //html += '<i class="fa fa-users" aria-hidden="true"></i><span class="badge">' + item.VendorCount;
                html += '<input class="form-control" type="file" id="FileUpload" accept=".xlsx" />';
                html += '<div class="detail_button" id="button_' + item.CampaignName+'" onclick=ViewCustomer(id)><a href="#">View Details</a>';
                html += '</div></div>';   
                $('#card_id').append(html);
            });
        }
    });
}

function ViewCustomer(id) {
    MasterData = {
        Operation: "tablename"
    };
    var tablename = id.slice(7);
    $.ajax({
        url: "/Campaign/Customer/?tablename=" + tablename,
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
                $('<tr>').html("<td class='hide'>" + item.cust_no
                    + "</td><td>" + ""//rowIndex
                    + "</td><td>" + item.cust_no
                    + "</td><td>" + item.cust_name
                    + "</td><td>" + item.phone_no
                    + "</td><td>" + item.RevisedDue
                    + "</td><td>" + item.ExitType
                    //+ "</td><td>" + item.ModelStatus
                    + "</td>"
                    + '<td><a class="btn btn -default btn - split btn- sm" href="#" onclick="return Editdata(' + item.cust_no + ')" style="border: 1px solid; " ><i class="fa fa - pen"></i> Edit</a>'
                    //| <a class="btn btn -default btn - split btn - sm" href="#" onclick="DeleteData(' + item.Segment_id + ')" style="border: 1px solid; "><i class="fa fa - trash"></i> Delete</a>
                    + "</td>"
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
            $("#viewclient").css("display", "block");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }