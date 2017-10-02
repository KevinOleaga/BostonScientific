using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Users
    {
        [HashKey]
        public string Email { get; set; }
        [RangeKey]
        public string Password { get; set; }
        [References(typeof(Roles))]
        public string IdRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string LastTime { get; set; }
    }
}