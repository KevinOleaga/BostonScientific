using BostonScientific.DATA;

namespace BostonScientific.DAL.Interfaces
{
    public interface IUsers
    {
        // Login 01
        int Login01(string email);
        
        // Login 02
        int Login02(string email, string password);

        // UsersInfo()
        Users[] UsersInfo();

        // UserInfo()
        Users[] UserInfo(string email);
    }
}
