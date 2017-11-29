using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;

namespace BostonScientific.UI
{
    public partial class Index : System.Web.UI.Page
    {
        public IPanels _panels;
        public IUsers _users;
        public Index()
        {
            _panels = new MPanels();
            _users = new MUsers();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PanelsCount.Text = _panels.CountPanels().ToString();
            UsersCount.Text = _users.GetTotalMembers().ToString();
        }
    }
}