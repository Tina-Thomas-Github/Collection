var Campaign = {};
var CommonModel = {};
$(document).ready(function () {
    Binddropdown();
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

function Binddropdown() {
    var Type = "dllVendor";
    $.ajax({
        url: "/Campaign/BindAllDrodownlist/?drpType=" + Type,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response._Collection_Models_list != null) {
                $('#dllVendor').empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response._Collection_Models_list, function (key, value) {
                    $('#dllVendor').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                });
            }
        }
    });
}
function AddCampaign() {
    //if (validateField(true)) {
    var formData = new FormData();

    //formData.append("SchemeConfigID", $("#hdnSchemeConfigID").val());
    formData.append("CampaignName", $("#txtCampaignName").val());
    formData.append("StartDate", $("#txtStartDate").val());
    formData.append("StartTime", $("#txtStartTime").val());
    formData.append("Vendor", $("#dllVendor option:selected").text());

    //formData.append("FieldParamter", multiSelect);
    formData.append("FileName", document.getElementById("FileUpload").files[0].name);
    formData.append("FilePath", document.getElementById("FileUpload").files[0]);
    formData.append("contentType", 'content/pdf');
    //formData.append("IsActive", chkflag);
    formData.append("Opertion", 'add');



    //Campaign= {
    //    //CampaignID: $("#hdnCampaignId").val(),
    //    CampaignName: $("#txtCampaignName").val(),
    //    StartDate: $("#txtStartDate").val(),
    //    StartTime: $("#txtStartTime").val(),
    //    Vendor: $("#dllVendor option: selected").val(),
    //        //IsActive: chkflag,
    //        Operation: "add"
     //   };
        $.ajax({
            url: "/Campaign/Create",
            type: "POST",
            //contentType: "application/json;charset=utf-8",
            contentType: false,
            processData: false,
            dataType: "json",
            //data: JSON.stringify(Campaign),
            data: formData,
            success: function (response) {
                //$(".loader").fadeOut("slow");
                if (response[0].Message.toLowerCase() == "campaign file uploaded successfully") {
                    bootbox.alert(response[0].Message);
                    ClearFields();
                    return true;
                }
                //else {
                //    bootbox.alert({
                //        message: response[0].Message,
                //        callback: function () {
                //            ClearFields();
                //            //BindData();
                //            //$('#SchemeFormMaster').modal('hide');
                //        }
                //    });
                //    return true;
                //}
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
    //}
}
function ClearFields() {
    window.location.href = "/Campaign/Create";
    return true;
}
function validateField() {
    var isValid = true;
    if ($("#ddlInvestmentType option:selected").val() == 0 || $("#ddlInvestmentType option:selected").val() == "" || $("#ddlInvestmentType option:selected").val() == undefined) {
        $('#ddlInvestmentType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlInvestmentType').css('border-color', 'lightgrey');
    }
    if ($("#txtSchemeCategory").val() == null || $("#txtSchemeCategory").val() == "" || $("#txtSchemeCategory").val() == undefined) {
        $('#txtSchemeCategory').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtSchemeCategory').css('border-color', 'lightgrey');
    }
    if ($("#txtSchemeFormName").val() == null || $("#txtSchemeFormName").val() == "" || $("#txtSchemeFormName").val() == undefined) {
        $('#txtSchemeFormName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtSchemeFormName').css('border-color', 'lightgrey');
    }

    return isValid;
}
