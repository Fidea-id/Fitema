$(document).ready(function () {
    //add select nav active
    $("#uploadNav").addClass("active");
    $("#uploadNav").find(".snw-menu").addClass("active");
});

function expandCode(p) {
    if (p.innerText == "See all code") {
        p.innerText = "Hide code";
        $(".prizeTable").removeClass("d-none d-sm-none d-md-none d-lg-block");
        $(".prizeTableMobile").removeClass("d-block d-sm-block d-md-block d-lg-none").addClass("d-none d-sm-none d-md-none d-lg-none");
    } else {
        p.innerText = "See all code";
        $(".prizeTable").addClass("d-none d-sm-none d-md-none d-lg-block");
        $(".prizeTableMobile").removeClass("d-none d-sm-none d-md-none d-lg-none").addClass("d-block d-sm-block d-md-block d-lg-none");
    }
}

function checkValid() {
    var period = document.getElementById('periodSelect').value;
    var fileInput = $('#winnerFile')[0];
    var invoiceImage = fileInput.files[0];
    console.log(invoiceImage);
    console.log(period);
    if (period == "Select Period") return false;
    if (!invoiceImage) {
        console.log("invalid");
        return false;
    }
    return true;
}

$('#btnStep2').click(function () {
    var isValid = checkValid();
    // Get form
    var formData = new FormData();

    if (isValid) {
        var period = document.getElementById('periodSelect').value;
        var fileInput = $('#winnerFile')[0];
        var invoiceImage = fileInput.files[0];

        formData.append("period", period);
        formData.append("spreadsheet", invoiceImage);

        Swal.fire({
            text: 'Loading..',
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
            }
        })
        $.ajax({
            url: "/Announcer/UploadWinner",
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            success: function (result) {
                console.log(result);
                Swal.fire({
                    title: "Thank you!",
                    icon: "success",
                    text: "Success Upload"
                }).then((result) => {
                    window.location.reload(true);
                });
            },
            error: function (error) {
                console.log(error);
                var errorText = "An error has occurred. Please try again!";
                if (error.responseJSON) {
                    errorText = error.responseJSON.message;
                }
                Swal.fire({
                    icon: "error",
                    title: "Oops",
                    text: errorText,
                }).then((result) => {
                });
            }
        });
    } else {
        Swal.fire({
            icon: "error",
            title: "Cannot upload",
            text: "Please select period and use available template to upload winner."
        });
    }
});