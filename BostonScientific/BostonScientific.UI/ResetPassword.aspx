<%@ Page Title="Nueva Contraseña" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="BostonScientific.UI.ResetPassword" %>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <div id="divSecretCode" runat="server">
        <asp:TextBox CssClass="form-control" ToolTip="Introduzca su código de verificación" placeholder="Código de verificación" ID="txtCode" runat="server" />
        <span class="glyphicon glyphicon-key" />
    </div>

    <div id="divPassword" runat="server">
        <asp:TextBox CssClass="form-control" ToolTip="Introduzca su nueva contraseña" placeholder="Nueva contraseña" TextMode="Password" ID="txtPassword" runat="server" />
        <span class="glyphicon glyphicon-lock" />
    </div>

    <div id="divPassword2" class="div_Password2" runat="server">
        <asp:TextBox CssClass="form-control" ToolTip="Introduzca nuevamente su contraseña" placeholder="Reescriba su contraseña" TextMode="Password" ID="txtPassword2" runat="server" />
        <span class="glyphicon glyphicon-lock" />
    </div>

    <div class="link_error" runat="server">
        <asp:Label ID="lbError" runat="server" />
    </div>

    <asp:Button OnClick="btnVerificar_Click" class="btn btn-block btn-primary btn_login" ID="btnVerificar" runat="server" Text="Validar Código" />
    <asp:Button OnClick="btnResetPassword_Click" class="btn btn-block btn-primary btn_login" ID="btnResetPassword" runat="server" Text="Cambiar Contraseña" />

    <section>
        <a id="link" class="link_forgotpassword" runat="server" href="Login.aspx">Volver al inicio</a>
    </section>
</asp:Content>
