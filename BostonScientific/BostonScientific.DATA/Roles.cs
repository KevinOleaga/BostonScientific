using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Roles
    {
        [HashKey]
        public int IdRole { get; set; }
        public string Name { get; set; }
    }
}
