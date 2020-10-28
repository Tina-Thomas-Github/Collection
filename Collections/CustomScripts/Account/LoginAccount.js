var LoginModel = {};
var CommonModel = {};
$(document).ready(function () {
    $('#btnLogin').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        Login();
    });
});

function Login() {
    if (validateField(true)) {
       
        LoginModel = {
            username: $("#txtUsername").val(),
            password: $("#txtPassword").val(),
        }
        $.ajax({
            url: "/Account/Login",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(LoginModel),
            success: function (response) {
                if (response[0].Message == "Wrong_Password") {
                    alert("Incorrect Password");
                    window.location.href = "/Account/Login";
                    return false;
                }
                else if (response[0].Message == "User_Not_Exist") {
                    alert("User does not exist");
                    window.location.href = "/Account/Login";
                    return false;
                }
                else {
                    //window.location.href = "/Account/Security";
                    window.location.href = "/Home/Dashboard";
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
    $("#txtUsername").val('');
    $('#txtUsername').css('border-color', 'lightgrey');
    $("#txtPassword").val('');
    $('#txtPassword').css('border-color', 'lightgrey');
}
function validateField() {
    var isValid = true;
    if ($("#txtUsername").val() == null || $("#txtUsername").val() == "" || $("#txtUsername").val() == undefined) {
        $('#txtUsername').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtUsername').css('border-color', 'lightgrey');
    }
    if ($("#txtPassword").val() == null || $("#txtPassword").val() == "" || $("#txtPassword").val() == undefined) {
        $('#txtPassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtPassword').css('border-color', 'lightgrey');
    }
    return isValid;
}
