using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using System;

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
    }
}