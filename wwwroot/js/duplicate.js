let statusNote = "";

$(document).ready(function () {
    //add select nav active
    localStorage.setItem("isStoreValid", true);
    $("#transactionNav").addClass("active");
    $("#transactionNav").find(".snw-menu").addClass("active");
    var duplicate = localStorage.getItem("possibleDuplicateList");
    var invoiceDate = localStorage.getItem("invoiceDate");
    var invoiceNumber = localStorage.getItem("invoiceNumber");
    var zoomCurrent = document.getElementById("zoomCurrent");
    var currentImage = document.getElementById("invoiceCurrentSrc").value;
    zoomCurrent.getElementsByTagName('img')[0].src = `/${currentImage}`;
    $('#zoomDuplicateTop').find('img').imageZoom({ zoom: 300 });

    var date = new Date(invoiceDate);
    const month = date.toLocaleString('default', {month: 'long' });
    const dateString = date.getDate();
    const year = date.getFullYear();
    var dateInvoice = `${month}, ${dateString} ${year}`;
    document.getElementById("totalAmountSpan").innerHTML = ": RM " + localStorage.getItem("totalAmount");
    document.getElementById("dateInvoiceSpan").innerHTML = ": " + dateInvoice;
    document.getElementById("numberInvoiceSpan").innerHTML = ": " + invoiceNumber;
    var duplicateJson = JSON.parse(duplicate);
    $('#DuplicateGrid').dxDataGrid({
        dataSource: duplicateJson,
    });
});

var rad = document.getElementsByName("StatusNote");
var prev = null;
for (var i = 0; i < rad.length; i++) {
    rad[i].addEventListener('change', function () {
        if (this !== prev) {
            prev = this;
        }
        if (this.value == "Other") {
            $("#rejectComment").removeClass("d-none");
        } else {
            $("#rejectComment").addClass("d-none");

        }
        statusNote = this.value;
    });
}

function ViewPossible(e){
    console.log(e.row.data);
    var zoomDuplicate = document.getElementById("zoomDuplicate");
    zoomDuplicate.getElementsByTagName('img')[0].src = `/${e.row.data["invoiceImage"]}`;

    $('#zoomCurrent').find('img').imageZoom({ zoom: 300 });
    $('#zoomDuplicate').find('img').imageZoom({ zoom: 300 });
    $('#duplicateModal').modal('toggle');
}

function postVerify(statusId) {
    var item = localStorage.getItem("itemList");
    var newItemJson = JSON.parse(item);

    var TransactionsId = document.getElementById('transactionId').value;
    var invoiceDate = localStorage.getItem("invoiceDate");
    var dateValue = new Date(invoiceDate);
    var invoiceDate = null;
    var invoiceNumber = localStorage.getItem("invoiceNumber");
    if (dateValue) {
        invoiceDate = dateValue.toJSON();
    }
    var InvoiceTotal = 0;
    if (newItemJson) {
        InvoiceTotal = newItemJson.map(e => e.totalPrice).reduce((a, b) => b + a);
    }
    var StatusNote = statusNote;

    if (statusNote == "Other") {
        StatusNote = $("#rejectComment").val();
    }
    console.log(StatusNote);
    var data = {
        acceptAnyway: true,
        transactionsId: parseInt(TransactionsId),
        invoiceDate: invoiceDate,
        invoiceTotal: InvoiceTotal,
        statusId: statusId,
        statusNote: StatusNote,
        invoiceNumber: invoiceNumber,
        products: newItemJson,
        isStoreValid: true
    }
    console.log(JSON.stringify(data));
    Swal.fire({
        text: 'Loading..',
        allowOutsideClick: false,
        onBeforeOpen: () => {
            Swal.showLoading()
        }
    })
    var resultMessage = "Accepted";
    if (statusId == 3) {
        resultMessage = "Rejected";
    }
    $.ajax({
        url: "/Verificator/VerifyTransaction",
        data: JSON.stringify(data),
        contentType: "application/json",
        processData: false,
        type: 'POST',
        success: function (result) {
            console.log(result);
            if (result.data.isProcessed) {
                Swal.fire({
                    title: "Success",
                    icon: "success",
                    text: "Entry " + resultMessage,
                }).then((result) => {
                    localStorage.clear();
                    window.location.href = "/admin/transaction/";
                });
            }
        },
        error: function (error) {
            var errorText = "An error has occurred. Please try again!";
            console.log(error);
            Swal.fire({
                icon: "error",
                title: "Oops",
                text: errorText,
            }).then((result) => {
            });
        }
    });
}
function rejectSubmit() {
    postVerify(3);
}
function clickAccept() {
    Swal.fire({
        title: 'Confirmation',
        text: "Are you sure to accept this entry?",
        icon: "question",
        showCancelButton: true,
        confirmButtonText: 'Yes',
    }).then((result) => {
        if (result.value) {
            postVerify(2);
        }
    });
}
function clickReject() {
    Swal.fire({
        title: 'Confirmation',
        text: "Are you sure to reject this entry?",
        icon: "question",
        showCancelButton: true,
        confirmButtonText: 'Yes',
    }).then((result) => {
        if (result.value) {
            $('#rejectedModal').modal('toggle');
        }
    });
}
