<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BostonScientific.UI.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-1" />

    <title>Login | Boston Scientific</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />

    <!-- CSS -->
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/login.css" />

    <!-- FONTS -->
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Lato:100italic,100,300italic,300,400italic,400,700italic,700,900italic,900" />
</head>

<body>
    <section id="logo">
        <img class="img-responsive custom_01" src="images/logo_blue.png" alt="Boston Scientific" />
    </section>
    
    <section class="container">
        <section class="row">
            <div class="col-md-13">
                <div class="card">
                    <form class="custom_06" role="login" runat="server">
                        <div id="divUser" runat="server">
                            <asp:TextBox CssClass="form-control" ToolTip="Introduzca su Email" placeholder="Usuario" TextMode="Email" ID="txtUser" runat="server" />
                            <span class="glyphicon glyphicon-user custom_02" />
                        </div>

                        <div id="divPassword" runat="server">
                            <asp:TextBox CssClass="form-control" ToolTip="Introduzca su Contraseña" placeholder="Contraseña" TextMode="Password" ID="txtPassword" runat="server" />
                            <span class="glyphicon glyphicon-lock custom_03" />
                        </div>

                        <asp:Label ID="lbError" class="custom_04" runat="server" />

                        <asp:Button OnClick="btnUser_Click" class="btn btn-block btn-primary custom_05" ID="btnUser" runat="server" Text="Continuar" />
                        <asp:Button OnClick="btnPassword_Click" class="btn btn-block btn-primary custom_05" ID="btnPassword" runat="server" Text="Iniciar Sesión" />
                        <a class="custom_07" href="ForgotPassword.aspx">Olvidaste la contraseña ?</a>
                    </form>
                </div>
            </div>
        </section>
    </section>
</body>
</html>