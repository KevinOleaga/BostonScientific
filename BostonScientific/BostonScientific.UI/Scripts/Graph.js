(function ($) {
    $.get = function (key) {
        key = key.replace(/[\[]/, '\\[');
        key = key.replace(/[\]]/, '\\]');
        var pattern = "[\\?&]" + key + "=([^&#]*)";
        var regex = new RegExp(pattern);
        var url = unescape(window.location.href);
        var results = regex.exec(url);
        if (results === null) {
            return null;
        } else {
            return results[1];
        }
    }
})(jQuery);

var IdSwitch = $.get("S");
var Voltage = 0;
var DateTime = "null";

Highcharts.setOptions({
    global: {
        useUTC: false
    }
});

function Ajax() {
    var id = "";
    if (IdSwitch == "aXqS3g/WMK4SnulJIk6Czg==") {
        id = "thing01/data"
    } else if (IdSwitch == "MkUYWPNqXR8Nl23KwclH9g==") {
        id = "thing02/data"
    }

    $.ajax({
        type: "POST",
        url: "Switch.aspx/GetData2",
        data: "{'IdSwitch' : '" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            SetData(response.d);
        }
    });
}

function SetData(res) {
    Voltage = res
}

function GetData() {
    Ajax();
    return(Voltage)
}

Highcharts.chart('container', {
    chart: {
        type: 'spline',
        animation: Highcharts.svg,
        marginRight: 10,
        events: {
            load: function () {
                var series = this.series[0];
                setInterval(function () {
                    var x = (new Date()).getTime(),
                        y = GetData();
                    series.addPoint([x, y], true, true);
                }, 5000);
            }
        }
    },
    title: {
        text: 'Medición del Switch'
    },
    xAxis: {
        type: 'datetime',
        tickPixelInterval: 0
    },
    yAxis: {
        title: {
            text: 'Voltaje'
        },
        plotLines: [{
            value: 0,
            width: 1,
            color: '#01192e'
        }]
    },
    tooltip: {
        formatter: function () {
            return '<b>' + this.series.name + '</b><br/>' +
                Highcharts.dateFormat('%Y-%m-%d %H:%M:%S', this.x) + '<br/>' +
                Highcharts.numberFormat(this.y, 2);
        }
    },
    legend: {
        enabled: true
    },
    exporting: {
        enabled: true
    },
    series: [{
        name: 'Medición',
        data: (function () {
            // generate an array of random data
            var data = [],
                time = (new Date()).getTime(),
                i;

            for (i = -19; i <= 0; i += 1) {
                data.push({
                    x: time + i * 1000,
                    y: 0
                });
            }
            return data;
        }())
    }]
});

function OpenFiles() {
    $("#Files").modal();
}

function DeleteSwitch() {
    swal({
        title: '¿Esta seguro?',
        text: "Al eliminar el switch se eliminaran todas las mediciones hasta la fecha",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#01192e',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, eliminar switch'
    }).then((result) => {
        if (result.value = true) {
            $.ajax({
                type: "POST",
                url: "Switch.aspx/DeleteSwitch",
                data: "{'IdSwitch' : '" + $.get("S") + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    swal({
                        position: 'center',
                        type: 'success',
                        title: 'El switch junto con sus mediciones han sido eliminados correctamente!',
                        showConfirmButton: false,
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        allowEnterKey: false
                    })

                    link = "Panels.aspx";
                    setTimeout(function () { location.href = link; }, 3000);
                },
                error: function (response) {
                    swal('Oops...', 'Ha ocurrido un error al intentar eliminar el switch, si el problema persiste contacte con el administrador', 'error')
                }
            });
        }
    })
}

var $table = $('#bootstrap-table');

function operateFormatter(value, row, index) {
    return [
        '<div class="table-icons">',
            '<a rel="tooltip" title="Ver archivo" class="btn btn-simple btn-info btn-icon table-action view" href="javascript:void(0)">',
                '<i class="fa fa-eye"></i>',
            '</a>',
        '</div>',
    ].join('');
}

$().ready(function () {
    window.operateEvents = {
        'click .view': function (e, value, row, index) {
            $.ajax({
                type: "POST",
                url: "Switch.aspx/DownloadDocs",
                data: "{'FileName' : '" + row.Nombre + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    swal({
                        position: 'center',
                        type: 'success',
                        title: 'El archivo ' + row.Nombre + ' se ha descargado correctamente!',
                        showConfirmButton: true,
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        allowEnterKey: false
                    })
               },
                error: function (response) {
                    swal('Oops...', 'Ha ocurrido un error al intentar eliminar el switch, si el problema persiste contacte con el administrador', 'error')
                }
            });
        },
    };

    $table.bootstrapTable({
        toolbar: ".toolbar",
        clickToSelect: true,
        showRefresh: false,
        search: true,
        showToggle: true,
        showColumns: true,
        pagination: true,
        searchAlign: 'left',
        pageSize: 8,
        clickToSelect: false,
        pageList: [8, 10, 25, 50, 100],

        formatShowingRows: function (pageFrom, pageTo, totalRows) {
            //do nothing here, we don't want to show the text "showing x of y from..."
        },
        formatRecordsPerPage: function (pageNumber) {
            return pageNumber + " rows visible";
        },
        icons: {
            refresh: 'fa fa-refresh',
            toggle: 'fa fa-th-list',
            columns: 'fa fa-columns',
            detailOpen: 'fa fa-plus-circle',
            detailClose: 'ti-close'
        }
    });

    //activate the tooltips after the data table is initialized
    $('[rel="tooltip"]').tooltip();

    $(window).resize(function () {
        $table.bootstrapTable('resetView');
    });
});
