using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using System;
using System.Diagnostics;
using System.Web.Security;

namespace BostonScientific.UI
{
    public partial class Login : System.Web.UI.Page
    {
        private static string UserName, Password;
        private IUsers users;
        private ITools tools;

        public Login()
        {
            users = new MUsers();
            tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            divPassword.Visible = false;
            btnPassword.Visible = false;
            btnRestore.Visible = false;
            btnReturn.Visible = false;
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            UserName = txtUser.Text;

            if (UserName == null)
            {
                lbError.Visible = true;
                lbError.Text = "Usuario inválido";
            }
            else if (users.Login01(tools.Encrypt(UserName.ToUpper())) == true)
            {
                var res = users.GetUserStatus(tools.Encrypt(UserName.ToUpper()));

                switch (res)
                {
                    case "Activo":
                        divUser.Visible = false;
                        btnUser.Visible = false;

                        divPassword.Visible = true;
                        btnPassword.Visible = true;

                        btnReturn.Visible = false;
                        btnRestore.Visible = false;

                        lbError.Visible = false;
                        break;
                    case "Bloqueado":
                        lbError.Visible = true;
                        lbError.Text = "Cuenta Bloqueada.";

                        divUser.Visible = false;
                        btnUser.Visible = false;

                        divPassword.Visible = false;
                        btnPassword.Visible = false;

                        btnReturn.Visible = true;
                        btnRestore.Visible = true;

                        link.Visible = false;
                        break;
                }
            }
            else
            {
                lbError.Visible = true;
                lbError.Text = "Usuario inválido";
                Debug.WriteLine("\nError: Usuario inválido. \nDescripción: El usuario " + UserName + " es inválido.");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            txtUser.Text = string.Empty;

            divUser.Visible = true;
            btnUser.Visible = true;

            lbError.Visible = false;
            link.Visible = true;
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            Password = txtPassword.Text;

            if (Password == null)
            {
                lbError.Visible = true;
                lbError.Text = "Contraseña incorrecta";
            }
            else if (users.Login02(tools.Encrypt(UserName.ToUpper()), tools.Encrypt(Password.ToUpper())) == true)
            {
                var res = users.GetUserStatus(tools.Encrypt(UserName.ToUpper()));

                switch (res)
                {
                    case "Activo":
                        users.DeleteFailedAttempts(tools.Encrypt(UserName.ToUpper()));
                        FormsAuthentication.RedirectFromLoginPage(UserName, true);
                        Response.Redirect("Index.aspx");
                        break;
                    case "Bloqueado":
                        lbError.Visible = true;
                        lbError.Text = "Cuenta Bloqueada.";

                        divUser.Visible = false;
                        btnUser.Visible = false;

                        divPassword.Visible = false;
                        btnPassword.Visible = false;

                        btnReturn.Visible = true;
                        btnRestore.Visible = true;

                        link.Visible = false;
                        break;
                }
            }
            else
            {
                var res = users.GetUserStatus(tools.Encrypt(UserName.ToUpper()));
                var n = 0;

                switch (res)
                {
                    case "Activo":
                        users.CreateNewFailedAttempt(tools.Encrypt(UserName.ToUpper()));
                        n = users.GetFailedAttempts(tools.Encrypt(UserName.ToUpper()));

                        if (n == 3)
                        {
                            lbError.Visible = true;
                            lbError.Text = "Cuenta Bloqueada. Intento(" + n + "/3)";

                            divUser.Visible = false;
                            btnUser.Visible = false;

                            divPassword.Visible = false;
                            btnPassword.Visible = false;

                            btnReturn.Visible = true;
                            btnRestore.Visible = true;

                            link.Visible = false;
                        }
                        else
                        {
                            lbError.Visible = true;
                            lbError.Text = "Contraseña inválida. Intento(" + n + "/3)";

                            divPassword.Visible = true;
                            btnPassword.Visible = true;
                        }
                        break;
                    case "Bloqueado":
                        n = users.GetFailedAttempts(tools.Encrypt(UserName.ToUpper()));

                        lbError.Visible = true;
                        lbError.Text = "Cuenta Bloqueada. Intento(" + n + "/3)";

                        divUser.Visible = false;
                        btnUser.Visible = false;

                        divPassword.Visible = false;
                        btnPassword.Visible = false;

                        btnReturn.Visible = true;
                        btnRestore.Visible = true;

                        link.Visible = false;
                        break;
                }
            }
        }
    }
}