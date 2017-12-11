using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.Web.UI;

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
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "mykey", "successalert();", true);

            Panels.Text = _panels.CountPanels().ToString();
            Users.Text = _users.GetTotalMembers().ToString();
        }
    }
}