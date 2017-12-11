using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.Web.Services;
using System.Web.UI;

namespace BostonScientific.UI
{
    public partial class Panels : Page
    {
        private static IPanels _panels;
        private static ITools _tools;

        public Panels()
        {
            _panels = new MPanels();
            _tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e) { }
        
        protected void ShowPanelsInfo()
        {
            var res = _panels.GetPanelsInfo();
            for (int i = 0; i < _panels.CountPanels(); i++)
            {
                var table = string.Format("<tr> <td>{0}</td> <td>{1}</td> <td>{2}</td> <td>{3} / 42</td> <td></td> </tr>", _tools.Decrypt(res[i].IdPanel).ToUpper(), _tools.Capitalize(_tools.Decrypt(res[i].Area)), _tools.Capitalize(_tools.Decrypt(res[i].Description)), _tools.Decrypt(res[i].SpacesAvailable));
                Response.Write(table);
            }
        }

        [WebMethod]
        public static bool CreatePanel(string IdPanel, string Model, string Description, string Bus, string Main, string Area, string From, string Voltage, string Phases, string Threads, string Frequency, string Comments)
        {
            var res = false;
            IdPanel = _tools.Encrypt(IdPanel.ToUpper());

            switch (_panels.IfPanelExist(IdPanel))
            {
                case true:
                    res = true;
                    break;
                case false:
                    var PanelInfo = new DATA.Panels
                    {                        
                        IdPanel = IdPanel,
                        Model = _tools.Encrypt(Model.ToUpper()),
                        Description = _tools.Encrypt(Description.ToUpper()),
                        Bus = _tools.Encrypt(Bus + "A"),
                        Main = _tools.Encrypt(Main + "A"),
                        Area = _tools.Encrypt(Area.ToUpper()),
                        From = _tools.Encrypt(From.ToUpper()),
                        Voltage = _tools.Encrypt(Voltage + "V"),
                        Phases = _tools.Encrypt(Phases + "Ph"),
                        Threads = _tools.Encrypt(Threads),
                        Frequency = _tools.Encrypt(Frequency + "Hz"),
                        Comments = _tools.Encrypt(Comments.ToUpper()),
                        SpacesAvailable = _tools.Encrypt("42"),
                    };

                    _panels.CreatePanel(PanelInfo);
                    res = false;
                    break;
            }
            return res;
        }

        [WebMethod]
        public static string PanelView(string IdPanel)
        {
            IdPanel = _tools.Encrypt(IdPanel);
            return "PanelView.aspx?C=" + IdPanel;
        }

        [WebMethod]
        public static void DeletePanel(string IdPanel)
        {
            IdPanel = _tools.Encrypt(IdPanel);
            _panels.DeletePanel(IdPanel);
        }

        [WebMethod]
        public static DATA.Panels[] GetPanelInfo(string IdPanel)
        {
            IdPanel = _tools.Encrypt(IdPanel);
            var res = _panels.GetPanelInfo(IdPanel);

            res[0].IdPanel = _tools.Decrypt(res[0].IdPanel);
            res[0].Model = _tools.Decrypt(res[0].Model);
            res[0].Description = _tools.Capitalize(_tools.Decrypt(res[0].Description));
            res[0].Bus = _tools.Decrypt(res[0].Bus);
            res[0].Main = _tools.Decrypt(res[0].Main);
            res[0].Area = _tools.Capitalize(_tools.Decrypt(res[0].Area));
            res[0].From = _tools.Capitalize(_tools.Decrypt(res[0].From));
            res[0].Voltage = _tools.Decrypt(res[0].Voltage);
            res[0].Phases = _tools.Decrypt(res[0].Phases);
            res[0].Threads = _tools.Decrypt(res[0].Threads);
            res[0].Frequency = _tools.Decrypt(res[0].Frequency);
            res[0].Comments = _tools.Capitalize(_tools.Decrypt(res[0].Comments));
            res[0].SpacesAvailable = _tools.Decrypt(res[0].SpacesAvailable);
            return res;
        }

        [WebMethod]
        public static void UpdatePanel(string IdPanel, string Model, string Description, string Bus, string Main, string Area, string From, string Comments, string Voltage, string Phases, string Threads, string Frequency)
        {
            var PanelInfo = new DATA.Panels
            {
                IdPanel = _tools.Encrypt(IdPanel),
                Model = _tools.Encrypt(Model),
                Description = _tools.Encrypt(Description),
                Bus = _tools.Encrypt(Bus),
                Main = _tools.Encrypt(Main),
                Area = _tools.Encrypt(Area),
                From = _tools.Encrypt(From),
                Comments = _tools.Encrypt(Comments),
                Voltage = _tools.Encrypt(Voltage),
                Phases = _tools.Encrypt(Phases),
                Threads = _tools.Encrypt(Threads),
                Frequency = _tools.Encrypt(Frequency)
            };

            _panels.UpdatePanel(PanelInfo);
        }
    }
}