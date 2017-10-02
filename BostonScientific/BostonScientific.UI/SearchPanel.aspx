<%@ Page Title="Buscar Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPanel.aspx.cs" Inherits="BostonScientific.UI.SearchPanel" %>

<asp:Content ID="Menu" ContentPlaceHolderID="Menu" runat="server">
    <div class="sidebar" data-background-color="brown" data-active-color="danger">
        <div class="logo">
            <img class="img-responsive custom_02" src="images/logo_white.png" alt="Boston Scientific" />
        </div>

        <div class="sidebar-wrapper">
            <div class="user">
                <div class="info">
                    <div class="photo">
                        <img src="images/profile.png" />
                    </div>

                    <a data-toggle="collapse" href="#users" class="collapsed">
                        <span>Perfil<b class="caret"></b></span>
                    </a>
                    <div class="clearfix"></div>

                    <div class="collapse" id="users">
                        <ul class="nav custom_01">
                            <li>
                                <a href="MyProfile.aspx">
                                    <span class="sidebar-mini fa fa-user custom_01"></span>
                                    <span class="sidebar-normal">Mi Perfil</span>
                                </a>
                            </li>
                            <li>
                                <a href="EditProfile.aspx">
                                    <span class="sidebar-mini fa fa-pencil custom_01"></span>
                                    <span class="sidebar-normal">Editar Perfil</span>
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
                <li>
                    <a data-toggle="collapse" href="#adm_paneles">
                        <i class="fa fa-sliders"></i>
                        <p>
                            ADM. PANELES
       					    <b class="caret"></b>
                        </p>
                    </a>
                    <div class="collapse in" id="adm_paneles">
                        <ul class="nav">
                            <li class="active">
                                <a href="SearchPanel.aspx">
                                    <span class="sidebar-mini fa fa-search custom_01"></span>
                                    <span class="sidebar-normal">Buscar panel</span>
                                </a>
                            </li>
                            <li>
                                <a href="CreatePanel.aspx">
                                    <span class="sidebar-mini fa fa-plus custom_01"></span>
                                    <span class="sidebar-normal">Crear panel</span>
                                </a>
                            </li>
                            <li>
                                <a href="EditPanel.aspx">
                                    <span class="sidebar-mini fa fa-pencil custom_01"></span>
                                    <span class="sidebar-normal">Editar panel</span>
                                </a>
                            </li>
                            <li>
                                <a href="DeletePanel.aspx">
                                    <span class="sidebar-mini fa fa-trash-o custom_01"></span>
                                    <span class="sidebar-normal">Eliminar panel</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </li>
                <li>
                    <a href="Tools.aspx">
                        <i class="fa fa-wrench "></i>
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
                <button id="minimizeSidebar" class="btn btn-fill btn-icon"><i class="ti-more-alt"></i></button>
            </div>
            <div class="navbar-header">
                <button type="button" class="navbar-toggle">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar bar1"></span>
                    <span class="icon-bar bar2"></span>
                    <span class="icon-bar bar3"></span>
                </button>
                <a class="navbar-brand">Administrar Paneles</a>
            </div>
            <div class="collapse navbar-collapse">

                <div class="input-group custom_14">
                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                    <input class="form-control" type="text" id="search" title="Ingrese el área o código del panel" placeholder="Buscar..." runat="server" />
                    <asp:Button class="custom_06" OnClick="SearchTop_Click" runat="server" />
                </div>

                <ul class="nav navbar-nav navbar-right custom_15">
                    <li class="dropdown">
                        <a href="#notifications" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="fa fa-sign-out fa fa-2x"></i>
                            <span class="notification"></span>
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
            <div class="card-content">
                <table id="bootstrap-table" class="table">
                    <thead>
                        <th data-field="state" data-checkbox="false"></th>
                        <th data-field="IdPanel" data-sortable="false" class="text-center">Código del Panel</th>
                        <th data-field="Area" data-sortable="false" class="text-center">Área</th>
                        <th data-field="Description" data-sortable="false" class="text-center">Descripción</th>
                        <th data-field="SpacesAvailable" data-sortable="false" class="text-center">Espacios Disponibles</th>
                        <th data-field="actions" class="td-actions text-right" data-events="operateEvents" data-formatter="operateFormatter">Actions</th>
                    </thead>
                    <tbody>
                        <% PanelsInfo(); %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
