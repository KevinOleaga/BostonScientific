using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Users
    {
        [HashKey]
        public string UserName { get; set; }
        public string Password { get; set; }
        [References(typeof(Roles))]
        public int IdRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdCard { get; set; }
        public string Telephone { get; set; }
        public string Photo { get; set; }
        [References(typeof(AccountStatus))]
        public int IdStatus { get; set; }
        public int FailedAttempts { get; set; }
        public string SecretCode { get; set; }
    }
}