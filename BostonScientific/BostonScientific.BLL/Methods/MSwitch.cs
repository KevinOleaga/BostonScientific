using BostonScientific.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.BLL.Methods
{
    public class MSwitch : ISwitch
    {
        private DAL.Interfaces.ISwitch _switch;
        public MSwitch()
        {
            _switch = new DAL.Methods.MSwitch();
        }

        // GetData()
        public DATA.Switch[] GetData(string IdSwitch)
        {
            return _switch.GetData(IdSwitch);
        }
    }
}
