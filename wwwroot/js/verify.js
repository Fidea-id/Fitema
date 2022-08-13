let idItem = 0;
let itemJson = [];
let statusNote = "";
let selectedItem = [];
let dataProductError;

$(document).ready(function () {
    checkLocalStorage();
    localStorage.clear();
});

function updateTotalBottom() {
    var dxData = $("#ItemDataGrid").dxDataGrid("instance").getDataSource().items();
    var total = 0;
    if (dxData.length > 0) {
        total = dxData.map(e => e.totalPrice).reduce((a, b) => b + a);
    }
    document.getElementById('snw-totalamount-value').innerText = "RM " + total;
}

function getLastIdItem() {
    var dxData = $("#ItemDataGrid").dxDataGrid("instance").getDataSource().items();
    if (dxData.length == 0) {
        return -1;
    } else {
        var id = dxData[dxData.length - 1].id;
        return id;
    }
}

function onRowUpdated(e) {
    updateTotalBottom();
}

function onEditorPreparing(e) {
    if (e.parentType == 'dataRow' && e.dataField == "price") {
        e.editorOptions.min = 0;
    }
    if (e.parentType == 'dataRow' && e.dataField == "qty") {
        e.editorOptions.min = 0;
    }
}

function asyncUpdate(e) {
    var dfd = $.Deferred();
    var data = e.newData;
    var valid = true;
    var message = ""
    if (data.price < 1) {
        valid = false;
        message = "Price must more than 0. You can't submit/continue before resolve this.";
    }
    if (data.qty < 1) {
        valid = false;
        message = "Qty must more than 0. You can't submit/continue before resolve this.";
    }
    if (!valid) {
        setTimeout(function (e) {
            dataProductError = true;
            dfd.reject(message);
        }, Math.floor(1000));
    }
    else {
        setTimeout(function (e) {
            dataProductError = false;
            dfd.resolve(e);
        }, Math.floor(1000));
    }
    return dfd.promise();
}
function asyncInsert(e) {
    var dfd = $.Deferred();
    var data = e.data;
    var valid = true;
    var message = ""
    if (!data.name) {
        valid = false;
        message = "You must fill product. You can't submit/continue before resolve this.";
    }
    if (data.price < 1) {
        valid = false;
        message = "Price must more than 0. You can't submit/continue before resolve this.";
    }
    if (data.qty < 1) {
        valid = false;
        message = "Qty must more than 0. You can't submit/continue before resolve this.";
    }
    if (!valid) {
        setTimeout(function (e) {
            dataProductError = true;
            dfd.reject(message);
        }, Math.floor(100));
    }
    else {
        setTimeout(function (e) {
            dataProductError = false;
            dfd.resolve(e);
        }, Math.floor(100));
    }
    return dfd.promise();
}

function onRowUpdating(e) {
    e.cancel = asyncUpdate(e);
}
function onRowInserting(e) {
    e.cancel = asyncInsert(e);
}

