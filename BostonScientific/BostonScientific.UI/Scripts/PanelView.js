var $table = $('#bootstrap-table');
var $table2 = $('#bootstrap-table2');

function operateFormatter(value, row, index) {
    return [
        '<div class="table-icons">',
            '<a rel="tooltip" title="Ver Switch" class="btn btn-simple btn-info btn-icon table-action view" href="javascript:void(0)">',
                '<i class="fa fa-eye"></i>',
            '</a>',
        '</div>',
    ].join('');
}

$().ready(function () {
    window.operateEvents = {
        'click .view': function (e, value, row, index) {            
            link = "Switch.aspx?S=" + row.IdSwitch;
            location.href = link;

            $('.Remove').addClass('Remove');
        },
    };

    $table.bootstrapTable({
        toolbar: ".toolbar",
        clickToSelect: false,
        showRefresh: false,
        search: false,
        showToggle: false,
        showColumns: false,
        pagination: false,
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

    $table2.bootstrapTable({
        toolbar: ".toolbar",
        clickToSelect: false,
        showRefresh: false,
        search: false,
        showToggle: false,
        showColumns: false,
        pagination: false,
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

    $(window).resize(function () {
        $table2.bootstrapTable('resetView');
    });
});






var Type = null;
$('#ddlSwitches').on('change', function () {
    Type = document.getElementById("ddlType").value;
});

$('#ddlSwitches').on('change', function () {
    if (Type == 'Monofasico') {
        if (this.selectedOptions.length < 2) {
            $(this).find(':selected').addClass('selected');
            $(this).find(':not(:selected)').removeClass('selected');
        } else
            swal('Oops...', 'El tipo de breaker seleccionado es Monofasico, por lo tanto no se puede escoger mas de 1 switch', 'warning')
        $(this)
        .find(':selected:not(.selected)')
        .prop('selected', false);
    }
    else if (Type == 'Bifasico') {
        if (this.selectedOptions.length < 3) {
            $(this).find(':selected').addClass('selected');
            $(this).find(':not(:selected)').removeClass('selected');
        } else
            swal('Oops...', 'El tipo de breaker seleccionado es Bifasico, por lo tanto no se puede escoger mas de 2 switches', 'warning')
        $(this)
            .find(':selected:not(.selected)')
            .prop('selected', false);
    }
    else if (Type == 'Trifasico') {
        if (this.selectedOptions.length < 4) {
            $(this).find(':selected').addClass('selected');
            $(this).find(':not(:selected)').removeClass('selected');
        } else
            swal('Oops...', 'El tipo de breaker seleccionado es Trifasico, por lo tanto no se puede escoger mas de 3 switches', 'warning')
        $(this)
            .find(':selected:not(.selected)')
            .prop('selected', false);
    }
});

function CreateSwitch() {
    var Type = document.getElementById("ddlType").value;
    var Switches = $('#ddlSwitches').val();
    var Current = document.getElementById("txtCurrent").value;
    var Caliber = document.getElementById("txtCaliber").value;
    var Comments = document.getElementById("txtComments").value;

    $.ajax({
        type: "POST",
        url: "PanelView.aspx/CreateSwitch",
        data: "{'Type' : '" + Type + "','Switches' : '" + Switches + "','Current' : '" + Current + "','Caliber' : '" + Caliber + "','Comments' : '" + Comments + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            swal({
                position: 'center',
                type: 'success',
                title: 'El switch se ha creado correctamente!',
                showConfirmButton: false,
                allowOutsideClick: false,
                allowEscapeKey: false,
                allowEnterKey: false
            })

            setTimeout(function () { window.location.reload(); }, 2000);
        },
        error: function (response) {
            swal('Oops...', 'Un error a ocurrido internamente, contacte con el administrador', 'error')
        }
    });
}

