$(document).ready(function () {
    //add select nav active
    $("#dashboardNav").addClass("active");
    $("#dashboardNav").find(".snw-menu").addClass("active");
    getSummaryFilter(null);
});

//#region Filter Top
//#region Button Filter
function OnclikActionFrom() {
    var fromDate = $("#fromDate").dxDateBox("instance").option('value');
    $("#toDate").dxDateBox("instance").option('min', fromDate);
}
function OnclikActionTo() {
    var toDate = $("#toDate").dxDateBox("instance").option('value');
    $("#fromDate").dxDateBox("instance").option('max', toDate);
}

function ApplyAction() {
    var _fromDate = $("#fromDate").dxDateBox("instance").option('value');
    var _toDate = $("#toDate").dxDateBox("instance").option('value');
    var _region = $("#SelectRegion").dxSelectBox("instance").option('value');

    var param = setParam(_fromDate, _toDate, _region, null);

    getSummaryFilter(param);
    getMostActiveFilter(param);
    getTopItemFilter(param);
    getStoresFilter(param);
    getEntryFilter(param);
    getProductFilter(param);
}
function ResetAction() {
    $("#fromDate").dxDateBox("instance").option('value', null);
    $("#toDate").dxDateBox("instance").option('value', null);
    $("#SelectRegion").dxSelectBox("instance").option('value', null);
    getSummaryFilter(null);
    getMostActiveFilter(null);
    getTopItemFilter(null);
    getStoresFilter(null);
    getEntryFilter(null);
    getProductFilter(null);
    resetTableFilter();
}
function resetTableFilter() {
    var activeStoreGrid = $("#ActiveStoreGrid").dxDataGrid("instance");
    activeStoreGrid.clearFilter();
    activeStoreGrid.clearSorting();
    activeStoreGrid.pageSize(10);

    var topProductGrid = $("#TopProductGrid").dxDataGrid("instance");
    topProductGrid.clearFilter();
    topProductGrid.clearSorting();
    topProductGrid.pageSize(10);

    var storeGrid = $("#StoresGrid").dxDataGrid("instance");
    storeGrid.clearFilter();
    storeGrid.clearSorting();
    storeGrid.pageSize(10);

    var entryDataGrid = $("#EntryDataGrid").dxDataGrid("instance");
    entryDataGrid.clearFilter();
    entryDataGrid.clearSorting();
    entryDataGrid.pageSize(10);

    var productsGrid = $("#ProductsGrid").dxDataGrid("instance");
    productsGrid.clearFilter();
    productsGrid.clearSorting();
    productsGrid.pageSize(10);
}
//#endregion

