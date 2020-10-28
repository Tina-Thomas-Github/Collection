var LoginModel = {};
var CommonModel = {};
$(document).ready(function () {
    $('#btnReset').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        Reset();
    });
});

function Reset() {
    if (validateField(true)) {
        //var userId = '<%= Session["UserID"] %>';
        LoginModel = {
           
            password: $("#txtNewPassword").val(),
            oldPassword: $("#txtOldPassword").val(),
            username: '',
        }
        $.ajax({
            url: "/Account/Reset",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(LoginModel),
            success: function (response) {
                if (response[0].Message == "Password_Updated") {
                    alert("Password Updated");
                    window.location.href = "/Home/Dashboard";
                    return true;
                }
                //else if (response[0].Message == "User_Not_Exist") {
                //    alert("User does not exist");
                //    window.location.href = "/Account/Login";
                //    return false;
                //}
                else {
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
    if ($("#txtOldPassword").val() == null || $("#txtOldPassword").val() == "" || $("#txtOldPassword").val() == undefined) {
        $('#txtOldPassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtOldPassword').css('border-color', 'lightgrey');
    }
    if ($("#txtNewPassword").val() == null || $("#txtNewPassword").val() == "" || $("#txtNewPassword").val() == undefined) {
        $('#txtNewPassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtNewPassword').css('border-color', 'lightgrey');
    }
    if ($("#txtConfirmPassword").val() == null || $("#txtConfirmPassword").val() == "" || $("#txtConfirmPassword").val() == undefined) {
        $('#txtConfirmPassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtConfirmPassword').css('border-color', 'lightgrey');
    }
    return isValid;
}
