var Campaign = {};
var CommonModel = {};

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
                html += '<span class="strt_date">' + item.StartDate.slice(0,10);
                html += '</span>';
                html += '<span class="time">' + item.StartTime;
                html += '</span></div>';
                html += '<div class="middle_section"><small data-toggle="tooltip" data-placement="top" title="' + item.CampaignName;
                html += '">' + item.CampaignName;
                html += '</small><h3 class="cardheader">' + item.CustomerCount;
                html += '</h3></div><div class="bottom_section"> <div class="button_vendor">Vendor';
                html += '<i class="fa fa-users" aria-hidden="true"></i><span class="badge">' + item.VendorCount;
                html += '</span></div><div class="detail_button"><a href="/Home/Dashboard"> View Details</a>';
                html += '</div></div></div></div>';   
                $('#card_id').append(html);
            });








            //var html = '<div class="box">';
            //html += '<div class="top_section cardtitle">';
            //html += '<div class="middle_sectionuserimg"> </div>';
            //html += '<div class="col-md-8 px-3">';
            //html += '<div class="card-block px-3">';
            //html += '<h4 class="middle_section cardheader"> </h4>';
            ////html += '<h4 class="card-title cardheader"> </h4>';
            //html += '<h4 class="bottom_section badge cardsubheader"> </h4>';
            //html += '</div>';
            //html += '</div>';
            //html += '</div>';
            ////html += '</div>';
            //html += '</div>';

            //for (var i = 0; i < result.length; i++) {
            //    $('#card_id').append(html);
            //    //uimg = result[i].CustomerName;
            //    var $img = result[i].CampaignName;//uimg;
            //    $(".userimg:eq(" + i + ")").append($img);

            //    var $cardt = result[i].StartDate;
            //    $(".cardtitle:eq(" + i + ")").append($cardt);

            //    var $cardheader = result[i].CustomerCount;
            //    $(".cardheader:eq(" + i + ")").append($cardheader);

            //    var $cardsubheader = result[i].VendorCount;;
            //    $(".cardsubheader:eq(" + i + ")").append($cardsubheader);

            //}
        }
    });
}
function ViewCustomer() {
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
                $("#viewclient").css("display", "block");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}