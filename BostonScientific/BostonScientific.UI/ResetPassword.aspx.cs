using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;

namespace BostonScientific.UI
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        private static string _UserName;
        private IUsers _users;
        private ITools _tools;

        public ResetPassword()
        {
            _users = new MUsers();
            _tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            divPassword.Visible = false;
            divPassword2.Visible = false;
            btnResetPassword.Visible = false;
            lbError.Visible = false;
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            _UserName = Request.QueryString["U"];
            var SecretCode = _tools.Encrypt(txtCode.Text);

            if (SecretCode == string.Empty)
            {
                lbError.Visible = true;
                lbError.Text = "Código Incorrecto";
            }
            else
            {
                switch (_users.CheckCode(_UserName, SecretCode))
                {
                    case true:
                        _users.SetRandomSecretCode(_UserName);

                        divPassword.Visible = true;
                        divPassword2.Visible = true;
                        btnResetPassword.Visible = true;

                        divSecretCode.Visible = false;
                        btnVerificar.Visible = false;

                        txtCode.Text = string.Empty;
                        lbError.Visible = false;
                        break;
                    case false:
                        lbError.Text = "Código Incorrecto";
                        lbError.Visible = true;
                        break;
                }
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            var Password = txtPassword.Text.ToUpper();
            var Password2 = txtPassword2.Text.ToUpper();

            if (Password == string.Empty || Password2 == string.Empty)
            {
                lbError.Visible = true;
                lbError.Text = "Contraseña Incorrecta";

                divPassword.Visible = true;
                divPassword2.Visible = true;
                btnResetPassword.Visible = true;
            }
            else
            {
                if (Password == Password2)
                {
                    Password = _tools.Encrypt(Password);
                    _users.UpdatePassword(_UserName, Password);
                    _users.DeleteFailedAttempts(_UserName);
                    _users.UnlockAccount(_UserName);

                    Response.Redirect("Login.aspx");
                }
                else
                {
                    divPassword.Visible = true;
                    divPassword2.Visible = true;
                    btnResetPassword.Visible = true;

                    lbError.Visible = true;
                    lbError.Text = "Las contraseñas no coinciden";
                }
            }
        }
    }
}