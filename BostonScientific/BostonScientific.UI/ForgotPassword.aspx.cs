using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using System;
using System.Diagnostics;
using System.IO;

namespace BostonScientific.UI
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private IUsers users;
        private ITools tools;

        public ForgotPassword()
        {
            users = new MUsers();
            tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Visible = false;
        }

        protected void btnRestoreAccount_Click(object sender, EventArgs e)
        {
            var UserName = tools.Encrypt(txtUser.Text.ToUpper());

            if (UserName == null)
            {
                lbError.Visible = true;
                lbError.Text = "Usuario inválido";
            }
            else if (users.Login01(UserName) == true)
            {
                var res = false;

                divEmail.Visible = false;
                btnEmail.Visible = false;
                lbError.Visible = false;

                res = users.ResetPassword(users.GetUserEmail(UserName), CreateBody(), UserName);

                switch (res)
                {
                    case true:
                        Debug.WriteLine("SweetAlert OK");
                        Response.Redirect("Login.aspx");
                        break;
                    case false:
                        Debug.WriteLine("SweetAlert");
                        break;
                }
            }
            else
            {
                lbError.Visible = true;
                lbError.Text = "Usuario inválido";
            }
        }

        public string CreateBody()
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