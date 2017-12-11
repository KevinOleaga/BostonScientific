<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BostonScientific.UI.Index" %>

<asp:Content ID="Menu" ContentPlaceHolderID="Menu" runat="server">
    <div class="sidebar" data-background-color="brown" data-active-color="danger">
        <div class="logo">
            <a href="Index.aspx" class="simple-text logo-normal">
                <img class="img-responsive logo-normal" src="images/logo_white.png" alt="Boston Scientific" />
            </a>
        </div><!-- end logo -->
        <div class="sidebar-wrapper">
            <div class="user">
                <div class="info">
                    <div class="photo">
                        <img src="images/profile.png" />
                    </div><!-- end photo -->

                    <a data-toggle="collapse" href="#users" class="collapsed">
                        <span>Perfil
                            <b class="caret"></b>
                        </span>
                    </a>

                    <div class="clearfix"></div><!-- end clearfix -->

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
                    </div><!-- end collapse -->
                </div><!-- end info -->
            </div><!-- end user -->

            <ul class="nav">
                <li class="active">
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
        </div><!-- end sidebar-wrapper -->
    </div><!-- end sidebar -->
</asp:Content>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-minimize">
                <button id="minimizeSidebar" class="btn btn-fill btn-icon"><i class="fa fa-bars"></i></button>
            </div><!-- end navbar-minimize -->

            <div class="navbar-header">
                <button type="button" class="navbar-toggle">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar bar1"></span>
                    <span class="icon-bar bar2"></span>
                    <span class="icon-bar bar3"></span>
                </button>
                <a class="navbar-brand" href="#">Dashboard</a>
            </div><!-- end navbar-header -->

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
            </div><!-- end collapse navbar-collapse -->
        </div><!-- end container-fluid -->
    </nav><!-- end container-fluid -->
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-primary text-center">
                                <i class="fa fa-users"></i>
                            </div><!-- end icon-big icon-primary text-center -->
                        </div><!-- end col-xs-5 -->
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Usuarios</p>
                                <asp:Label ID="Users" runat="server"></asp:Label>
                            </div><!-- end numbers -->
                        </div><!-- end col-xs-7 -->
                    </div><!-- end row -->
                </div><!-- end card-content -->
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i>Actualizado
                    </div><!-- end stats -->
                </div><!-- end card-footer -->
            </div><!--end card -->
        </div><!-- end col-lg-3 col-sm-6 -->

        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-success text-center">
                                <i class="fa fa-th-large"></i>
                            </div><!-- end icon-big icon-succes text-center -->
                        </div><!-- col-xs-5 -->
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Paneles</p>
                                <asp:Label ID="Panels" runat="server"></asp:Label>
                            </div><!-- end numbers -->
                        </div><!-- col-xs-7 -->
                    </div><!-- end row -->
                </div><!-- end card-content -->
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i> Actualizado
                    </div><!-- end stats -->
                </div><!-- end card-footer -->
            </div><!-- end card -->
        </div><!-- end col-lg-3 col-sm-6 -->

        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-danger text-center">
                                <i class="fa fa-plus"></i>
                            </div><!-- end icon-big icon-danger text-center -->
                        </div><!-- end col-xs-5 -->
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Disponible</p>
                                0
                            </div><!-- end numbers -->
                        </div><!-- end col-xs-7 -->
                    </div><!-- end row -->
                </div><!-- end card-content -->
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i>Actualizado
                    </div><!-- end stats -->
                </div><!-- end card-footer -->
            </div><!-- end card -->
        </div><!-- end col-lg-3 col-sm-6 -->

        <div class="col-lg-3 col-sm-6">
            <div class="card">
                <div class="card-content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="icon-big icon-info text-center">
                                <i class="fa fa-plus"></i>
                            </div><!-- end icon-big icon-info text-center -->
                        </div><!-- end col-xs-5 -->
                        <div class="col-xs-7">
                            <div class="numbers">
                                <p>Alertas</p>
                                <asp:Label ID="Alerts" runat="server"></asp:Label>
                            </div><!-- end numbers -->
                        </div><!-- end col-xs-7 -->
                    </div><!-- end row -->
                </div><!-- end card-content -->
                <div class="card-footer">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh fa-spin"></i>Actualizado
                    </div><!-- end stats -->
                </div><!-- end card-footer -->
            </div><!-- end card -->
        </div><!-- end col-lg-3 col-sm-6 -->
    </div><!-- end row -->
</asp:Content>
