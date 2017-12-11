using BostonScientific.BLL.Interfaces;
using BostonScientific.DATA;
using System.Collections.Generic;
using System.IO;

namespace BostonScientific.BLL.Methods
{
    public class MUsers : IUsers
    {
        private DAL.Interfaces.IUsers _users;
        public MUsers()
        {
            _users = new DAL.Methods.MUsers();
        }

        #region Login.Master

        // Login 01()
        public bool Login01(string UserName)
        {
            return _users.Login01(UserName);
        }

        // Login 02()
        public bool Login02(string UserName, string Password)
        {
            return _users.Login02(UserName, Password);
        }

        // GetUserStatus()
        public string GetUserStatus(string UserName)
        {
            return _users.GetUserStatus(UserName);
        }

        // GetFailedAttempts()
        public int GetFailedAttempts(string UserName)
        {
            return _users.GetFailedAttempts(UserName);
        }

        // CreateNewFailedAttempt()
        public void CreateNewFailedAttempt(string UserName)
        {
            _users.CreateNewFailedAttempt(UserName);
        }

        // DeleteFailedAttempts()
        public void DeleteFailedAttempts(string UserName)
        {
            _users.DeleteFailedAttempts(UserName);
        }

        // UserExist()
        public bool UserExist(string UserName)
        {
            return _users.UserExist(UserName);
        }

        // GetUserEmail()
        public string GetUserEmail(string UserName)
        {
            return GetUserEmail(UserName);
        }

        // ResetPassword()
        public bool ResetPassword(string UserEmail, string Body, string UserName)
        {
            return _users.ResetPassword(UserEmail, Body, UserName);
        }

        // CheckCode()
        public bool CheckCode(string UserName, string SecretCode)
        {
            return _users.CheckCode(UserName, SecretCode);
        }

        // SetRandomSecretCode()
        public void SetRandomSecretCode(string UserName)
        {
            _users.SetRandomSecretCode(UserName);
        }

        // UpdatePassword()
        public void UpdatePassword(string UserName, string NewPassword)
        {
            _users.UpdatePassword(UserName, NewPassword);
        }

        // UnlockAccount()
        public void UnlockAccount(string UserName)
        {
            _users.UnlockAccount(UserName);
        }

        #endregion Login.Master

        #region Site.Master

        // GetUserInfo()
        public Users[] GetUserInfo(string UserName)
        {
            return _users.GetUserInfo(UserName);
        }

        // GetUserRole()
        public string GetUserRole(int IdRole)
        {
            return _users.GetUserRole(IdRole);
        }

        // GetTotalUsers()
        public int GetTotalMembers()
        {
            return _users.GetTotalMembers();
        }

        // GetMembersInfo()
        public Users[] GetMembersInfo()
        {
            return _users.GetMembersInfo();
        }

        // GetMembersRole()
        public Roles[] GetMembersRole(int IdRole)
        {
            return _users.GetMembersRole(IdRole);
        }

        // SendFileToS3
        public void SendFileToS3(Stream FileAddress, string FileName, string UserName)
        {
            _users.SendFileToS3(FileAddress, FileName, UserName);
        }

        // UpdateProfile()
        public void UpdateProfile(List<string> data, string UserName)
        {
            _users.UpdateProfile(data, UserName);
        }

        // GetUsersInfo()
        public Users[] GetUsersInfo()
        {
            return _users.GetUsersInfo();
        }

        // DeleteUser()
        public void DeleteUser(string UserName)
        {
            _users.DeleteUser(UserName);
        }
        
        // EditUser()
        public void EditUser(Users EditUser)
        {
            _users.EditUser(EditUser);
        }

        #endregion Site.Master

        #region Managment

        // CreateTable()
        public void CreateTable()
        {
            _users.CreateTable();
        }

        // DropTable()
        public void DropTable()
        {
            _users.DropTable();
        }

        // DeleteTable()
        public void DeleteTable()
        {
            _users.DeleteTable();
        }

        #endregion Managment
    }
}