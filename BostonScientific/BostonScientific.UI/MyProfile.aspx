<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="BostonScientific.UI.MyProfile" %>

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

                    <div class="collapse in" id="users">
                        <ul class="nav custom_01">
                            <li class="active">
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
                <a class="navbar-brand" href="#MyProfile">Mi Perfil
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
        <div class="col-lg-5 col-md-5">
            <div class="card card-user">
                <div class="image">
                    <img src="images/bg_profile.jpg" />
                </div>
                <div class="card-content">
                    <div class="author">
                        <img class="avatar border-white" src="images/user1.png" />
                        <h4 class="card-title">
                            <asp:Label ID="user" runat="server"></asp:Label>
                            <br />
                            <a href="#email"><small><asp:Label ID="email" runat="server"></asp:Label></small></a>
                        </h4>
                    </div>
                    <p class="description text-center">
                        "La única manera de
                        <br>
                        hacer un trabajo genial
                        <br>
                        es amando lo que haces"
                    </p>
                </div>
                <hr>
                <div class="text-center">
                    <div class="row">
                        <div class="col-md-3 col-md-offset-1 custom_07">
                            <h5>Teléfono<br />
                                <small>
                                    <asp:Label ID="tel" runat="server" />
                                </small>
                            </h5>
                        </div>
                        <div class="col-md-4">
                            <h5>Rol<br />
                                <small>
                                    <asp:Label ID="role" runat="server" />
                                </small>
                            </h5>
                        </div>
                        <div class="col-md-3">
                            <h5>Última vez<br />
                                <small>
                                    <asp:Label ID="last_time" runat="server" />
                                </small>
                            </h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-6 col-md-7">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Miembros</h4>
                </div>
                <div class="card-content">
                    <ul class="list-unstyled team-members">
                        <% Miembros(); %>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
