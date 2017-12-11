<%@ Page Title="Login" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BostonScientific.UI.Login" %>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <div id="divUser" runat="server">
        <asp:TextBox CssClass="form-control" ToolTip="Introduzca su usuario" placeholder="Usuario" ID="txtUser" runat="server" />
        <span class="glyphicon glyphicon-user" />
    </div>

    <div id="divPassword" runat="server">
        <asp:TextBox CssClass="form-control" ToolTip="Introduzca su contraseña" placeholder="Contraseña" TextMode="Password" ID="txtPassword" runat="server" />
        <span class="glyphicon glyphicon-lock" />
    </div>

    <div class="link_error" runat="server">
        <asp:Label ID="lbError" runat="server" />
    </div>

    <asp:Button OnClick="btnUser_Click" class="btn btn-block btn-primary btn_login" ID="btnUser" runat="server" Text="Continuar" />
    <asp:Button OnClick="btnPassword_Click" class="btn btn-block btn-primary btn_login" ID="btnPassword" runat="server" Text="Iniciar Sesión" />
    <asp:Button OnClick="btnRestore_Click" class="btn btn-block btn-primary" ID="btnRestore" runat="server" Text="Restaurar Contraseña" />
    <asp:Button OnClick="btnReturn_Click" class="btn btn-block btn-primary" ID="btnReturn" runat="server" Text="Volver al inicio" />

    <section>
        <a id="link" class="link_forgotpassword" runat="server" href="ForgotPassword.aspx">Olvidaste la contraseña ?</a>
    </section>
</asp:Content>
