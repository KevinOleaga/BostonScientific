using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class SwitchInfo
    {
        [HashKey]
        [Required]
        public string IdSwitch { get; set; }
        
        [Required]
        public string IdPanel { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Current { get; set; }

        [Required]
        public string Caliber { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public string Switches  { get; set; }

        public string Comments { get; set; }
    }
}
