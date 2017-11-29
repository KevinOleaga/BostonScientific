using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.IO;

namespace BostonScientific.UI
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
       private static string _UserName;
        private IUsers _users;
        private ITools _tools;

        public ForgotPassword()
        {
            _users = new MUsers();
            _tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Visible = false;
        }

        protected void btnRestoreAccount_Click(object sender, EventArgs e)
        {
            _UserName = txtUser.Text.ToUpper();

            if (_UserName == string.Empty)
            {
                lbError.Visible = true;
                lbError.Text = "Usuario inválido";
            }
            else
            {
                _UserName = _tools.Encrypt(_UserName);
                switch (_users.UserExist(_UserName))
                {
                    case true:
                        lbError.Visible = false;

                        _users.ResetPassword(_users.GetUserEmail(_UserName), CreateBody(), _UserName);
                        Response.Redirect("Login.aspx");
                        break;
                    case false:
                        lbError.Visible = true;
                        lbError.Text = "Usuario inválido";
                        break;
                }
            }
        }

        private string CreateBody()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(MapPath("EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }

            return body;
        }
    }
}