using BostonScientific.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.BLL.Interfaces
{
    public interface ISwitch
    {
        // GetData()
        Switch[] GetData(string IdSwitch);
    }
}
