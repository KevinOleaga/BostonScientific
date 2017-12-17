<%@ Page Title="Switch" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Switch.aspx.cs" Inherits="BostonScientific.UI.Switch" %>

<asp:Content ID="Menu" ContentPlaceHolderID="Menu" runat="server">
    <div class="sidebar" data-background-color="brown" data-active-color="danger">
        <div class="logo">
            <a href="Index.aspx" class="simple-text logo-normal">
                <img class="img-responsive logo-normal" src="images/logo_white.png" alt="Boston Scientific" />
            </a>
        </div>
        <!-- end logo -->

        <div class="sidebar-wrapper">
            <div class="user">
                <div class="info">
                    <div class="photo">
                        <img src="images/profile.png" />
                    </div>
                    <!-- end photo -->

                    <a data-toggle="collapse" href="#users" class="collapsed">
                        <span>Perfil
                            <b class="caret"></b>
                        </span>
                    </a>

                    <div class="clearfix"></div>
                    <!-- end clearfix -->

                    <div class="collapse" id="users">
                        <ul class="nav">
                            <li>
                                <a href="MyProfile.aspx">
                                    <span class="sidebar-mini fa fa-user menu_icons"></span>
                                    <span class="sidebar-normal">Mi Perfil</span>
                                </a>
                            </li>
                            <li>
                                <a href="UsersConfig.aspx">
                                    <span class="sidebar-mini fa fa-group menu_icons"></span>
                                    <span class="sidebar-normal">Adm. Usuarios</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <!-- end collapse -->
                </div>
                <!-- end info -->
            </div>
            <!-- end user -->

            <ul class="nav">
                <li>
                    <a href="Index.aspx">
                        <i class="fa fa-line-chart"></i>
                        <p>DASHBOARD</p>
                    </a>
                </li>
                <li>
                    <a href="Panels.aspx">
                        <i class="fa fa-sliders"></i>
                        <p>ADM. DE PANELES</p>
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
        <!-- end sidebar-wrapper -->
    </div>
    <!-- end sidebar -->
</asp:Content>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-minimize">
                <button id="minimizeSidebar" class="btn btn-fill btn-icon"><i class="fa fa-bars"></i></button>
            </div>
            <!-- end navbar-minimize -->

            <div class="navbar-header">
                <button type="button" class="navbar-toggle">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar bar1"></span>
                    <span class="icon-bar bar2"></span>
                    <span class="icon-bar bar3"></span>
                </button>
                <a class="navbar-brand" href="#">Switch</a>
            </div>
            <!-- end navbar-header -->

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
            <!-- end collapse navbar-collapse -->
        </div>
        <!-- end container-fluid -->
    </nav>
    <!-- end container-fluid -->
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-12">
        <div class="card">
            <div class="card-header custom-index">
                <h4 class="card-title">Información del Switch</h4>
                <br />
            </div>

            <div class="card-content custom_card">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12 custom_col">
                            <div class="form-group">
                                <button type="button" class="btn btn-icon btn-fill btn-success" onclick="OpenFiles()">
                                    <i class="fa fa-file-archive-o"></i>
                                </button>
                                <button type="button" class="btn btn-icon btn-fill btn-info" onclick="EditSwitch()">
                                    <i class="fa fa-pencil"></i>
                                </button>
                                <button type="button" class="btn btn-icon btn-fill btn-danger" onclick="DeleteSwitch()">
                                    <i class="fa fa-trash-o"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Tipo de breaker</label>
                                <asp:TextBox ReadOnly="true" CssClass="form-control" ToolTip="Tipo de breaker" ID="txtType" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Corriente</label>
                                <asp:TextBox ReadOnly="true" CssClass="form-control" ToolTip="Corriente del switch" ID="txtCurrent" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Calibre</label>
                                <asp:TextBox ReadOnly="true" CssClass="form-control" ToolTip="Calibre del switch" ID="txtCaliber" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-1">
                            <div class="form-group">
                                <label>Switches</label>
                                <asp:TextBox ReadOnly="true" CssClass="form-control txtsize" ToolTip="Switch #1" ID="txtS1" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-1">
                            <div class="form-group">
                                <label></label>
                                <asp:TextBox ReadOnly="true" CssClass="form-control txtsize txtTop" ToolTip="Switch #2" ID="txtS2" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-1">
                            <div class="form-group">
                                <label></label>
                                <asp:TextBox ReadOnly="true" CssClass="form-control txtsize txtTop" ToolTip="Switch #3" ID="txtS3" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Comentarios</label>
                                <textarea runat="server" readonly="readonly" id="txtComments" rows="3" class="form-control" placeholder="Comentarios..."></textarea>
                            </div>
                            <!-- end form-group -->
                        </div>
                        <!-- end col-md-12 -->
                    </div>
                    <!-- end row -->
                    <div class="row">
                        <div class="col-md-12">
                            <label>Añadir archivos</label>
                            <div class="input-group image-preview">
                                <input type="text" class="form-control image-preview-filename" disabled="disabled">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-default image-preview-clear" style="display: none;">
                                        <span class="fa fa-remove"></span>Limpiar
                                    </button>
                                    <div class="btn btn-default image-preview-input">
                                        <span class="fa fa-folder-open"></span>
                                        <span class="image-preview-input-title">Buscar</span>
                                        <asp:FileUpload ID="fuFiles" runat="server" />
                                    </div>
                                </span>
                            </div>
                            <asp:Button CssClass="btn btn-info btn-fill btn-wd" ID="btn_AddFile" runat="server" Text="Guardar" OnClick="btn_AddFile_Click" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
                        </div>
                    </div>

                </div>
            </div>
            <!-- end card-content -->
        </div>
        <!-- end card -->
    </div>

    <div class="modal fade in" id="Files" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Archivos del Switch</h4>
                </div>
                <div class="modal-body">
                    <div class="card-content">
                        <table id="bootstrap-table" class="table">
                            <thead>
                                <th data-field="Id" class="text-center">Id</th>
                                <th data-field="Nombre" class="text-center">Nombre</th>
                                <th data-field="actions" class="td-actions text-center" data-events="operateEvents" data-formatter="operateFormatter">Acciones</th>
                            </thead>
                            <tbody>
                                <% GetFiles(); %>
                            </tbody>
                        </table>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btnCancel_customColor" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="JS" ContentPlaceHolderID="JS" runat="server">
    <script src="Scripts/highcharts.js"></script>
    <script src="Scripts/exporting.js"></script>
    <script src="Scripts/Graph.js"></script>
</asp:Content>
