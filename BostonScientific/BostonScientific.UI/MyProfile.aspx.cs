using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BostonScientific.UI
{
    public partial class MyProfile : System.Web.UI.Page
    {
        private static string _UserName;
        string photo = string.Empty;

        private IUsers _users;
        private ITools _tools;

        public MyProfile()
        {
            _users = new MUsers();
            _tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _UserName = Context.User.Identity.Name;

            var res = _users.GetUserInfo(_UserName);
            photo = _tools.Decrypt(res[0].Photo);
            user.Text = _tools.Capitalize(_tools.Decrypt(res[0].FirstName) + " " + _tools.Decrypt(res[0].LastName));
            email.Text = _tools.Decrypt(res[0].Email).ToLower();
            phrase.Text = _tools.Decrypt(res[0].Phrase);
            username.Text = _tools.Decrypt(res[0].UserName);
            tel.Text = _tools.Decrypt(res[0].Telephone);
            role.Text = _tools.Capitalize(_users.GetUserRole(res[0].IdRole));
            
            E_Role.Text = role.Text;
            E_IdCard.Text = _tools.Decrypt(res[0].IdCard);
        }

        public void Photo()
        {
            Response.Write(photo);
        }

        public void Members()
        {
            var TotalMembers = _users.GetTotalMembers();
            var MembersInfo = _users.GetMembersInfo();

            for (int i = 0; i < TotalMembers; i++)
            {
                var MembersRole = _users.GetMembersRole(MembersInfo[i].IdRole);
                Response.Write("<li>" +
                                   "<div class='row'>" +
                                       "<div class='col-xs-3'>" +
                                           "<div class='avatar'>" +
                                               "<img src='" + _tools.Decrypt(MembersInfo[i].Photo) + "' class='img-circle img-no-padding img-responsive custom_10'>" +
                                           "</div>" +
                                       "</div>" +

                                       "<div class='col-xs-6 custom_17'>" +
                                           _tools.Capitalize(_tools.Decrypt(MembersInfo[i].FirstName) + " " + _tools.Decrypt(MembersInfo[i].LastName)) + "<br />" +
                                           "<span><small class='custom_11'>" + _tools.Capitalize(_tools.Decrypt(MembersRole[0].Name)) + "</small></span><br />" +
                                           "<span><small class='custom_11'>" + _tools.Decrypt(MembersInfo[i].Telephone) + "</small></span><br />" +
                                       "</div>" +
                                   "</div>" +
                               "</li>");
            }
        }

        protected void btn_UpdateProfile_Click(object sender, EventArgs e)
        {
            if (E_FirstName.Text == string.Empty || E_LastName.Text == string.Empty || E_Email.Text == string.Empty || E_Telephone.Text == string.Empty ||  E_Phrase.Value == string.Empty)
            {
                // Do nothing
            }
            else
            {
                List<string> data = new List<string>();

                data.Add(_tools.Encrypt(E_FirstName.Text.ToUpper()));
                data.Add(_tools.Encrypt(E_LastName.Text.ToUpper()));
                data.Add(_tools.Encrypt(E_Email.Text.ToUpper()));
                data.Add(_tools.Encrypt(E_Telephone.Text));
                data.Add(_tools.Encrypt(E_Phrase.Value));

                _users.UpdateProfile(data, _UserName);
            }

            Stream FileStream = E_Image.PostedFile.InputStream;            
            string FileName = Path.GetFileName(E_Image.FileName);
            
            if (FileName != string.Empty)
            {
                _users.SendFileToS3(FileStream, FileName, _UserName);
            }

            Response.Redirect("MyProfile.aspx");

        }
    }
}