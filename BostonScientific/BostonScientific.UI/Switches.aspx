<%@ Page Title="Switches" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Switches.aspx.cs" Inherits="BostonScientific.UI.Switches" %>

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
                <a class="navbar-brand" href="#Switches">Visor de Switches
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
    
</asp:Content>
