using Amazon.S3.Transfer;
using BostonScientific.DAL;
using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using BostonScientific.DATA;
using System;
using System.Diagnostics;
using System.IO;

namespace BostonScientific.UI
{
    public partial class Profile : System.Web.UI.Page
    {
        tools tools = new tools();
        string photo = string.Empty;

        public IUsers users;
        public Profile()
        {
            users = new MUsers();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var res = users.UserInfo(Context.User.Identity.Name);
            var res_role = users.UserRole(Convert.ToInt32(res[0].IdRole));

            photo = res[0].Photo;
            user.Text = tools.Capitalize(res[0].FirstName + " " + res[0].LastName);
            email.Text = res[0].Email.ToLower();
            phrase.Text = res[0].Phrase;
            tel.Text = res[0].Telephone;
            role.Text = tools.Capitalize(res_role[0].Name);
            last_time.Text = res[0].LastTime;
            
            E_FirstName.Text = tools.Capitalize(res[0].FirstName);
            E_LastName.Text = tools.Capitalize(res[0].LastName);
            E_Role.Text = tools.Capitalize(res_role[0].Name);
            E_Telephone.Text = res[0].Telephone;
            E_Email.Text = res[0].Email.ToLower();
            E_Phrase.Value = res[0].Phrase;
        }

        public void Photo()
        {
            Response.Write(photo);
        }

        public void Members()
        {
            var cant = users.TotalUsers();
            var UsersInfo = users.UsersInfo();

            for (int i = 0; i < cant; i++)
            {
                var role = users.UserRole(Convert.ToInt32(UsersInfo[i].IdRole));
                Response.Write("<li>" +
                                   "<div class='row'>" +
                                       "<div class='col-xs-3'>" +
                                           "<div class='avatar'>" +
                                               "<img src='" + UsersInfo[i].Photo + "' class='img-circle img-no-padding img-responsive custom_10'>" +
                                           "</div>" +
                                       "</div>" +

                                       "<div class='col-xs-6 custom_17'>" +
                                           tools.Capitalize(UsersInfo[i].FirstName + " " + UsersInfo[i].LastName) + "<br />" +
                                           "<span><small class='custom_11'>" + role[0].Name + "</small></span><br />" +
                                           "<span><small class='custom_11'>" + UsersInfo[i].Telephone + "</small></span><br />" +
                                       "</div>" +

                                       "<div class='col-xs-3 text-right'>" +
                                           "<btn class='btn btn-sm btn-success btn-icon'><i class='fa fa-envelope'></i></btn>" +
                                       "</div>" +
                                   "</div>" +
                               "</li>");
            }
        }

        protected void btn_UpdateProfile_Click(object sender, EventArgs e)
        {
            var user = new Users
            {
                FirstName = E_FirstName.Text,
                LastName = E_LastName.Text,
                Telephone = E_Telephone.Text,
                Email = E_Email.Text,
                Phrase = E_Phrase.Value,
                Photo = ""
            };

            users.UpdateProfile();
            
            //var FileName = Path.GetFileName(E_Image.FileName);
            //var FileAddress = Path.GetFullPath(E_Image.FileName);

            //Debug.WriteLine(Path.GetFullPath(E_Image.FileName));
            
            //users.SendFileToS3(FileName, "FileAddress");
        }
    }
}