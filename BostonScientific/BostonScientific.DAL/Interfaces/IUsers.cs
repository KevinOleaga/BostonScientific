using BostonScientific.DATA;
using System.Collections.Generic;
using System.IO;

namespace BostonScientific.DAL.Interfaces
{
    public interface IUsers
    {
        #region Login.Master

        // Login 01
        bool Login01(string UserName);

        // Login 02
        bool Login02(string UserName, string Password);

        // GetUserStatus()
        string GetUserStatus(string UserName);

        // GetFailedAttempts()
        int GetFailedAttempts(string UserName);

        // CreateNewFailedAttempt()
        void CreateNewFailedAttempt(string UserName);

        // DeleteFailedAttempts()
        void DeleteFailedAttempts(string UserName);

        // UserExist()
        bool UserExist(string UserName);

        // GetUserEmail()
        string GetUserEmail(string UserName);

        // ResetPassword()
        bool ResetPassword(string UserEmail, string Body, string UserName);

        // CheckCode()
        bool CheckCode(string UserName, string SecretCode);

        // SetRandomSecretCode()
        void SetRandomSecretCode(string UserName);

        // UpdatePassword()
        void UpdatePassword(string UserName, string NewPassword);

        // UnlockAccount()
        void UnlockAccount(string UserName);

        #endregion Login.Master

        #region Site.Master

        // GetUserInfo()
        Users[] GetUserInfo(string UserName);

        // GetUserRole()
        string GetUserRole(int IdRole);

        // GetTotalUsers()
        int GetTotalMembers();

        // GetMembersInfo()
        Users[] GetMembersInfo();

        // GetMembersRole()
        Roles[] GetMembersRole(int IdRole);

        // SendFileToS3
        void SendFileToS3(Stream FileAddress, string FileName, string UserName);

        // UpdateProfile()
        void UpdateProfile(List<string> data, string UserName);

        // GetUsersInfo()
        Users[] GetUsersInfo();

        // DeleteUser()
        void DeleteUser(string UserName);
        
        // EditUser()
        void EditUser(Users EditUser);

        #endregion Site.Master
    }
}
