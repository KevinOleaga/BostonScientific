<%@ Page Title="Index" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BostonScientific.UI.Index" %>

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
                <li class="active">
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
                    <div class="collapse" id="adm_paneles">
                        <ul class="nav">
                            <li>
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
                <a class="navbar-brand" href="#Dashboard">Dashboard
                </a>
            </div>
            <div class="collapse navbar-collapse">

                <div class="input-group custom_14">
                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                    <input class="form-control" type="text" id="search" title="Ingrese el área o código del panel" placeholder="Buscar..." runat="server" />
                    <asp:Button class="custom_06" OnClick="Search_Click" runat="server" />
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
    <div class="row">
        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-primary text-center">
                                <i class="fa fa-th-large"></i>
                            </div>
                        </div>
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Paneles</p>
                                <asp:Label ID="PanelCount" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i> Actualizado
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-success text-center">
                                <i class="fa fa-plus"></i>
                            </div>
                        </div>
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Disponible</p>
                                0
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i> Actualizado
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-danger text-center">
                                <i class="fa fa-plus"></i>
                            </div>
                        </div>
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Disponible</p>
                                0
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i> Actualizado
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-info text-center">
                                <i class="fa fa-plus"></i>
                            </div>
                        </div>
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Disponble</p>
                                0
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i> Actualizado
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-4 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-7">
                            <div class="numbers pull-left">
                                000
                            </div>
                        </div>
                        <div class="col-xs-5">
                            <div class="pull-right">
                                <span class="label label-success">0%
                                </span>
                            </div>
                        </div>
                    </div>
                    <h6 class="big-title">Disponible</h6>
                    <div id="chartTotalEarnings"></div>
                </div>
                <div class="card-footer">
                    <hr>
                    <div class="footer-title">Disponible</div>
                </div>
            </div>
        </div>

        <div class="col-lg-4 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-7">
                            <div class="numbers pull-left">
                                000
                            </div>
                        </div>
                        <div class="col-xs-5">
                            <div class="pull-right">
                                <span class="label label-danger">0%
                                </span>
                            </div>
                        </div>
                    </div>
                    <h6 class="big-title">Disponible</h6>
                    <div id="chartTotalSubscriptions"></div>
                </div>
                <div class="card-footer">
                    <hr>
                    <div class="footer-title">Disponible</div>
                </div>
            </div>
        </div>

        <div class="col-lg-4 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-7">
                            <div class="numbers pull-left">
                                000
                            </div>
                        </div>
                        <div class="col-xs-5">
                            <div class="pull-right">
                                <span class="label label-warning">0%
                                </span>
                            </div>
                        </div>
                    </div>
                    <h6 class="big-title">Disponible</h6>
                    <div id="chartTotalDownloads"></div>
                </div>
                <div class="card-footer">
                    <hr>
                    <div class="footer-title">Disponible</div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-3 col-sm-6">
            <div class="card card-circle-chart" data-background-color="blue">
                <div class="card-header text-center">
                    <h5 class="card-title">Disponible</h5>
                    <p class="description">Disponible</p>
                </div>
                <div class="card-content">
                    <div id="chartDashboard" class="chart-circle" data-percent="100">100%</div>
                </div>
            </div>
        </div>

        <div class="col-lg-3 col-sm-6">
            <div class="card card-circle-chart" data-background-color="green">
                <div class="card-header text-center">
                    <h5 class="card-title">Disponible</h5>
                    <p class="description">Disponible</p>
                </div>
                <div class="card-content">
                    <div id="chartOrders" class="chart-circle" data-percent="75">75%</div>
                </div>
            </div>
        </div>

        <div class="col-lg-3 col-sm-6">
            <div class="card card-circle-chart" data-background-color="orange">
                <div class="card-header text-center">
                    <h5 class="card-title">Disponible</h5>
                    <p class="description">Disponible</p>
                </div>
                <div class="card-content">
                    <div id="chartNewVisitors" class="chart-circle" data-percent="50">50%</div>
                </div>
            </div>
        </div>

        <div class="col-lg-3 col-sm-6">
            <div class="card card-circle-chart" data-background-color="brown">
                <div class="card-header text-center">
                    <h5 class="card-title">Disponible</h5>
                    <p class="description">Disponible</p>
                </div>
                <div class="card-content">
                    <div id="chartSubscriptions" class="chart-circle" data-percent="25">25%</div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