function setCellName(newData, value, currentRowData) {
    $.ajax({
        url: "/Product/GetProductFromKey?key=" + value,
        contentType: "application/json",
        type: 'GET',
        async:false,
        success: function (result) {
            newData.id = getLastIdItem() + 1;
            newData.name = result.name;
            newData._12NC = value;
            if (result.salesPrice == 0 && currentRowData.price > 0) {

            } else {
                newData.price = result.salesPrice;
            }
            newData.qty = currentRowData.qty || 0;
            var total = currentRowData.qty * currentRowData.price;
            newData.totalPrice = total || 0;
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function setCellPrice(newData, value, currentRowData) {
    newData.price = value;
    var total = Math.round((currentRowData.qty * value) * 100) / 100;
    newData.totalPrice = total || 0;
}
function setCellQty(newData, value, currentRowData) {
    newData.qty = value;
    var total = Math.round((currentRowData.price * value) * 100) / 100;
    newData.totalPrice = total || 0;
}

function clickAddItem(e) {
    var dxData = $("#ItemDataGrid").dxDataGrid("instance");
    dxData.addRow();
}

//#region itemPopup
function getDataItem(val) {
    if (val == null) {
        $("#ItemName").dxSelectBox({
            dataSource: null,
        });
    } else {
        $.ajax({
            url: "/Product/GetProduct?key=" + val,
            contentType: "application/json",
            type: 'GET',
            success: function (result) {
                updateItemListData(result.data);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
}

function updateItemListData(data) {
    $("#ItemName").dxSelectBox({
        dataSource: data,
    });
}

function oninput(e) {
    var val = e.element.find(":input:not([type=hidden])")[0].value;
    if (val.length > 1) {
        getDataItem(val);
    } else {
        getDataItem(null);
    }
}

function itemNameOnChange(e) {
    if (e.selectedItem != null) {
        selectedItem = e.selectedItem;
        $("#Price").dxNumberBox({ value: e.selectedItem.salesPrice });
    } else {
        $("#Price").dxNumberBox({ value: null });
    }

    if (checkItemField) {
        $("#errorTextModal").addClass("d-none");
    }
}

function priceOnChange(e) {
    updateTotalPrice();
    if (checkItemField) {
        $("#errorTextModal").addClass("d-none");
    }
}
function qtyOnChange(e) {
    updateTotalPrice();
    if (checkItemField) {
        $("#errorTextModal").addClass("d-none");
    }
}

function clickAddItemPop(e) {
    clearItemInput();
    $('#itemModal').modal('toggle');
}

function EditItem(e) {
    var data = e.row.data;
    $("#ItemId").val(data.id);
    $("#ItemName").dxSelectBox({
        value: selectedItem._12NC
    });
    $("#Price").dxNumberBox({ value: data.price });
    $("#Qty").dxNumberBox({ value: data.qty });
    $("#TotalPrice").dxNumberBox({ value: data.totalPrice });
    var btn = document.getElementById("btnModalItem");
    btn.innerText = 'Edit';
    $('#itemModal').modal('toggle');
}
function DeleteItem(e) {
    var id = e.row.rowIndex;
    itemJson.splice(id,1);
    updateDxDataItem();
}
function clearItemInput() {
    $("#ItemId").val(null);
    $("#ItemName").dxSelectBox({ value: null });
    $("#Price").dxNumberBox({ value: null });
    $("#Qty").dxNumberBox({ value: null });
    $("#TotalPrice").dxNumberBox({ value: null });
}

function updateDxDataItem() {
    $('#ItemDataGridPop').dxDataGrid({
        dataSource: itemJson,
    });
    var total = itemJson.map(e => e.totalPrice).reduce((a, b) => b + a);
    document.getElementById('snw-totalamount-value').innerText = "RM " + total;
}

function updateTotalPrice() {
    var priceInstance = $('#Price').dxNumberBox('instance');
    var qtyInstance = $('#Qty').dxNumberBox('instance');

    var price = priceInstance.option('value'); //Get the current value
    var qty = qtyInstance.option('value'); //Get the current value
    var total = Math.round((price * qty) * 100)/100;

    $("#TotalPrice").dxNumberBox({ value: total });
}

function checkItemField() {
    var itemNameInstance = $('#ItemName').dxSelectBox('instance');
    var priceInstance = $('#Price').dxNumberBox('instance');
    var qtyInstance = $('#Qty').dxNumberBox('instance');

    var itemName = itemNameInstance.option('value'); //Get the current value
    var price = priceInstance.option('value'); //Get the current value
    var qty = qtyInstance.option('value'); //Get the current value

    if (itemName && price && qty) {
        return true;
    }
    return false;
}

function clickSaveItem() {
    var priceInstance = $('#Price').dxNumberBox('instance');
    var qtyInstance = $('#Qty').dxNumberBox('instance');
    var totalPriceInstance = $('#TotalPrice').dxNumberBox('instance');

    var price = priceInstance.option('value'); //Get the current value
    var qty = qtyInstance.option('value'); //Get the current value
    var _totalPrice = totalPriceInstance.option('value'); //Get the current value

    if (_totalPrice && price && qty) {
        updateTotalPrice(); //update total
        var itemId = document.getElementById('ItemId').value;

        var itemName = selectedItem.name;
        var item12NC = selectedItem._12NC;
        var totalPrice = totalPriceInstance.option('value'); //Get the current value
        if (itemId) {
            var itemData = itemJson[itemId];
            itemData.name = itemName;
            itemData._12NC = item12NC;
            itemData.price = price;
            itemData.qty = qty;
            itemData.totalPrice = totalPrice;
        } else {
            var dataString = `{"id":${idItem},"_12NC":${item12NC},"name":"${itemName}","price":${price},"qty":${qty},"totalPrice":${totalPrice}}`;
            const data = JSON.parse(dataString);
            idItem++;
            itemJson.push(data);
        }

        updateDxDataItem();
        clearItemInput();

        var btn = document.getElementById("btnModalItem");
        btn.innerText = 'Add';
        $('#itemModal').modal('toggle');
    } else {
        $("#errorTextModal").removeClass("d-none");
    }
}

function itemListToPost() {
    if (itemJson.length == 0) {
        var dxData = $("#ItemDataGrid").dxDataGrid("instance").getDataSource().items();
        return dxData;
    } else {
        var jsonString = JSON.stringify(toCamel(itemJson));
        var filteredObject = JSON.parse(jsonString, function (k, v) {
            return k === 'id' ? undefined : v;
        });
        return filteredObject;
    }
}
//#endregion

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

function ErrorHandlerDx(e) {
    console.log(e);
}

function convertDateToCSubDate(date) {
    if (date.toString().includes("000Z")) {
        return date;
    } else {
        const year = date.getFullYear();
        const month = ("0" + (date.getMonth() + 1)).slice(-2);
        const dates = ("0" + (date.getDate())).slice(-2);
        var time = ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2);
        return `${year}-${month}-${dates}T${time}.000Z`;
    }
}

function postVerify(statusId) {
    var newItemJson = itemListToPost();
    console.log(newItemJson);

    var TransactionsId = document.getElementById('transactionId').value;
    var dateBox = $("#InvoiceDate").dxDateBox("instance");
    var dateValue = dateBox.option('value');
    var invoiceNumber = $("#InvoiceNumber").dxTextBox("instance").option('value');
    var StatusNote = statusNote;
    var isStoreValid = $("#storeCheckBox").is(":checked");
    var invoiceDate = null;
    if (dateValue) {
        invoiceDate = convertDateToCSubDate(dateValue);
    }
    var InvoiceTotal = 0;
    if (newItemJson.length > 0) {
        InvoiceTotal = newItemJson.map(e => e.totalPrice).reduce((a, b) => b + a);
    }
    if (StatusNote == "Other") {
        StatusNote = $("#rejectComment").val();
    }
    var data = {
        acceptAnyway: false,
        transactionsId: parseInt(TransactionsId),
        invoiceDate: invoiceDate,
        invoiceTotal: InvoiceTotal,
        statusId: statusId,
        statusNote : StatusNote,
        products: newItemJson,
        invoiceNumber: invoiceNumber.trim(),
        isStoreValid: isStoreValid
    }
    Swal.fire({
        text: 'Loading..',
        allowOutsideClick: false,
        onBeforeOpen: () => {
            Swal.showLoading();
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
            if (result.data.isProcessed) {
                Swal.fire({
                    title: "Success",
                    icon: "success",
                    text: "Entry " + resultMessage,
                }).then((result) => {
                    localStorage.clear();
                    window.location.href = "/admin/transaction/";
                });
            } else {
                localStorage.setItem("possibleDuplicateList", JSON.stringify(result.data.possibleDuplicateList));
                localStorage.setItem("itemList", JSON.stringify(newItemJson));
                localStorage.setItem("invoiceDate", '' + invoiceDate);
                localStorage.setItem("invoiceNumber", '' + invoiceNumber);
                localStorage.setItem("totalAmount", '' + InvoiceTotal);
                window.location.href = "/admin/transaction/duplicate/" + TransactionsId;
            }
        },
        error: function (error) {
            console.log(error);
            var errorText = "An error has occurred. Please try again!";
            if (error.responseJSON) {
                if (error.responseJSON.message) {
                    errorText = error.responseJSON.message;
                }
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

function checkLocalStorage() {
    var exist = localStorage.getItem("isStoreValid");
    if (exist) {
        var itemList = localStorage.getItem("itemList");
        var invoiceDate = localStorage.getItem("invoiceDate");
        var invoiceNumber = localStorage.getItem("invoiceNumber");
        var totalAmount = localStorage.getItem("totalAmount");

        $("#InvoiceNumber").dxTextBox({
            value: invoiceNumber
        });

        $("#InvoiceDate").dxDateBox({
            value: invoiceDate
        });
        //storeCheckBox
        document.getElementById('snw-totalamount-value').innerText = "RM " + totalAmount;
    }
}

function checkInvoiceDateBox() {
    var dateBox = $("#InvoiceDate").dxDateBox("instance");
    var dateBoxValue = dateBox.option('value');
    if (dateBoxValue) {
        return true;
    } else {
        return false;
    }
}
function checkInvoiceNumber() {
    var textBox = $("#InvoiceNumber").dxTextBox("instance");
    var textBoxValue = textBox.option('value').trim();
    if (textBoxValue) {
        return true;
    } else {
        return false;
    }
}

function validateFormAccept() {
    var title = "";
    var isValid = true;
    var invoiceTotal = 0; 
    var itemJsons = itemListToPost();
    console.log(itemJsons);
    if (!$("#storeCheckBox").is(":checked")) {
        isValid = false;
        title = "Store uncheck!";
    } else if (!checkInvoiceNumber()) {
        isValid = false;
        title = "Invoice Number not set!";
    } else if (!checkInvoiceDateBox()) {
        isValid = false;
        title = "Invoice Date not set!";
    } else if (itemJsons.length == 0) {
        isValid = false;
        title = "No Products entered!";
    } else if (itemJsons.length > 0) {
        invoiceTotal = itemJsons.map(e => e.totalPrice).reduce((a, b) => b + a);
        console.log(invoiceTotal);
        if (invoiceTotal < 50) {
            isValid = false;
            title = "Total Amount minimum RM 50!";
        } else if (dataProductError) {
            var error = document.getElementsByClassName("dx-error-row");
            if (error.length == 0) {
                title = "";
                isValid = true;
            } else {
                isValid = false;
                title = "Please complete your data product";
            }
        }
    } 

    if (isValid) {
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
    } else {
        Swal.fire({
            title: title,
            text: "This entry cannot marked as accepted.",
            icon: "warning",
        });
    }
}

function validateFormReject() {
    var title = "";
    var isValid = true;

    if (isValid) {
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
    } else {
        Swal.fire({
            title: title,
            text: "This entry cannot marked as valid.",
            icon: "warning",
        });
    }
}

function rejectSubmit() {
    postVerify(3);
}
function clickAccept() {
    validateFormAccept();
}
function clickReject() {
    validateFormReject()
}

function VerifiedToggle(e) {
    var status = $("#statusEntry").val();
    if (status != "Waiting for verification") return false;
    else return true;
}
function toCamel(o) {
    var newO, origKey, newKey, value
    if (o instanceof Array) {
        return o.map(function (value) {
            if (typeof value === "object") {
                value = toCamel(value)
            }
            return value
        })
    } else {
        newO = {}
        for (origKey in o) {
            if (o.hasOwnProperty(origKey)) {
                newKey = (origKey.charAt(0).toLowerCase() + origKey.slice(1) || origKey).toString()
                value = o[origKey]
                if (value instanceof Array || (value !== null && value.constructor === Object)) {
                    value = toCamel(value)
                }
                newO[newKey] = value
            }
        }
    }
    return newO
}