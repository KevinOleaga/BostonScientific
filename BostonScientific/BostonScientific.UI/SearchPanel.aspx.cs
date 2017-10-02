using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using System;
using System.Diagnostics;

namespace BostonScientific.UI
{
    public partial class SearchPanel : System.Web.UI.Page
    {
        public IPanels panels;
        public SearchPanel()
        {
            panels = new MPanels();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SearchTop_Click(object sender, EventArgs e)
        {
            //string cod_ = cod.Value;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("\nDato Capturado: " + search.Value + "\n");
            search.Value = "";
        }

        protected void PanelsInfo()
        {
            var res = panels.PanelsInfo();

            for (int i = 0; i < panels.CountPanels(); i++)
            {
                Response.Write("<tr>" +
                                 "<td></td>" +
                                 "<td>" + res[i].IdPanel + "</td>" +
                                 "<td>" + res[i].Area + "</td>" +
                                 "<td>" + res[i].Description + "</td>" +
                                 "<td>" + res[i].SpacesAvailable + "</td>" +
                                 "<td></td>" +
                               "</tr>");
            }
        }
    }
}