//#region Get Data Filter
function getSummaryFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Admin/GetSummaryTransaction" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            setCardSummary(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getMostActiveFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Admin/GetStoreActiveList" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            if (result.data) {
                setMostActiveTable(result.data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getTopItemFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Admin/GetTopProduct" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            if (result.data) {
                setTopItemTable(result.data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getStoresFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Admin/GetStoresList" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            if (result.data) {
                setStoresTable(result.data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getEntryFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Admin/GetEntriesList" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            if (result.data) {
                setEntryTable(result.data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getProductFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Admin/GetProductList" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            if (result.data) {
                setProductTable(result.data);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}
//#endregion

//#region Set Visual Filter
function setCardSummary(obj) {
    document.getElementById("totalEntrySummary").innerText = obj.totalEntry;
    document.getElementById("waitingSummary").innerText = obj.totalWaitingForVerification;
    document.getElementById("acceptedInvoiceSummary").innerText = obj.totalAccepted;
    document.getElementById("rejectedInvoiceSummary").innerText = obj.totalRejected;
    document.getElementById("totalAmmountSummary").innerText = "RM " + obj.validTotalAmount;
}

function setMostActiveTable(obj) {
    $('#ActiveStoreGrid').dxDataGrid({
        dataSource: obj,
    });
}

function setTopItemTable(obj) {
    $('#TopProductGrid').dxDataGrid({
        dataSource: obj,
    });
}

function setStoresTable(obj) {
    $('#StoresGrid').dxDataGrid({
        dataSource: obj,
    });
}

function setEntryTable(obj) {
    $('#EntryDataGrid').dxDataGrid({
        dataSource: obj,
    });
}

function setProductTable(obj) {
    $('#ProductsGrid').dxDataGrid({
        dataSource: obj,
    });
}
//#endregion
//#endregion

//#region Filter CE
function OnclikActionFromCE(e) {
    var fromDate = $("#fromDateCE").dxDateBox("instance").option('value');
    $("#toDateCE").dxDateBox("instance").option('min', fromDate);
}
function OnclikActionToCE(e) {
    var toDate = $("#toDateCE").dxDateBox("instance").option('value');
    $("#fromDateCE").dxDateBox("instance").option('max', toDate);
}
function ApplyActionCE(e) {
    var _fromDate = $("#fromDateCE").dxDateBox("instance").option('value');
    var _toDate = $("#toDateCE").dxDateBox("instance").option('value');
    var _region = $("#SelectRegionCE").dxSelectBox("instance").option('value');
    var _period = $("#SelectPeriodCE").dxSelectBox("instance").option('value');

    var param = setParam(_fromDate, _toDate, _region, _period);
    getCEFilter(param);
}
function ResetActionCE() {
    $("#fromDateCE").dxDateBox("instance").option('value', null);
    $("#toDateCE").dxDateBox("instance").option('value', null);
    $("#SelectRegionCE").dxSelectBox("instance").option('value', null);
    $("#SelectPeriodCE").dxSelectBox("instance").option('value', null);

    getCEFilter(null);
}
function getCEFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Transaction/GetCustomerEntriesTrend" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            setCEChart(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function setCEChart(obj) {
    $('#chartCustomerEntriesTrend').dxChart({
        dataSource: obj,
    });
}
//#endregion

//#region Filter AT
function OnclikActionFromAT(e) {
    var fromDate = $("#fromDateAT").dxDateBox("instance").option('value');
    $("#toDateAT").dxDateBox("instance").option('min', fromDate);
}
function OnclikActionToAT(e) {
    var toDate = $("#toDateAT").dxDateBox("instance").option('value');
    $("#fromDateAT").dxDateBox("instance").option('max', toDate);
}
function ApplyActionAT() {
    var _fromDate = $("#fromDateAT").dxDateBox("instance").option('value');
    var _toDate = $("#toDateAT").dxDateBox("instance").option('value');
    var _region = $("#SelectRegionAT").dxSelectBox("instance").option('value');
    var _period = $("#SelectPeriodAT").dxSelectBox("instance").option('value');

    var param = setParam(_fromDate, _toDate, _region, _period);
    getATFilter(param);
}
function ResetActionAT() {
    $("#fromDateAT").dxDateBox("instance").option('value', null);
    $("#toDateAT").dxDateBox("instance").option('value', null);
    $("#SelectRegionAT").dxSelectBox("instance").option('value', null);
    $("#SelectPeriodAT").dxSelectBox("instance").option('value', null);

    getATFilter(null);
}
function getATFilter(param) {
    var key = "";
    if (param) {
        key = "?" + param;
    }
    $.ajax({
        url: "/Transaction/GetAmountTrend" + key,
        contentType: "application/json",
        type: 'GET',
        success: function (result) {
            setATChart(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function setATChart(obj) {
    $('#chartAmountTrend').dxChart({
        dataSource: obj,
    });
}
//#endregion

//#region HelperFilter
function setParam(_fromDate, _toDate, _region, _period) {
    var paramList = [];
    var param = null;

    var fromDate = null;
    var toDate = null;

    if (_fromDate) {
        fromDate = convertDateToCSubDate(_fromDate);
        paramList.push(`from=${encodeURIComponent(fromDate)}`);
    }
    if (_toDate) {
        toDate = convertDateToCSubDate(_toDate);
        paramList.push(`to=${encodeURIComponent(toDate)}`);
    }
    if (_region) {
        paramList.push(`region=${_region}`);
    }
    if (_period) {
        paramList.push(`period=${_period}`);
    }
    if (paramList.length > 1) {
        param = paramList.join("&");
    } else if (paramList.length == 1) {
        param = paramList[0];
    }
    return param;
}

function convertDateToCSubDate(date) {
    const year = date.getFullYear();
    const month = ("0" + (date.getMonth() + 1)).slice(-2);
    const dates = ("0" + (date.getDate())).slice(-2);
    var time = ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2) + ":" + ("0" + date.getSeconds()).slice(-2);
    return `${year}-${month}-${dates}T${time}.000Z`;
}
//#endregion

function toolbar_preparing(e) {
    var dataGrid = e.component;

    if (window.screen.width <= 450) {
        e.toolbarOptions.items.unshift({
            location: "after",
            widget: "dxButton",
            options: {
                hint: "Reset Filter",
                icon: "refresh",
                onClick: function () {
                    dataGrid.clearFilter();
                    dataGrid.clearSorting();
                    dataGrid.pageSize(10);
                }
            }
        });
    } else {
        e.toolbarOptions.items.unshift({
            location: "before",
            widget: "dxButton",
            options: {
                text: "Reset Filter",
                icon: "refresh",
                onClick: function () {
                    dataGrid.clearFilter();
                    dataGrid.clearSorting();
                    dataGrid.pageSize(10);
                }
            }
        });
    }
}
function Exporting() {

}
function ErrorHandlerDx() {

}