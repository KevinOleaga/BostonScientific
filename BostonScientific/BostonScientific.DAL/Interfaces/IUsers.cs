using BostonScientific.DATA;

namespace BostonScientific.DAL.Interfaces
{
    public interface IUsers
    {
        // Login 01
        bool Login01(string email);
        
        // Login 02
        bool Login02(string email, string password);

        // UserInfo()
        Users[] UserInfo(string email);

        // UserRole
        Roles[] UserRole(int idRole);

        // UsersInfo()
        Users[] UsersInfo();

        // TotalUsers()
        int TotalUsers();

        // SendFileToS3()
        void SendFileToS3(string Name, string FileAddress);

        // UpdateProfile()
        void UpdateProfile();
    }
}
