using BostonScientific.DATA;
using System.Collections.Generic;
using System.IO;

namespace BostonScientific.BLL.Interfaces
{
    public interface IPanels
    {
        void SendFileToS3(Stream FileStream, string FileName);

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

        // UpdateComments()
        void UpdateComments(Panels PanelInfo);

        int GetInfo();
    }
}
