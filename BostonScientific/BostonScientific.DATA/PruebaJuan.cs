using ServiceStack.DataAnnotations;

namespace BostonScientific.DATA
{
    public class PruebaJuan
    {
        [HashKey]
        public int Medicion { get; set; }
        public string Tiempo { get; set; }
    }
}
