<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelView.aspx.cs" Inherits="BostonScientific.UI.PanelView" %>

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
                <a class="navbar-brand" href="#Panels">Vista del Panel
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
        <div class="card custom-size">
            <div class="card-header">
                <h4 class="card-title">
                    <asp:Label ID="lb_IdPanel" runat="server"></asp:Label>
                </h4>
                <p class="category">
                    <asp:Label ID="lb_Description" runat="server"></asp:Label>
                </p>
                <br />
                <div class="custom-btns">
                    <button type="button" class="btn btn-center" data-toggle="modal" data-target="#SelectBreakers">Ver información del panel</button>
                    <button type="button" class="btn btn-center" data-toggle="modal" data-target="#CreateSwitch">Crear Switch</button>
                </div>
                <br />
            </div>
            <div class="card-content">
                <div class="col-md-6">
                    <div class="card-content table-responsive table-full-width">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="text-center">CKT</th>
                                    <th class="text-center">Descripción</th>
                                    <th class="text-center">AMP</th>
                                    <th class="text-center">Polo</th>
                                    <th class="text-center">Ver switch</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% prueba(); %>
                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="card-content table-responsive table-full-width">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="text-center">CKT</th>
                                    <th class="text-center">Descripción</th>
                                    <th class="text-center">AMP</th>
                                    <th class="text-center">Polo</th>
                                    <th class="text-center">Ver switch</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% prueba1(); %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal CreateSwitch -->
    <div class="modal fade in" id="SelectBreakers" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Editar panel</h4>
                </div>
                <div class="modal-body">

<button id="btnValoresSeleccionados" type="button" class="btn btn-primary">Valores Seleccionadas</button>
<hr />
<table id="myTable" class="table" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Age</th>
                <th>Start date</th>
                <th>Salary</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Age</th>
                <th>Start date</th>
                <th>Salary</th>
            </tr>
        </tfoot>
        <tbody>
            <tr>
                <td>Tiger Nixon</td>
                <td>System Architect</td>
                <td>Edinburgh</td>
                <td>61</td>
                <td>2011/04/25</td>
                <td>$320,800</td>
            </tr>
            <tr>
                <td>Garrett Winters</td>
                <td>Accountant</td>
                <td>Tokyo</td>
                <td>63</td>
                <td>2011/07/25</td>
                <td>$170,750</td>
            </tr>
            <tr>
                <td>Ashton Cox</td>
                <td>Junior Technical Author</td>
                <td>San Francisco</td>
                <td>66</td>
                <td>2009/01/12</td>
                <td>$86,000</td>
            </tr>
            <tr>
                <td>Cedric Kelly</td>
                <td>Senior Javascript Developer</td>
                <td>Edinburgh</td>
                <td>22</td>
                <td>2012/03/29</td>
                <td>$433,060</td>
            </tr>
            <tr>
                <td>Airi Satou</td>
                <td>Accountant</td>
                <td>Tokyo</td>
                <td>33</td>
                <td>2008/11/28</td>
                <td>$162,700</td>
            </tr>
            <tr>
                <td>Brielle Williamson</td>
                <td>Integration Specialist</td>
                <td>New York</td>
                <td>61</td>
                <td>2012/12/02</td>
                <td>$372,000</td>
            </tr>
            <tr>
                <td>Herrod Chandler</td>
                <td>Sales Assistant</td>
                <td>San Francisco</td>
                <td>59</td>
                <td>2012/08/06</td>
                <td>$137,500</td>
            </tr>
            <tr>
                <td>Rhona Davidson</td>
                <td>Integration Specialist</td>
                <td>Tokyo</td>
                <td>55</td>
                <td>2010/10/14</td>
                <td>$327,900</td>
            </tr>
            <tr>
                <td>Colleen Hurst</td>
                <td>Javascript Developer</td>
                <td>San Francisco</td>
                <td>39</td>
                <td>2009/09/15</td>
                <td>$205,500</td>
            </tr>
            <tr>
                <td>Sonya Frost</td>
                <td>Software Engineer</td>
                <td>Edinburgh</td>
                <td>23</td>
                <td>2008/12/13</td>
                <td>$103,600</td>
            </tr>
            <tr>
                <td>Jena Gaines</td>
                <td>Office Manager</td>
                <td>London</td>
                <td>30</td>
                <td>2008/12/19</td>
                <td>$90,560</td>
            </tr>
            <tr>
                <td>Quinn Flynn</td>
                <td>Support Lead</td>
                <td>Edinburgh</td>
                <td>22</td>
                <td>2013/03/03</td>
                <td>$342,000</td>
            </tr>
        </tbody>
    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btnCancel_customColor" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btnOK_customColor" onclick="UpdatePanel()">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal CreateSwitch -->


    <!-- Modal CreateSwitch -->
    <div class="modal fade in" id="CreateSwitch" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Crear Switch</h4>
                </div>
                <div class="modal-body">
                    <div class="card-content">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Tipo de breaker</label>
                                    <asp:TextBox CssClass="form-control border-input" ToolTip="Digite el tipo de breaker" ID="txtBreaker" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Corriente</label>
                                    <asp:TextBox CssClass="form-control border-input" ToolTip="Digite la corriente" ID="txtCorriente" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Calibre</label>
                                    <asp:TextBox CssClass="form-control border-input" ToolTip="Digite el calibre" ID="txtCalibre" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Comentarios</label>
                                    <textarea runat="server" id="txtComments" rows="5" class="form-control border-input" placeholder="Comentarios..."></textarea>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Subir Archivo</label>
                                <div class="input-group image-preview">
                                    <input type="text" class="form-control image-preview-filename" disabled="disabled">
                                    <span class="input-group-btn">
                                        <button type="button" class="btn btn-default image-preview-clear" style="display: none;">
                                            <span class="glyphicon glyphicon-remove"></span>Limpiar
                   
                                        </button>
                                        <div class="btn btn-default image-preview-input">
                                            <span class="glyphicon glyphicon-folder-open"></span>
                                            <span class="image-preview-input-title">Buscar</span>
                                            <asp:FileUpload ID="fileUpload" runat="server" />
                                        </div>
                                    </span>
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
    <!-- End Modal CreateSwitch -->
</asp:Content>
