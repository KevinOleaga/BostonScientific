using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Panels
    {
        [HashKey]
        [Required]
        public string IdPanel { get; set; }
        [RangeKey]
        [Required]
        public string Area { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Bus { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Main { get; set; }
        [Required]
        public string From { get; set; }
        public string Comments { get; set; }
        [Required]
        public string Voltage { get; set; }
        [Required]
        public string Threads { get; set; }
        [Required]
        public string Phases { get; set; }
        [Required]
        public string Frequency { get; set; }
        [Required]
        public int SpacesAvailable { get; set; }
    }
}
