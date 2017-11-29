<%@ Page Title="Restaurar Contraseña" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="BostonScientific.UI.ForgotPassword" %>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <asp:Label ID="lbTitle" runat="server" Text="Restablecer Contraseña" />
    
    <div id="divUser" class="div_User" runat="server">
        <asp:TextBox CssClass="form-control" ToolTip="Introduzca su Usuario" placeholder="Usuario" ID="txtUser" runat="server" />
        <span class="glyphicon glyphicon-user" />
    </div>

    <div class="link_error" runat="server">
        <asp:Label ID="lbError" runat="server" />
    </div>

    <asp:Button OnClick="btnRestoreAccount_Click" class="btn btn-block btn-primary btn_login" ID="btnRestore" runat="server" Text="Continuar" />
</asp:Content>
