using BostonScientific.DAL;
using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using System;
using System.Diagnostics;
using System.Web.Security;

namespace BostonScientific.UI
{
    public partial class Login : System.Web.UI.Page
    {
        tools t = new tools();
        static string email, password;
        public IUsers users;

        public Login()
        {
            users = new MUsers();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            t.CreateTable();
            FormsAuthentication.SignOut();
            divPassword.Visible = false;
            btnPassword.Visible = false;
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            email = txtUser.Text.ToUpper();

            if (users.Login01(email) == 1)
            {
                divUser.Visible = false;
                btnUser.Visible = false;
                lbError.Visible = false;

                divPassword.Visible = true;
                btnPassword.Visible = true;
            }
            else
            {
                lbError.Text = "Usuario inválido";
                Debug.WriteLine("\nError: Usuario inválido. \nDescripción: El usuario " + email + " es inválido.");
            }
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            password = txtPassword.Text.ToUpper();

            if (users.Login02(email, password) == 1)
            {
                FormsAuthentication.RedirectFromLoginPage(email, true);
                Response.Redirect("Index.aspx");
            }
            else
            {
                divPassword.Visible = true;
                btnPassword.Visible = true;
                lbError.Visible = true;

                lbError.Text = "Contraseña inválida";
                Debug.WriteLine("\nError: Contraseña inválida. \nDescripción: La contraseña " + password + " es inválida.");
            }
        }
    }
}