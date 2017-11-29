<%@ Page Title="Adm. Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersConfig.aspx.cs" Inherits="BostonScientific.UI.UsersConfig" %>

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

                    <div class="collapse in" id="users">
                        <ul class="nav">
                            <li>
                                <a href="MyProfile.aspx">
                                    <span class="sidebar-mini fa fa-user custom_01"></span>
                                    <span class="sidebar-normal">Mi Perfil</span>
                                </a>
                            </li>
                            <li class="active">
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
                <a class="navbar-brand" href="#SearchPanel">Adm. Usuarios
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
                <h4 class="card-title">Administración de usuarios
                </h4>
                <p class="category">
                    Seleccione el usuario que desea administrar o bien cree un nuevo usuario
                </p>
                <br />
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#CreateUser">Crear usuario</button>
            </div>
            <div class="card-content">
                <table id="bootstrap-table" class="table">
                    <thead>
                        <th class="text-center" data-field="UserName">Usuario</th>
                        <th class="text-center" data-field="Nombre">Nombre</th>
                        <th class="text-center" data-field="Rol">Rol</th>
                        <th class="text-center" data-field="Email">Email</th>
                        <th class="text-center" data-field="Telefono">Teléfono</th>
                        <th data-field="actions" class="td-actions text-center" data-events="operateEvents" data-formatter="operateFormatter">Acciones</th>
                    </thead>
                    <tbody>
                        <% UsersInfo(); %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <!-- Modal CreateUser -->
    <div class="modal fade in" id="CreateUser" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Crear Usuario</h4>
                </div>
                <div class="modal-body">
                    <div class="card-content">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox UseSubmitBehavior="false" CssClass="form-control border-input" ToolTip="Digite el nombre" ID="txtNombre" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Apellidos</label>
                                    <asp:TextBox CssClass="form-control border-input" ToolTip="Digite los apellidos" ID="txtApellidos" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control border-input" TextMode="Email" ToolTip="Digite el email" ID="txtEmail" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Número de Cédula</label>
                                    <asp:TextBox CssClass="form-control border-input" ToolTip="Digite el número de cédula" ID="txtCedula" MaxLength="15" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Rol</label>
                                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddlRol" ToolTip="Seleccione un rol para el usuario"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Número de Teléfono</label>
                                    <asp:TextBox CssClass="form-control border-input" ToolTip="Digite el número teléfonico" ID="txtTelefono" MaxLength="8" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Comentarios</label>
                                    <textarea runat="server" id="txtComentarios" rows="3" class="form-control border-input" placeholder="Comentarios..."></textarea>
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
                                            <span class="glyphicon glyphicon-remove"></span>Limpiar                   
                                        </button>
                                        <div class="btn btn-default image-preview-input">
                                            <span class="glyphicon glyphicon-folder-open"></span>
                                            <span class="image-preview-input-title">Buscar</span>
                                            <asp:FileUpload ID="fuFoto" runat="server" />
                                        </div>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button CssClass="btn btn-info btn-fill btn-wd" ID="btn_CreateUser" runat="server" Text="Crear usuario" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal CreateUser -->

    <!-- Modal UserDetails -->
    <div class="modal fade in" id="UserDetails" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Detalles del usuario</h4>
                </div>
                <div class="modal-body">
                    <div class="card-content">
                        <div class="row">
                            <div class="col-md-12 text-center">
                                <div class="form-group">
                                    <div class="author">
                                        <img class="avatar border-white custom-image" id="D_UserPhoto" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <input class="form-control" id="D_txtFirstName" readonly="readonly" type="text" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Apellidos</label>
                                    <input class="form-control" id="D_txtLastName" readonly="readonly" type="text" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email</label>
                                    <input class="form-control" id="D_txtEmail" readonly="readonly" type="email" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Número de Cédula</label>
                                    <input class="form-control" id="D_txtIdCard" readonly="readonly" type="number" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Rol</label>
                                    <input class="form-control" id="D_ddlRole" readonly="readonly" type="text" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Número de Teléfono</label>
                                    <input class="form-control" id="D_txtTelephone" readonly="readonly" type="number" />
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal UserDetails -->

    <!-- Modal EditUser -->
    <div class="modal fade in" id="EditUser" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Editar Usuario</h4>
                </div>
                <div class="modal-body">
                    <div class="card-content">
                        <div class="row">
                            <div class="col-md-12 text-center">
                                <div class="form-group">
                                    <div class="author">
                                        <img class="avatar border-white custom-image" id="E_UserPhoto" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <input class="form-control" title="Digite el nombre del usuario" id="E_txtFirstName" required="required" type="text" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Apellidos</label>
                                    <input class="form-control" title="Digite los apellidos del usuario" id="E_txtLastName" required="required" type="text" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email</label>
                                    <input class="form-control" title="Digite el email del usuario" id="E_txtEmail" required="required" type="email" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Número de Cédula</label>
                                    <input class="form-control" title="Digite el número de cédula del usuario" id="E_txtIdCard" required="required" type="number" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Rol</label>
                                    <select id="E_ddlRole" class="form-control" title="Seleccione el rol del usuario" data-size="2" required="required">
                                        <option selected disabled hidden>Seleccione un rol</option>
                                        <option value="Administrador">Administrador</option>
                                        <option value="Técnico">Técnico</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Número de Teléfono</label>
                                    <input class="form-control" title="Digite el número de teléfono del usuario" id="E_txtTelephone" required="required" type="number" />
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
                                            <input type="file" accept="image/png, image/jpeg, image/gif" id="E_Photo" name="input-file-preview" />
                                        </div>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-info btn-fill btn-wd" onclick="UpdateUser()">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal EditUser -->
</asp:Content>

<asp:Content ID="JS" ContentPlaceHolderID="JS" runat="server">
    <script src="Scripts/UsersConfig.js"></script>
</asp:Content>
