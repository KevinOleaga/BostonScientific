using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using System;
using System.Diagnostics;

namespace BostonScientific.UI
{
    public partial class Index : System.Web.UI.Page
    {
        public IPanels panels;
        public Index()
        {
            panels = new MPanels();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PanelCount.Text = panels.CountPanels().ToString();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("\nDato Capturado: " + search.Value + "\n");
            search.Value = "";
        }
    }
}