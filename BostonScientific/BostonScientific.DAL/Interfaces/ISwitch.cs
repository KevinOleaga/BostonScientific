using BostonScientific.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.DAL.Interfaces
{
    public interface ISwitch
    {
        // GetData()
        Switch[] GetData(string IdSwitch);
    }
}
