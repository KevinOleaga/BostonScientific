using BostonScientific.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.BLL.Interfaces
{
    public interface ISwitchInfo
    {
        // GetPanelSwitches()
        SwitchInfo[] GetPanelSwitches(string IdPanel);

        // CreateSwitch()
        void CreateSwitch(SwitchInfo NewSwitch);

        #region Managment

        // CreateTable()
        void CreateTable();
        
        // DropTable()
        void DropTable();
        
        // DeleteTable()
        void DeleteTable();

        #endregion Managment
    }
}
