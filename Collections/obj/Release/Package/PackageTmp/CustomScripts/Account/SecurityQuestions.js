var CommonModel = {};
var SecurityQuestion = {};
$(document).ready(function () {
    Binddropdown();
    $('#btnProceed').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        SaveSecurityData();
    });
    $("#ddlSecurity").change(function () {
        var QuestionId = $('#ddlSecurity option:selected').val();
        ReBindSecurity(QuestionId);
    });
    $("#ddlSecurity1").change(function () {
        var Question1Id = $('#ddlSecurity1 option:selected').val();
        var QuestionId = $('#ddlSecurity option:selected').val();
        ReBindSecurity1(QuestionId, Question1Id);
    });
});

function Binddropdown() {
    var Type = "ddlSecurity";
    $.ajax({
        url: "/Account/BindAllDropdownlist/?drpType=" + Type,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response._Collection_Models_list != null) {
                $('#ddlSecurity').empty().append('<option selected="selected" value="0">Select Security Question 1</option>');
                $('#ddlSecurity1').empty().append('<option selected="selected" value="0">Select Security Question 2</option>');
                $('#ddlSecurity2').empty().append('<option selected="selected" value="0">Select Security Question 3</option>');
                    $.each(response._Collection_Models_list, function (key, value) {
                        $('#ddlSecurity').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                        $('#ddlSecurity1').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                        $('#ddlSecurity2').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                    });
            }
        }
    });
    
}
function ReBindSecurity(Id) {
    var Type = "ddlSecurity";
    $.ajax({
        url: "/Account/BindAllDropdownlist/?drpType=" + Type,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response._Collection_Models_list != null) {
                $('#ddlSecurity1').empty().append('<option selected="selected" value="0">Select Security Question 2</option>');
                $('#ddlSecurity2').empty().append('<option selected="selected" value="0">Select Security Question 3</option>');
                $.each(response._Collection_Models_list, function (key, value) {
                    $('#ddlSecurity1').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                    $('#ddlSecurity2').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                    $('#ddlSecurity1 option[value=' + Id + ']').remove();
                    $('#ddlSecurity2 option[value=' + Id + ']').remove();
                });
            }
        }
    });

}
function ReBindSecurity1(Id,Id1) {
    var Type = "ddlSecurity";
    $.ajax({
        url: "/Account/BindAllDropdownlist/?drpType=" + Type,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response._Collection_Models_list != null) {
                //$('#ddlSecurity1').empty().append('<option selected="selected" value="0">Select Security Question 2</option>');
                $('#ddlSecurity2').empty().append('<option selected="selected" value="0">Select Security Question 3</option>');
                $.each(response._Collection_Models_list, function (key, value) {
                    //$('#ddlSecurity1').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                    $('#ddlSecurity2').append('<option value="' + value.Id + '">' + value.Type + '</option>');
                    $('#ddlSecurity2 option[value=' + Id + ']').remove();
                    $('#ddlSecurity2 option[value=' + Id1 + ']').remove();
                });
            }
        }
    });

}
function SaveSecurityData() {
    if (validateField(true)) {
        SecurityQuestion = {
            sqSecAns1: $("#txtAnswer").val(),
            sqSecAns2: $("#txtAnswer1").val(),
            sqSecAns3: $("#txtAnswer2").val(),
            sqSecQues1: $("#ddlSecurity option:selected").text(),
            sqSecQues2: $("#ddlSecurity1 option:selected").text(),
            sqSecQues3: $("#ddlSecurity2 option:selected").text()
        }
        $.ajax({
            url: "/Account/Security",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(SecurityQuestion),
            success: function (response) {
                if (response[0].Message == "Security_saved_successfully") {
                    alert("Security saved successfully");
                    window.location.href = "/Account/Reset";
                    return true;
                }
                else if (response[0].Message == "Updated_Successfully") {
                    alert("Security updated successfully");
                    window.location.href = "/Account/Reset";
                    return true;
                }
                else {
                    alert("Security not saved");
                    window.location.href = "/Account/Security";
                    return false;
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
function validateField() {
    var isValid = true;
    if ($("#ddlSecurity option:selected").val() == 0 || $("#ddlSecurity option:selected").val() == "" || $("#ddlSecurity option:selected").val() == undefined) {
        $('#ddlSecurity').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlSecurity').css('border-color', 'lightgrey');
    }
    if ($("#ddlSecurity1 option:selected").val() == 0 || $("#ddlSecurity1 option:selected").val() == "" || $("#ddlSecurity1 option:selected").val() == undefined) {
        $('#ddlSecurity1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlSecurity1').css('border-color', 'lightgrey');
    }
    if ($("#ddlSecurity2 option:selected").val() == 0 || $("#ddlSecurity2 option:selected").val() == "" || $("#ddlSecurity2 option:selected").val() == undefined) {
        $('#ddlSecurity2').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlSecurity2').css('border-color', 'lightgrey');
    }
    if ($("#txtAnswer").val() == null || $("#txtAnswer").val() == "" || $("#txtAnswer").val() == undefined) {
        $('#txtAnswer').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtAnswer').css('border-color', 'lightgrey');
    }
    if ($("#txtAnswer1").val() == null || $("#txtAnswer1").val() == "" || $("#txtAnswer1").val() == undefined) {
        $('#txtAnswer1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtAnswer1').css('border-color', 'lightgrey');
    }
    if ($("#txtAnswer2").val() == null || $("#txtAnswer2").val() == "" || $("#txtAnswer2").val() == undefined) {
        $('#txtAnswer2').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtAnswer2').css('border-color', 'lightgrey');
    }

    return isValid;
}