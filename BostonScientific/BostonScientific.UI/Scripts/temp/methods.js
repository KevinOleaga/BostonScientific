function CreatePanel() {
    var IdPanel = document.getElementById("C_txtIdPanel").value;
    var Model = document.getElementById("C_txtModel").value;
    var Description = document.getElementById("C_txtDescription").value;
    var Bus = document.getElementById("C_txtBus").value;
    var Main = document.getElementById("C_txtMain").value;
    var Area = document.getElementById("C_txtArea").value;
    var From = document.getElementById("C_txtFrom").value;
    var Voltage = document.getElementById("C_txtVoltage").value;
    var Phases = document.getElementById("C_txtPhases").value;
    var Threads = document.getElementById("C_txtThreads").value;
    var Frequency = document.getElementById("C_txtFrequency").value;
    var Comments = document.getElementById("C_txtComments").value;

    $.ajax({
        type: "POST",
        url: "SearchPanel.aspx/CreatePanel",
        data: "{'IdPanel' : '" + IdPanel + "','Model' : '" + Model + "','Description' : '" + Description + "','Bus' : '" + Bus + "','Main' : '" + Main + "','Area' : '" + Area + "','From' : '" + From + "','Voltage' : '" + Voltage + "','Phases' : '" + Phases + "','Threads' : '" + Threads + "','Frequency' : '" + Frequency + "','Comments' : '" + Comments + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d == false) {
                swal({
                    position: 'center',
                    type: 'success',
                    title: 'El panel ' + IdPanel + ' se ha creado correctamente!',
                    showConfirmButton: false,
                    timer: 5000
                })

                setTimeout(function () { window.location.reload(); }, 5000);
            }
            else if (response.d == true) {
                swal('Error', 'El panel ' + IdPanel + ' ya se encuentra en el sistema!', 'error')
            }
        }
    });
}

function UpdatePanel() {
    var IdPanel = document.getElementById("U_txtIdPanel").value;
    var Model = document.getElementById("U_txtModel").value;
    var Description = document.getElementById("U_txtDescription").value;
    var Bus = document.getElementById("U_txtBus").value;
    var Main = document.getElementById("U_txtMain").value;
    var Area = document.getElementById("U_txtArea").value;
    var From = document.getElementById("U_txtFrom").value;
    var Voltage = document.getElementById("U_txtVoltage").value;
    var Phases = document.getElementById("U_txtPhases").value;
    var Threads = document.getElementById("U_txtThreads").value;
    var Frequency = document.getElementById("U_txtFrequency").value;
    var Comments = document.getElementById("U_txtComments").value;

    $.ajax({
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
    });
}



$(document).ready(function () { 
    var myTable = $('#myTable').DataTable();

    $('#myTable tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });

    //Contar filas seleccionadas
    $('#btnValoresSeleccionados').click(function () {
        //alert(myTable.rows().data().length+' row(s) selected' );

        //Recorre las filas de la tabla
        $('#myTable tbody tr').each(function (indexFila) {
            //verifica si  la fila seleccionada tiene la clase 'selected'  
            if ($(this).hasClass('selected')) {
                alert("La fila: " + indexFila + " se ha seleccionado");
            }
            //Recorre las columnas de la tabla
            $(this).children('td').each(function (indexColumna) {
                if (indexColumna == 3) {
                    campo1 = $(this).text()
                    alert(campo1 + " :children");
                };
            });

        });//fin de '#myTable tbody tr'

    });//fin (btnSeleccionados)
    // alert(myTable.rows('.selected').data().length+' row(s) selected' );

    //Obtener valor de las filas a las que se hace click
    var myFila = myTable.row(this).data(); //Obtiene datos de una fila
    $.each(myFila, function (index, contenido) { //Recorre un array
        if (index == 2) {
            alert(contenido);
        };
    });

});//Fin