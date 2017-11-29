<%@ Page Title="Adm. Paneles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Panels.aspx.cs" Inherits="BostonScientific.UI.Panels" %>

<asp:Content ID="Menu" ContentPlaceHolderID="Menu" runat="server">
    <div class="sidebar" data-background-color="brown" data-active-color="danger">
        <div class="logo">
            <a href="Index.aspx" class="simple-text logo-normal">
                <img class="img-responsive custom_02 logo-normal" src="images/logo_white.png" alt="Boston Scientific" />
            </a>
        </div>

        <div class="sidebar-wrapper">
            <div class="user">
                <div class="info">
                    <div class="photo">
                        <img src="images/profile.png" />
                    </div>

                    <a data-toggle="collapse" href="#users" class="collapsed">
                        <span>Perfil
                            <b class="caret"></b>
                        </span>
                    </a>

                    <div class="clearfix"></div>

                    <div class="collapse" id="users">
                        <ul class="nav">
                            <li>
                                <a href="MyProfile.aspx">
                                    <span class="sidebar-mini fa fa-user custom_01"></span>
                                    <span class="sidebar-normal">Mi Perfil</span>
                                </a>
                            </li>
                            <li>
                                <a href="UsersConfig.aspx">
                                    <span class="sidebar-mini fa fa-group custom_01"></span>
                                    <span class="sidebar-normal">Adm. Usuarios</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <ul class="nav">
                <li>
                    <a href="Index.aspx">
                        <i class="fa fa-line-chart"></i>
                        <p>DASHBOARD</p>
                    </a>
                </li>
                <li class="active">
                    <a href="Panels.aspx">
                        <i class="fa fa-sliders"></i>
                        <p>Adm. de Paneles</p>
                    </a>
                </li>
                <li>
                    <a href="Tools.aspx">
                        <i class="fa fa-wrench"></i>
                        <p>HERRAMIENTAS</p>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-minimize">
                <button id="minimizeSidebar" class="btn btn-fill btn-icon"><i class="fa fa-bars"></i></button>
            </div>

            <div class="navbar-header">
                <button type="button" class="navbar-toggle">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar bar1"></span>
                    <span class="icon-bar bar2"></span>
                    <span class="icon-bar bar3"></span>
                </button>
                <a class="navbar-brand" href="#Panels">Adm. Paneles
                </a>
            </div>

            <div class="collapse navbar-collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a href="#notifications" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="fa fa-sign-out fa fa-2x"></i>
                            <p class="hidden-md hidden-lg"><b class="caret"></b></p>
                        </a>
                        <ul class="dropdown-menu">
                            <li><a href="Login.aspx">Cerrar Sesión</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Administración de paneles
                </h4>
                <p class="category">
                    Seleccione el panel que desea administrar o bien cree un nuevo panel
                </p>
                <br />
                <button type="button" class="btn btnCreatePanel" data-toggle="modal" data-target="#CreatePanel">Crear panel</button>
            </div>
            <div class="card-content">
                <table id="bootstrap-table" class="table">
                    <thead>
                        <th data-field="IdPanel" class="text-center">Código de Panel</th>
                        <th data-field="Area" class="text-center" data-sortable="true">Área</th>
                        <th data-field="Description" class="text-center">Descripción</th>
                        <th data-field="SpacesAvailable" class="text-center">Espacios Disponibles</th>
                        <th data-field="actions" class="td-actions text-center" data-events="operateEvents" data-formatter="operateFormatter">Acciones</th>
                    </thead>
                    <tbody>
                        <% ShowPanelsInfo(); %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <!-- Modal CreatePanel -->
    <div class="modal fade in" id="CreatePanel" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div>
                    <div class="form-wizard form-header-stylist form-body-material">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h3>Crear Panel</h3>
                        <p>Rellene los espacios en blanco para crear un nuevo panel</p>

                        <div class="form-wizard-steps form-wizard-tolal-steps-4">
                            <div class="form-wizard-progress">
                                <div class="form-wizard-progress-line" data-now-value="12.25" data-number-of-steps="4" style="width: 12.25%;"></div>
                            </div>
                            <!-- Step 1 -->
                            <div class="form-wizard-step active">
                                <div class="form-wizard-step-icon"><i class="fa fa-info" aria-hidden="true"></i></div>
                                <p>Información General</p>
                            </div>
                            <!-- Step 1 -->

                            <!-- Step 2 -->
                            <div class="form-wizard-step">
                                <div class="form-wizard-step-icon"><i class="fa fa-location-arrow" aria-hidden="true"></i></div>
                                <p>Ubicación</p>
                            </div>
                            <!-- Step 2 -->

                            <!-- Step 3 -->
                            <div class="form-wizard-step">
                                <div class="form-wizard-step-icon"><i class="fa fa-dashboard" aria-hidden="true"></i></div>
                                <p>Medidas</p>
                            </div>
                            <!-- Step 3 -->

                            <!-- Step 4 -->
                            <div class="form-wizard-step">
                                <div class="form-wizard-step-icon"><i class="fa fa-comments" aria-hidden="true"></i></div>
                                <p>Comentarios</p>
                            </div>
                            <!-- Step 4 -->
                        </div>

                        <!-- Form Step 1 -->
                        <fieldset>
                            <div class="progress">
                                <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="25.6" aria-valuemin="0" aria-valuemax="100" style="width: 25.6%"></div>
                            </div>

                            <h4>Información del Panel: <span>Paso 1 - 4</span></h4>
                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca el código del panel" placeholder="Código del panel" id="C_txtIdPanel" type="text" />
                            </div>
                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca el modelo del panel" placeholder="Modelo" id="C_txtModel" type="text" />
                            </div>
                            <div class="form-group col-xs-12">
                                <input class="form-control required" title="Introduzca una descripción del panel" placeholder="Descripción" id="C_txtDescription" type="text" />
                            </div>
                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca el bus del panel" placeholder="Bus" id="C_txtBus" type="number" />
                            </div>
                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca el main del panel" placeholder="Main" id="C_txtMain" type="number" />
                            </div>
                            <br />
                            <div class="form-wizard-buttons">
                                <button type="button" class="btn btn-next">Siguiente</button>
                            </div>
                        </fieldset>
                        <!-- Form Step 1 -->

                        <!-- Form Step 2 -->
                        <fieldset>
                            <div class="progress">
                                <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="50.6" aria-valuemin="0" aria-valuemax="100" style="width: 50.6%">
                                </div>
                            </div>

                            <h4>Ubicación del Panel: <span>Paso 2 - 4</span></h4>

                            <div class="form-group col-xs-12">
                                <input class="form-control required" title="Introduzca el área donde se encuentra el panel" placeholder="Área" id="C_txtArea" type="text" />
                            </div>
                            <div class="form-group col-xs-12">
                                <input class="form-control required" title="Introduzca la proveniencia del panel" placeholder="From" id="C_txtFrom" type="text" />
                            </div>
                            <br />
                            <div class="form-wizard-buttons">
                                <button type="button" class="btn btn-previous">Atras</button>
                                <button type="button" class="btn btn-next">Siguiente</button>
                            </div>
                        </fieldset>
                        <!-- Form Step 2 -->

                        <!-- Form Step 3 -->
                        <fieldset>
                            <div class="progress">
                                <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="75.6" aria-valuemin="0" aria-valuemax="100" style="width: 75.6%">
                                </div>
                            </div>

                            <h4>Mediciones: <span>Paso 3 - 4</span></h4>

                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca el voltaje del panel" placeholder="Voltaje" id="C_txtVoltage" type="number" />
                            </div>
                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca la cantidad de fases del panel" placeholder="Fases" id="C_txtPhases" type="number" />
                            </div>
                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca la cantidad de hilos del panel" placeholder="Hilos" id="C_txtThreads" type="number" />
                            </div>
                            <div class="form-group col-xs-6">
                                <input class="form-control required" title="Introduzca la frecuencia del panel" placeholder="Frecuencia" id="C_txtFrequency" type="number" />
                            </div>
                            <br />
                            <div class="form-wizard-buttons">
                                <button type="button" class="btn btn-previous">Atras</button>
                                <button type="button" class="btn btn-next">Siguiente</button>
                            </div>
                        </fieldset>
                        <!-- Form Step 3 -->

                        <!-- Form Step 4 -->
                        <fieldset>
                            <div class="progress">
                                <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                                </div>
                            </div>

                            <h4>Comentarios: <span>Paso 4 - 4</span></h4>

                            <div class="form-group col-xs-12">
                                <input class="form-control" title="Comentarios..." placeholder="Comentarios" id="C_txtComments" type="text" />
                            </div>
                            <br />
                            <div class="form-wizard-buttons">
                                <button type="button" class="btn btn-previous">Atras</button>
                                <button type="button" class="btn btn-submit" onclick="CreatePanel()">Crear Panel</button>
                            </div>
                        </fieldset>
                        <!-- Form Step 4 -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal CreatePanel -->

    <!-- Modal EditPanel -->
    <div class="modal fade in" id="EditPanel" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Editar panel</h4>
                </div>
                <div class="modal-body">
                    <div class="card-content">
                        <div class="row">
                            <div class="col-md-9">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Código del panel</label>
                                            <input class="form-control" readonly="readonly" title="Código del panel" id="U_txtIdPanel" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Modelo</label>
                                            <input class="form-control required" title="Introduzca el modelo del panel" id="U_txtModel" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Bus</label>
                                            <input class="form-control required" title="Introduzca el bus del panel" id="U_txtBus" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Main</label>
                                            <input class="form-control required" title="Introduzca el main del panel" id="U_txtMain" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Descripción</label>
                                            <input class="form-control required" title="Introduzca una descripción del panel" id="U_txtDescription" type="text" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Área</label>
                                            <input class="form-control required" title="Introduzca el área donde se encuentra el panel" id="U_txtArea" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>From</label>
                                            <input class="form-control required" title="Introduzca la proveniencia del panel" id="U_txtFrom" type="text" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Voltaje</label>
                                            <input class="form-control required" title="Introduzca el voltaje del panel" id="U_txtVoltage" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Fases</label>
                                            <input class="form-control required" title="Introduzca la cantidad de fases del panel" id="U_txtPhases" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Hilos</label>
                                            <input class="form-control required" title="Introduzca la cantidad de hilos del panel" id="U_txtThreads" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Frecuencia</label>
                                            <input class="form-control required" title="Introduzca la frecuencia del panel" id="U_txtFrequency" type="text" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Comentarios</label>
                                            <textarea class="form-control border-input" title="Comentarios..." id="U_txtComments" rows="3"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="card card-circle-chart edit_panelChart" data-background-color="brown">
                                    <div class="card-header text-center">
                                        <h5 class="card-title custom-title">Switches</h5>
                                        <p class="description custom_EditCardSub">Espacios disponibles</p>
                                    </div>
                                    <div class="card-content">
                                        <div id="chartSubscriptions" class="chart-circle" data-percent="100">
                                            42 / 42
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btnCancel_customColor" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btnOK_customColor" onclick="UpdatePanel()">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal EditPanel -->
</asp:Content>
