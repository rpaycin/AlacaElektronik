//tüm ajax istekleri öncesi çalışır
$(function () {
    $.ajaxSetup({
        beforeSend: function () {      
            $('#ajaxLoader').dialog({ dialogClass: 'noTitleStuff', modal: true, width: 60, height: 70 });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            switch (xhr.status) {
                case 403:
                    window.location.replace("/account/login");
                    break;
                case 500:
                    window.location.replace("/account/login");
                    break;
                default:
                    ShowMessage('Error', xhr.status);
            }
        },
        complete: function () {
            $('#ajaxLoader').dialog('close');
        },
    });
});

//ajax isteği hazırlanması
function AjaxRequest(type, url, data, isShowMessage) {

    var request = $.ajax({
        beforeSend: function () {
            $('#ajaxLoader').dialog({ dialogClass: 'noTitleStuff', modal: true, width: 60, height: 70 });
        },
        complete: function () {
            $('#ajaxLoader').dialog('close');
        },
        type: type,
        url: url,
        data: data,
        async: !isShowMessage,
        timeout: 30000,
        contentType: "application/json; charset=utf-8"
    });

    return request;
}

function AjaxRequestWithMessage(type, url, data) {
    var result = true;

    var response = AjaxRequest(type, url, data, true);

    response.done(function (data) {
        if (!data.IsSuccess) {
            ShowMessage('Hata', data.ErrorMessage);
            result = false;
        }
        else {
            result = true;
        }
    });

    return result;
}

//sayfadaki divi dinamik yenilemek için
function ReloadList(type, url, data, divContainer, tableID, tableType) {
    var requestAjax = AjaxRequest(type, url, data, false);

    requestAjax.done(function (html) {
        //container yenileniyor
        $('#' + divContainer).html(html);

        //tabloyu güncellemek için
        if (tableID != '') {
            if (tableType == "datatable")
                DataGridTR(tableID);
            else if (tableType == 'nosorting')
                DataGridScroolingDisableSort(tableID);
            else
                DataGridScrooling(tableID);
        }
    });
}

function DataGridTR(tableName) {
    jQuery('#' + tableName).dataTable({
        "oLanguage": {
            "sUrl": "/js/datatables.turkish.txt",
            "codification": "ISO-8859-1"
        },
        "sPaginationType": "full_numbers",
        "aaSortingFixed": [[0, 'asc']],
        "aLengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
        //"aLengthMenu": [[-1, 100, 50, 25, 10, 5], ["Tümü", 100, 50, 25, 10, 5]],
        "iDisplayLength": 5,
        "fnDrawCallback": function (oSettings) {
            jQuery.uniform.update();
        }
    });
}

function DataGridTRParameter(tableName) {
    jQuery('#' + tableName).dataTable({
        "oLanguage": {
            "sUrl": "/js/datatables.turkish.txt",
            "codification": "ISO-8859-1"
        },
        "sPaginationType": "full_numbers",
        "aaSortingFixed": [[0, 'asc']],
        "aLengthMenu": [[10, 25, 50], [10, 25, 50]],
        "iDisplayLength": 10,
        "fnDrawCallback": function (oSettings) {
            jQuery.uniform.update();
        }
    });
}

function DataGridScrooling(tableName) {
    jQuery('#' + tableName).dataTable({
        "oLanguage": {
            "sUrl": "/js/datatables.turkish.txt",
            "codification": "ISO-8859-1"
        },
        "bScrollInfinite": true,
        "bScrollCollapse": true,
        "aLengthMenu": [
        [25, 50, 100, 200, -1],
        [25, 50, 100, 200, "All"]
        ],
        "iDisplayLength": -1,
        "sScrollY": "300px"
    });
}
function DataGridScroolingDisableSort(tableName) {
    jQuery('#' + tableName).dataTable({
        "oLanguage": {
            "sUrl": "/js/datatables.turkish.txt",
            "codification": "ISO-8859-1"
        },
        "bScrollInfinite": true,
        "bScrollCollapse": true,
        "aLengthMenu": [
        [25, 50, 100, 200, -1],
        [25, 50, 100, 200, "All"]
        ],
        "iDisplayLength": -1,
        "sScrollY": "300px",
        "bSort":false
    });
}

function FillDropdownList(ddlListID, data) {
    ddlListID = "#" + ddlListID;
    $(ddlListID).empty();

    $(data).each(function () {
        $("<option />", {
            val: this.Value,
            text: this.Text
        }).appendTo(ddlListID);
    });
}
//Sadece Rakam Kontrolü
function OnlyNumberControl(e) {
    if (e.which != 8 && e.which != 0 && e.which != 45 && (e.which < 48 || e.which > 57)) {
        return false;
    }
    return true;
}
