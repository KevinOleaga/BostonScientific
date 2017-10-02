using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Roles
    {
        [AutoIncrement]
        public int IdRole { get; set; }
        public string Name { get; set; }
    }
}
