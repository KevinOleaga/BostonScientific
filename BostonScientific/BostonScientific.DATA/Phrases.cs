using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Phrases
    {
        [HashKey]
        public int Id { get; set; }

        public string Phrase { get; set; }
    }
}
