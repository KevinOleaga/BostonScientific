using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Panels_Switches
    {
        [HashKey]
        [Required]
        public string IdPanel { get; set; }
        [Required]
        public string IdSwitch { get; set; }
        [Required]
        public string Breaker { get; set; }
        [Required]
        public string Corriente { get; set; }
        [Required]
        public string Calibre { get; set; }
        public string Planos { get; set; }
    }
}
