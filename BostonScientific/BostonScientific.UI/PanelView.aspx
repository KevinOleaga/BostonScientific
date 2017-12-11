<%@ Page Title="Vista del Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelView.aspx.cs" Inherits="BostonScientific.UI.PanelView" %>

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
                <a class="navbar-brand" href="#">Vista del Panel</a>
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
        <div class="card custom-size">
            <div class="card-content">
                <div class="col-md-6 ">
                    <div class="form-group" style="margin-top: 4%;">
                        <h4 class="card-title">
                            <asp:Label ID="lb_IdPanel" runat="server"></asp:Label>
                        </h4>
                        <p class="category custom-card">
                            <asp:Label ID="lb_Description" runat="server"></asp:Label><br />
                            <asp:Label ID="lb_SpacesAvailable" runat="server"></asp:Label>
                        </p>
                        <div class="btns">
                            <button type="button" class="btn btnOK_customColor" data-toggle="modal" data-target="#SelectBreakers">Ver información del panel</button>
                            <button type="button" class="btn btnOK_customColor" data-toggle="modal" data-target="#CreateSwitch">Crear Switch</button>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <br />
                        <textarea runat="server" id="atxtComments" rows="3" class="form-control border-input" placeholder="Comentarios..."></textarea>
                        <button type="button" class="btn btnOK_customColor custom_btn_save" data-toggle="modal" data-target="#SelectBreakers">Guardar</button>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="card-content">
                        <table id="bootstrap-table" class="table">
                            <thead>
                                <th data-field="CKT" class="text-center">CKT</th>
                                <th data-field="IdSwitch" class="text-center Remove"></th>
                                <th data-field="Estado" class="text-center">Estado</th>
                                <th data-field="AMP" class="text-center">AMP</th>
                                <th data-field="Polo" class="text-center">Polo</th>
                                <th data-field="actions" class="td-actions text-center" data-events="operateEvents" data-formatter="operateFormatter">Ver</th>
                            </thead>
                            <tbody>
                                <% ListSwitches_01(); %>
                            </tbody>
                        </table>
                    </div>
                </div>
                <!--  end card  -->

                <div class="col-md-6">
                    <div class="card-content">
                        <table id="bootstrap-table2" class="table">
                            <thead>
                                <th data-field="CKT" class="text-center">CKT</th>
                                <th data-field="IdSwitch" class="text-center Remove"></th>
                                <th data-field="Estado" class="text-center">Estado</th>
                                <th data-field="AMP" class="text-center">AMP</th>
                                <th data-field="Polo" class="text-center">Polo</th>
                                <th data-field="actions" class="td-actions text-center" data-events="operateEvents" data-formatter="operateFormatter">Ver</th>
                            </thead>
                            <tbody>
                                <% ListSwitches_02(); %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- modal CreateSwitch -->
    <div class="modal fade in" id="CreateSwitch" role="dialog">
        <div class="modal-dialog modal_custom">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Crear Switch</h4>
                </div>
                <!-- end modal-header -->
                <!-- end modal-header -->
                <div class="modal-body">
                    <div class="card-content">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Tipo de breaker</label>
                                            <select id="ddlType" class="form-control" title="Tipo de breaker" data-size="3" required="required">
                                                <option value="Monofasico">Monofasico</option>
                                                <option value="Bifasico">Bifasico</option>
                                                <option value="Trifasico">Trifasico</option>
                                            </select>
                                        </div>
                                        <!-- end form-group -->
                                    </div>
                                    <!-- end col-md-3 -->
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Seleccione los switches</label>
                                            <select multiple id="ddlSwitches" title="Switches" class="selectpicker custom_cbx" data-style="btn-info btn-fill btn-block custom_cbx" data-size="7" required="required">
                                                <option value="01">01</option>
                                                <option value="02">02</option>
                                                <option value="03">03</option>
                                                <option value="04">04</option>
                                                <option value="05">05</option>
                                                <option value="06">06</option>
                                                <option value="07">07</option>
                                                <option value="08">08</option>
                                                <option value="09">09</option>
                                                <option value="10">10</option>
                                                <option value="11">11</option>
                                                <option value="12">12</option>
                                                <option value="13">13</option>
                                                <option value="14">14</option>
                                                <option value="15">15</option>
                                                <option value="16">16</option>
                                                <option value="17">17</option>
                                                <option value="18">18</option>
                                                <option value="19">19</option>
                                                <option value="20">20</option>
                                                <option value="21">21</option>
                                                <option value="22">22</option>
                                                <option value="23">23</option>
                                                <option value="24">24</option>
                                                <option value="25">25</option>
                                                <option value="26">26</option>
                                                <option value="27">27</option>
                                                <option value="28">28</option>
                                                <option value="29">29</option>
                                                <option value="30">30</option>
                                                <option value="31">31</option>
                                                <option value="32">32</option>
                                                <option value="33">33</option>
                                                <option value="34">34</option>
                                                <option value="35">35</option>
                                                <option value="36">36</option>
                                                <option value="37">37</option>
                                                <option value="38">38</option>
                                                <option value="39">39</option>
                                                <option value="40">40</option>
                                                <option value="41">41</option>
                                                <option value="42">42</option>
                                            </select>
                                        </div>
                                        <!-- end form-group -->
                                    </div>
                                    <!-- end col-md-3 -->
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Corriente</label>
                                            <input class="form-control" title="Introduzca la corriente del switch" id="txtCurrent" type="text" required="required" />
                                        </div>
                                        <!-- end form-group -->
                                    </div>
                                    <!-- end col-md-3 -->
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Calibre</label>
                                            <input class="form-control" title="Introduzca el calibre del switch" id="txtCaliber" type="text" required="required" />
                                        </div>
                                        <!-- end form-group -->
                                    </div>
                                    <!-- end col-md-3 -->
                                </div>
                                <!-- end row -->
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Comentarios</label>
                                            <textarea class="form-control border-input" title="Comentarios..." id="txtComments" rows="3"></textarea>
                                        </div>
                                        <!-- end form-group -->
                                    </div>
                                    <!-- end col-md-12 -->
                                </div>
                                <!-- end row -->
                            </div>
                            <!-- end col-md-9 -->
                        </div>
                        <!-- end row -->
                        <div class="clearfix"></div>
                        <div class="modal-footer">
                            <button type="button" class="btn btnCancel_customColor" data-dismiss="modal">Cerrar</button>
                            <button type="button" class="btn btnOK_customColor" onclick="CreateSwitch()">Actualizar</button>
                        </div>
                        <!-- end modal-footer -->
                    </div>
                    <!-- end card-content -->
                </div>
                <!-- end modal-body -->
            </div>
            <!-- end Modal EditPanel -->
        </div>
        <!-- end modal-dialog modal-custom -->
    </div>
    <!-- end modal fade in -->
    <!-- end modal CreateSwitch -->
    <button type='button' class='btn btnOK_customColor' onclick='ShowSwitch()'>Actualizar</button>
</asp:Content>

<asp:Content ID="JS" ContentPlaceHolderID="JS" runat="server">
    <script src="Scripts/PanelView.js"></script>
</asp:Content>
