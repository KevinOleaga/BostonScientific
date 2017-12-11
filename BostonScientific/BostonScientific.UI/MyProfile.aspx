<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="BostonScientific.UI.MyProfile" %>

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

                    <div class="collapse in" id="users">
                        <ul class="nav">
                            <li class="active">
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
                <a class="navbar-brand" href="#">Mi Perfil</a>
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
    <div class="col-lg-5 col-md-5">
        <div class="card card-user">
            <div class="image">
                <img src="images/profile_HeaderCard.jpg" />
            </div><!-- end image -->
            <div class="card-content">
                <div class="author">
                    <img class="avatar border-white" src="<% Photo(); %>" />
                    <h4 class="card-title">
                        <asp:Label ID="lb_user" runat="server"></asp:Label>
                        <br />
                        <a href="#">
                            <small>
                                <asp:Label ID="lb_email" runat="server"></asp:Label>
                            </small>
                        </a>
                    </h4>
                </div><!-- end author-->
                <p class="description text-center">
                    "<asp:Label ID="lb_phrase" runat="server"></asp:Label>"
                </p>
            </div><!-- end card-content -->
            <hr>
            <div class="text-center">
                <div class="row">
                    <div class="col-md-4">
                        <h5>Usuario<br />
                            <small>
                                <asp:Label ID="lb_username" runat="server" />
                            </small>
                        </h5>
                    </div><!-- end col-md-4 -->
                    <div class="col-md-4">
                        <h5>Rol<br />
                            <small>
                                <asp:Label ID="lb_role" runat="server" />
                            </small>
                        </h5>
                    </div><!-- end col-md-4 -->
                    <div class="col-md-4">
                        <h5>Teléfono<br />
                            <small>
                                <asp:Label ID="lb_telephone" runat="server" />
                            </small>
                        </h5>
                    </div><!-- end col-md-4 -->
                </div><!-- end row-->
            </div><!-- end text-center -->
        </div><!-- end card card-user -->

        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Miembros</h4>
            </div><!-- end card-header -->
            <div class="card-content card_members">
                <ul class="list-unstyled team-members">
                    <% Members();  %>
                </ul>
            </div><!-- end card-content card-members -->
        </div><!-- end card -->
    </div><!-- end col-lg-5 col-md-5 -->

    <div class="col-lg-7 col-md-7">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Editar Perfil</h4>
            </div>
            <div class="card-content">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Nombre</label>
                            <asp:TextBox CssClass="form-control border-input" ToolTip="Digite su nombre" ID="E_FirstName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Apellidos</label>
                            <asp:TextBox CssClass="form-control border-input" ToolTip="Digite sus apellidos" ID="E_LastName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox CssClass="form-control border-input" TextMode="Email" ToolTip="Digite su email" ID="E_Email" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Rol</label>
                            <asp:TextBox CssClass="form-control border-input" ReadOnly="true" ID="E_Role" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Teléfono</label>
                            <asp:TextBox CssClass="form-control border-input" MaxLength="8" ToolTip="Digite su número teléfonico" ID="E_Telephone" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Número de Cédula</label>
                            <asp:TextBox CssClass="form-control border-input" ReadOnly="true" ToolTip="Digite su número de cédula" ID="E_IdCard" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Frase</label>
                            <textarea runat="server" id="E_Phrase" rows="5" class="form-control border-input" placeholder="Frase diaria..."></textarea>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <label>Foto de Perfil</label>
                        <div class="input-group image-preview">
                            <input type="text" class="form-control image-preview-filename" disabled="disabled">
                            <span class="input-group-btn">
                                <button type="button" class="btn btn-default image-preview-clear" style="display: none;">
                                    <span class="fa fa-remove"></span>Limpiar
                                </button>
                                <div class="btn btn-default image-preview-input">
                                    <span class="fa fa-folder-open"></span>
                                    <span class="image-preview-input-title">Buscar</span>
                                    <asp:FileUpload ID="E_Image" runat="server" />
                                </div>
                            </span>
                        </div>
                    </div>
                </div>

                <div class="text-center custom_18">
                    <asp:Button CssClass="btn btn-info btn-fill btn-wd" ID="btn_UpdateProfile" runat="server" Text="Actualizar" OnClick="btn_UpdateProfile_Click" />
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
