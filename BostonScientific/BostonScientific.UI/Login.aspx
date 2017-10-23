<%@ Page Title="Login" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BostonScientific.UI.Login" %>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <div id="divUser" runat="server">
        <asp:TextBox CssClass="form-control" AutoCompleteType="Disabled" ToolTip="Introduzca su usuario" placeholder="Usuario" ID="txtUser" runat="server" />
        <span class="glyphicon glyphicon-user custom_02" />
    </div>

    <div id="divPassword" runat="server">
        <asp:TextBox CssClass="form-control" AutoCompleteType="Disabled" ToolTip="Introduzca su contraseña" placeholder="Contraseña" TextMode="Password" ID="txtPassword" runat="server" />
        <span class="glyphicon glyphicon-lock custom_03" />
    </div>

    <asp:Label ID="lbError" class="custom_04" runat="server" />

    <asp:Button OnClick="btnUser_Click" class="btn btn-block btn-primary custom_05" ID="btnUser" runat="server" Text="Continuar" />
    <asp:Button OnClick="btnReturn_Click" class="btn btn-block btn-primary custom_05" ID="btnReturn" runat="server" Text="Volver" />
    <asp:Button OnClick="btnRestore_Click" class="btn btn-block btn-primary custom_05" ID="btnRestore" runat="server" Text="Restaurar cuenta" />
    <asp:Button OnClick="btnPassword_Click" class="btn btn-block btn-primary custom_05" ID="btnPassword" runat="server" Text="Iniciar Sesión" />
    <a runat="server" id="link" class="custom_07" href="ForgotPassword.aspx">Olvidaste la contraseña ?</a>
</asp:Content>
