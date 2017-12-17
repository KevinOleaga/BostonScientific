using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Files
    {
        [HashKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string IdSwitch { get; set; }

        public string FileName { get; set; }

        public string Location { get; set; }
    }
}
