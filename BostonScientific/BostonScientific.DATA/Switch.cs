using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class Switch
    {
        public int Voltage { get; set; }

        [HashKey]
        public string IdSwitch { get; set; }
    }
}
