<%@ Page Title="Restaurar Contraseña" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="BostonScientific.UI.ForgotPassword" %>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <asp:Label ID="lbTitle" runat="server" Text="Restablecer Contraseña" />
    
    <div id="divEmail" runat="server">
        <asp:TextBox CssClass="form-control" AutoCompleteType="Disabled" placeholder="Introduzca su usuario" ID="txtUser" runat="server" />
        <span class="glyphicon glyphicon-user custom_02" />
    </div>

    <script type="text/javascript">
        function successalert() {

        }
    </script>

    <asp:Label ID="lbError" class="custom_04" runat="server" />
    <asp:Button OnClick="btnRestoreAccount_Click" class="btn btn-block btn-primary custom_05" ID="btnEmail" runat="server" Text="Continuar" />
</asp:Content>
