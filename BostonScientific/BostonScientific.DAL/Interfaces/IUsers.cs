using BostonScientific.DATA;

namespace BostonScientific.DAL.Interfaces
{
    public interface IUsers
    {
        #region Login.aspx

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
     
        #endregion
        
        #region ForgotPassword.aspx

        // GetUserEmail()
        string GetUserEmail(string UserName);

        // ResetPassword()
        bool ResetPassword(string UserEmail, string Body, string UserName);

        #endregion ForgotPassword.aspx

        void UnlockAccount(string UserName);
        void DeleteUser(string UserName);
        Users[] UserInfo(string email);
        Roles[] UserRole(int idRole);
        Users[] UsersInfo();
        int TotalUsers();
        void SendFileToS3(string Name, string FileAddress);
        void UpdateProfile(string Email_, string FirstName_, string LastName_, string Telephone_, string Phrase_, string Photo_);
        Users[] GetUserInfo(string UserName);
    }
}
