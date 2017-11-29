using BostonScientific.DATA;
using System.Collections.Generic;

namespace BostonScientific.BLL.Interfaces
{
    public interface IPanels
    {
        // GetPanelsInfo()
        Panels[] GetPanelsInfo();

        // CountPanels()
        int CountPanels();

        // DeletePanel()
        void DeletePanel(string IdPanel);

        // GetPanelInfo()
        Panels[] GetPanelInfo(string IdPanel);

        // UpdatePanel()
        void UpdatePanel(Panels PanelInfo);
        
        // CreatePanel()
        bool CreatePanel(Panels PanelInfo);
        
        // IfPanelExist()
        bool IfPanelExist(string IdPanel);
    }
}
