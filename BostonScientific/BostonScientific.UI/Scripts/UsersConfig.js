﻿var $table = $('#bootstrap-table');

function operateFormatter(value, row, index) {
    return [
        '<div class="table-icons">',
            '<a rel="tooltip" title="Ver" class="btn btn-simple btn-info btn-icon table-action view" href="javascript:void(0)">',
                '<i class="fa fa-eye"></i>',
            '</a>',
            '<a rel="tooltip" title="Editar" class="btn btn-simple btn-warning btn-icon table-action edit" href="javascript:void(0)">',
                '<i class="fa fa-pencil"></i>',
            '</a>',
            '<a rel="tooltip" title="Eliminar" class="btn btn-simple btn-danger btn-icon table-action remove" href="javascript:void(0)">',
                '<i class="fa fa-close"></i>',
            '</a>',
        '</div>',
    ].join('');
}

$().ready(function () {
    window.operateEvents = {
        'click .view': function (e, value, row, index) {
            info = JSON.stringify(row);

            $.ajax({
                type: "POST",
                url: "UsersConfig.aspx/GetUserInfo",
                data: "{'UserName' : '" + row.UserName + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var res = response.d

                    document.getElementById("D_txtFirstName").value = res[0].FirstName;
                    document.getElementById("D_txtLastName").value = res[0].LastName;
                    document.getElementById("D_txtEmail").value = res[0].Email;
                    document.getElementById("D_txtIdCard").value = res[0].IdCard;
                    document.getElementById("D_ddlRole").value = res[0].Phrase;
                    document.getElementById("D_txtTelephone").value = res[0].Telephone;
                    document.getElementById("D_UserPhoto").src = res[0].Photo;

                    $("#UserDetails").modal("show")
                }
            });
        },
        'click .edit': function (e, value, row, index) {
            info = JSON.stringify(row);

            $.ajax({
                type: "POST",
                url: "UsersConfig.aspx/GetUserInfo",
                data: "{'UserName' : '" + row.UserName + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var res = response.d

                    document.getElementById("E_txtFirstName").value = res[0].FirstName;
                    document.getElementById("E_txtLastName").value = res[0].LastName;
                    document.getElementById("E_txtEmail").value = res[0].Email;
                    document.getElementById("E_txtIdCard").value = res[0].IdCard;
                    if (res[0].Phrase == "Administrador") {
                        document.getElementById("E_ddlRole").selectedIndex = 1;
                    }
                    else {
                        document.getElementById("E_ddlRole").selectedIndex = 2;
                    }
                    document.getElementById("E_txtTelephone").value = res[0].Telephone;
                    document.getElementById("E_UserPhoto").src = res[0].Photo;

                    $("#EditUser").modal("show")
                }
            });
        },
        'click .remove': function (e, value, row, index) {
            swal({
                title: 'Esta seguro?',
                text: "El usuario " + row.UserName + " sera eliminado",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#21354c',
                confirmButtonText: "Si, eliminar usuario",
                cancelButtonText: "Cancelar",
            }).then((result) => {
                if (result.value = true) {
                    $.ajax({
                        type: "POST",
                        url: "UsersConfig.aspx/DeleteUser",
                        data: "{'UserName' : '" + row.UserName + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            $table.bootstrapTable('remove', {
                                field: 'UserName',
                                values: [row.UserName]
                            });

                            swal(
                              'Usuario eliminado!',
                              'El usuario ' + row.UserName + ' ha sido eliminado.',
                              'success'
                            )
                        }
                    });
                }
            })
        }
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
            detailClose: 'fa fa-close'
        }
    });

    //activate the tooltips after the data table is initialized
    $('[rel="tooltip"]').tooltip();

    $(window).resize(function () {
        $table.bootstrapTable('resetView');
    });
});

function UpdateUser() {
    var FirstName = document.getElementById("E_txtFirstName").value;
    var LastName = document.getElementById("E_txtLastName").value;
    var Email = document.getElementById("E_txtEmail").value;
    var IdCard = document.getElementById("E_txtIdCard").value;
    var Role = document.getElementById("E_ddlRole").value;
    var Telephone = document.getElementById("E_txtTelephone").value;
    var Photo = document.getElementById('E_Photo');       
    var FileName = Photo.files[0].name; //foto.png
    var FileName = Photo.files[0].name; //foto.png

    // Stream FileAddress = E_Photo.PostedFile.InputStream;
    
    /*s$.ajax({
        type: "POST",
        url: "SearchPanel.aspx/UpdatePanel",
        data: "{'IdPanel' : '" + IdPanel + "','Model' : '" + Model + "','Description' : '" + Description + "','Bus' : '" + Bus + "','Main' : '" + Main + "','Area' : '" + Area + "','From' : '" + From + "','Comments' : '" + Comments + "','Voltage' : '" + Voltage + "','Phases' : '" + Phases + "','Threads' : '" + Threads + "','Frequency' : '" + Frequency + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            swal({
                position: 'center',
                type: 'success',
                title: 'La información del panel ' + IdPanel + ' se ha actualizado correctamente',
                showConfirmButton: false,
                timer: 5000
            })
            setTimeout(function () { window.location.reload(); }, 5000);
        }
    });*/
}