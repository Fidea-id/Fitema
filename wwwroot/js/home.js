let slogan = "";

$(document).ready(function () {
    localStorage.clear();
    $('#form-step').parsley();
});
function textInput(e){
    var idChar = "char" + e.id.replace("question", "");
    var count = $(`#${e.id}`).val().length;
    document.getElementById(idChar).innerHTML = count;
}
$('#btnStep1').click(function () {
    var valid = true;
    var listAnswer = [];
    var quiz = new Object;
    var totalQuestion = document.getElementById('totalQuestion').value;
    var ele = document.getElementById('form-quiz').getElementsByTagName('input');

    slogan = $("#question1").val();
    for (i = 0; i < ele.length; i++) {
        if (ele[i].type == "radio") {
            if (ele[i].checked) {
                var value = ele[i].value;
                listAnswer.push(value);
            }
        }
    }

    if (slogan.trim() == "") {
        valid = false;
    }
    if (listAnswer.length != totalQuestion) {
        valid = false;
    }

    if (valid) {
        console.log()
        var param = {
            answer: listAnswer.join(";;")
        };
        quiz.answer = listAnswer.join(";;");
        $.post("/Home/CheckQuiz", param, function (result) {
            document.getElementById('step1').className = "step";
            document.getElementById('step2').className = "step active";
            $("[data-toggle='tooltip']").tooltip('show');
            window.scrollTo(0, 1818);
            if (!result) {
                Swal.fire({
                    icon: "warning",
                    text: "Please fill slogan first before you can continue."
                });
            }
        });
    } else {
        Swal.hideLoading();
        Swal.close();
        Swal.fire({
            icon: "warning",
            text: "Please fill slogan first before you can continue."
        });
    };
});
function prevStep2() {
    document.getElementById('step2').className = "step";
    document.getElementById('step1').className = "step active";
    window.scrollTo(0, 0);
};


function regionChange(selected) {
    var value = selected.selectedItem.Region;
    var param = "?region=" + value;
    $("input[name='Region']").val(value);
    var token = document.querySelector('meta[name="csrf-token"]').content;
    $.ajax({
        url: "/Store/GetStore" + param,
        headers: { 'RequestVerificationToken': token },
        type: 'GET',
        success: function (result) {
            if (result) {
                var array = result.data;
                setStoreSelectBox(array);
            }
        }
    });
}

function setStoreSelectBox(data) {
    $("#storeSelect").dxSelectBox({
        dataSource: data,
    });
}

function storeChange(selected) {
    var item = selected.selectedItem;
    console.log(selected);
    $("input[name='StoreName']").val(item.storeName);
    $("input[name='ARCode']").val(item.arCode);
    var errorStoreField = document.getElementById("parsley-id-13");
    if (errorStoreField) {
        errorStoreField.classList.remove("filled");
        errorStoreField.innerHTML = "";
    }
}

$('#btnStep2').click(function () {
    var isValid = true;
    $('#form-step').each(function () {
        if ($(this).parsley().validate() !== true) {
            isValid = false;
        }
    });
    // Get form
    var formData = new FormData();

    if (isValid) {
        var name = document.getElementById('Name').value;
        var phone = document.getElementById('PhoneNumber').value;
        var email = document.getElementById('Email').value;
        var storeCode = document.getElementById('ARCode').value;
        var storeName = document.getElementById('StoreName').value;
        var region = document.getElementById('Region').value;
        var invoiceImage = $('input[type=file]')[0];
        var fileInput = $('#InvoiceImage')[0];
        var invoiceImage = fileInput.files[0];
        var token = document.querySelector('meta[name="csrf-token"]').content;

        formData.append("name", name);
        formData.append("phoneNumber", phone);
        formData.append("email", email);
        formData.append("storeName", storeName);
        formData.append("region", region);
        formData.append("aRcode", storeCode);
        formData.append("invoiceImage", invoiceImage);
        formData.append("customerSlogan", slogan);

        Swal.fire({
            text: 'Loading..',
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
            }
        })
        $.ajax({
            url: "/Transaction/Submit",
            data: formData,
            headers: { 'RequestVerificationToken': token },
            contentType: false,
            processData: false,
            type: 'POST',
            success: function (result) {
                if (result.message == "Success.") {
                    Swal.fire({
                        title: "Thank you!",
                        icon: "success",
                        text: "We have accepted your participation in the Philips Save and Win Promo"
                    }).then((result) => {
                        window.location.reload(true);
                    });
                } else {
                    Swal.fire({
                        icon: "error",
                        title: "Oops",
                        text: "An error has occurred. Please try again!"
                    }).then((result) => {
                    });
                }
            },
            error: function (error) {
                var errorText = "An error has occurred. Please try again!";
                if (error.responseJSON) {
                    if (error.responseJSON.errors) {
                        if (error.responseJSON.errors.InvoiceImage) {
                            errorText = error.responseJSON.errors.InvoiceImage[0];
                        }
                    }
                } else if (error.statusText == "Request Entity Too Large") {
                    errorText = "Maximum allowed file size is 10MB.";
                }
                Swal.fire({
                    icon: "error",
                    title: "Oops",
                    text: errorText,
                }).then((result) => {
                });
            }
        });
    }
});