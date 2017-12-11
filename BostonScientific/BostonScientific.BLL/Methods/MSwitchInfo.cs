using BostonScientific.BLL.Interfaces;
using BostonScientific.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.BLL.Methods
{
    public class MSwitchInfo : ISwitchInfo
    {
        private DAL.Interfaces.ISwitchInfo _switchInfo;
        public MSwitchInfo()
        {
            _switchInfo = new DAL.Methods.MSwitchInfo();
        }

        // GetPanelSwitches()
        public SwitchInfo[] GetPanelSwitches(string IdPanel)
        {
            return _switchInfo.GetPanelSwitches(IdPanel);
        }


        // CreateSwitch()
        public void CreateSwitch(SwitchInfo NewSwitch)
        {
            _switchInfo.CreateSwitch(NewSwitch);
        }

        #region Managment

        // CreateTable()
        public void CreateTable()
        {
            _switchInfo.CreateTable();
        }

        // DropTable()
        public void DropTable()
        {
            _switchInfo.DropTable();
        }

        // DeleteTable()
        public void DeleteTable()
        {
            _switchInfo.DeleteTable();
        }

        #endregion Managment
    }
}
