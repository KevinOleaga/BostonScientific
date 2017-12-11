using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.DATA
{
    public class testData
    {
        public string Id { get; set; }
        public string timestamp { get; set; }
        public Payload payload { get; set; }
        public string payload_raw { get; set; }
    }
    
    public class Payload
    {
        public int Medicion { get; set; }
    }
}
