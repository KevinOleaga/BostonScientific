using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class AccountStatus
    {
        [HashKey]
        [AutoIncrement]
        public int IdStatus { get; set; }
        public string Status { get; set; }
    }
}
