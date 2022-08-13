
$(document).ready(function () {
    var parsleyConfig = {
        errorsContainer: function (parsleyField) {
            if (parsleyField["domOptions"].errorMessage == "Password is required") {
                var fieldSet = parsleyField.$element.closest('form');
                console.log(fieldSet);
                if (fieldSet.length > 0) {
                    return fieldSet.find('#errors-field');
                }
            }
            return parsleyField;
        }
    };
    $('#form-login').parsley(parsleyConfig);
});
$(".toggle-password").click(function () {
    $(this).toggleClass("fa-eye-slash fa-eye");
    var input = $($(this).attr("toggle"));
    if ($("#Password").attr("type") == "password") {
        $("#Password").attr("type", "text");
    } else {
        $("#Password").attr("type", "password");
    }
});


document.getElementById("form-login").onsubmit = function (e) { loginFunc(e) };

function loginFunc(e){
    e.preventDefault();
    var isValid = true;
    console.log(e);
    $('#form-login').each(function () {
        if ($(this).parsley().validate() !== true) {
            isValid = false;
        }
    });
            
    if (isValid) {
        var formData = new FormData(document.getElementById('form-login'));
        var rememberMe = document.querySelector('#remember').checked;
        formData.append("RememberMe", rememberMe);
        $.ajax({
            url: "/Auth/Login",
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            success: function (result) {
                console.log(result);
                window.location.href = result;
            },
            error: function (error) {
                var errorText = "You have entered an invalid email or password";
                Swal.fire({
                    icon: "error",
                    title: "Oops",
                    text: errorText,
                }).then((result) => {
                
                });
            }
        });
    }
}