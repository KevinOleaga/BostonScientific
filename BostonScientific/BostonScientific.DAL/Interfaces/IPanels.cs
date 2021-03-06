﻿using BostonScientific.DATA;
using System.Collections.Generic;
using System.IO;

namespace BostonScientific.DAL.Interfaces
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

        // UpdateComments()
        void UpdateComments(Panels PanelInfo);

        int GetInfo();

        void SendFileToS3(Stream FileStream, string FileName);
        /*

        #region Index.aspx

        // CountPanels()
        int CountPanels();

        #endregion Index.aspx

        
        void CreatePanel(List<string> PanelInfo);


        #region Switches.aspx

        Panels[] GetPanelInfo(string IdPanel);

        #endregion Switches.aspx


        // PanelsInfo()
        Panels[] PanelsInfo();

        Dictionary<string, string> OpcionesCategorias();
        */
    }
}
