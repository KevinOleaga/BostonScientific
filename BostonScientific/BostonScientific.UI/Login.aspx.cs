using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.Web.Security;

namespace BostonScientific.UI
{
    public partial class Login : System.Web.UI.Page
    {
        private static string _UserName, _Password;
        private IUsers _users;
        private ITools _tools;

        public Login()
        {
            _users = new MUsers();
            _tools = new MTools();
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
            _UserName = txtUser.Text.ToUpper();

            if (_UserName == string.Empty)
            {
                lbError.Text = "Usuario Inválido";
            }
            else
            {
                _UserName = _tools.Encrypt(_UserName);

                switch (_users.Login01(_UserName))
                {
                    case true:
                        var res = _users.GetUserStatus(_UserName);

                        if (res == "Activo")
                        {
                            divUser.Visible = false;
                            btnUser.Visible = false;

                            divPassword.Visible = true;
                            btnPassword.Visible = true;

                            btnReturn.Visible = false;
                            btnRestore.Visible = false;

                            lbError.Visible = false;
                        }
                        else
                        {
                            divUser.Visible = false;
                            btnUser.Visible = false;

                            divPassword.Visible = false;
                            btnPassword.Visible = false;

                            btnReturn.Visible = true;
                            btnRestore.Visible = true;

                            lbError.Visible = true;
                            lbError.Text = "Usuario Bloqueado";

                            link.Visible = false;
                        }
                        break;
                    case false:
                        txtUser.Text = string.Empty;

                        lbError.Visible = true;
                        lbError.Text = "Usuario Inválido";
                        break;
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            txtUser.Text = string.Empty;

            divUser.Visible = true;
            btnUser.Visible = true;

            link.Visible = true;
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            _Password = txtPassword.Text.ToUpper();

            if (_Password == string.Empty)
            {
                lbError.Text = "Contraseña Inválida";
            }
            else
            {
                _Password = _tools.Encrypt(_Password);

                switch (_users.Login02(_UserName, _Password))
                {
                    case true:
                        var res = _users.GetUserStatus(_UserName);

                        if (res == "Activo")
                        {
                            _users.DeleteFailedAttempts(_UserName);

                            FormsAuthentication.RedirectFromLoginPage(_UserName, true);
                            Response.Redirect("Index.aspx");
                        }
                        else if (res == "Bloqueado")
                        {
                            divUser.Visible = false;
                            btnUser.Visible = false;

                            divPassword.Visible = false;
                            btnPassword.Visible = false;

                            btnReturn.Visible = true;
                            btnRestore.Visible = true;

                            lbError.Visible = true;
                            lbError.Text = "Usuario Bloqueado";

                            link.Visible = false;
                        }
                        break;
                    case false:
                        res = _users.GetUserStatus(_UserName);
                        var n = 0;

                        if (res == "Activo")
                        {
                            _users.CreateNewFailedAttempt(_UserName);
                            n = _users.GetFailedAttempts(_UserName);

                            if (n == 3)
                            {
                                divUser.Visible = false;
                                btnUser.Visible = false;

                                divPassword.Visible = false;
                                btnPassword.Visible = false;

                                btnReturn.Visible = true;
                                btnRestore.Visible = true;

                                lbError.Visible = true;
                                lbError.Text = string.Format("Usuario bloqueado");

                                link.Visible = false;
                            }
                            else
                            {
                                lbError.Visible = true;
                                lbError.Text = string.Format("Contraseña Incorrecta");

                                divPassword.Visible = true;
                                btnPassword.Visible = true;
                            }
                        }
                        else if (res == "Bloqueado")
                        {
                            n = _users.GetFailedAttempts(_UserName);

                            divUser.Visible = false;
                            btnUser.Visible = false;

                            divPassword.Visible = false;
                            btnPassword.Visible = false;

                            btnReturn.Visible = true;
                            btnRestore.Visible = true;

                            lbError.Visible = true;
                            lbError.Text = string.Format("Usuario bloqueado");

                            link.Visible = false;
                        }
                        break;
                }
            }
        }
    }
}