using BostonScientific.BLL.Interfaces;
using BostonScientific.DATA;
using System.Collections.Generic;

namespace BostonScientific.BLL.Methods
{
    public class MPanels : IPanels
    {
        private DAL.Interfaces.IPanels _panels;
        public MPanels()
        {
            _panels = new DAL.Methods.MPanels();
        }

        // GetPanelsInfo()
        public Panels[] GetPanelsInfo()
        {
            return _panels.GetPanelsInfo();
        }

        // CountPanels()
        public int CountPanels()
        {
            return _panels.CountPanels();
        }

        // DeletePanel()
        public void DeletePanel(string IdPanel)
        {
            _panels.DeletePanel(IdPanel);
        }

        // GetPanelInfo()
        public Panels[] GetPanelInfo(string IdPanel)
        {
            return _panels.GetPanelInfo(IdPanel);
        }

        // UpdatePanel()
        public void UpdatePanel(Panels PanelInfo)
        {
            _panels.UpdatePanel(PanelInfo);
        }

        // CreatePanel()
        public bool CreatePanel(Panels PanelInfo)
        {
            return _panels.CreatePanel(PanelInfo);
        }

        // IfPanelExist()
        public bool IfPanelExist(string IdPanel)
        {
            return _panels.IfPanelExist(IdPanel);
        }
    }
}
