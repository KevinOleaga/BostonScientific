using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.IO;
using System.Web.Services;

namespace BostonScientific.UI
{
    public partial class UsersConfig : System.Web.UI.Page
    {
        private static IUsers _users;
        private static ITools _tools;
        public static string UserName;
        public static string photo;

        public UsersConfig()
        {
            _users = new MUsers();
            _tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e) { }

        protected void UsersInfo()
        {
            var res = _users.GetUsersInfo();

            for (int i = 0; i < _users.GetTotalMembers(); i++)
            {
                Response.Write("<tr>" +
                                 "<td>" + _tools.Decrypt(res[i].UserName) + "</td>" +
                                 "<td>" + _tools.Capitalize(_tools.Decrypt(res[i].FirstName) + " " + _tools.Decrypt(res[i].LastName)) + "</td>" +
                                 "<td>" + _tools.Capitalize(_users.GetUserRole(res[i].IdRole)) + "</td>" +
                                 "<td>" + _tools.Decrypt(res[i].Telephone) + "</td>" +
                                 "<td>" + _tools.Decrypt(res[i].Email).ToLower() + "</td>" +
                                 "<td></td>" +
                               "</tr>");
            }
        }

        [WebMethod]
        public static DATA.Users[] GetUserInfo(string UserName)
        {
            UserName = _tools.Encrypt(UserName);
            var res = _users.GetUserInfo(UserName);

            res[0].FirstName = _tools.Capitalize(_tools.Decrypt(res[0].FirstName));
            res[0].LastName = _tools.Capitalize(_tools.Decrypt(res[0].LastName));
            res[0].Email = _tools.Decrypt(res[0].Email).ToLower();
            res[0].IdCard = _tools.Decrypt(res[0].IdCard);
            // res[0].IdRole is a int so we use res[0].Phrase because it's a string
            res[0].Phrase = _tools.Capitalize(_users.GetUserRole(res[0].IdRole));
            res[0].Telephone = _tools.Decrypt(res[0].Telephone);
            res[0].Photo = _tools.Decrypt(res[0].Photo);
            return res;
        }

        [WebMethod]
        public static string CreateUser()
        {
            return "PanelView.aspx?C=";
        }

        [WebMethod]
        public static string EditUser()
        {
            return "PanelView.aspx?C=";
        }
        
        [WebMethod]
        public static void DeleteUser(string UserName)
        {
            UserName = _tools.Encrypt(UserName);
            _users.DeleteUser(UserName);
        }
    }
}