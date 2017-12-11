using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using BostonScientific.DATA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Services;

namespace BostonScientific.UI
{
    public partial class PanelView : System.Web.UI.Page
    {
        private static ITools _tools;
        private static ISwitchInfo _switchInfo;
        private static IPanels _panels;
        public static string IdPanel;

        public PanelView()
        {
            _tools = new MTools();
            _panels = new MPanels();
            _switchInfo = new MSwitchInfo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IdPanel = Request.QueryString["C"];

            var res = _panels.GetPanelInfo(IdPanel);

            lb_IdPanel.Text = string.Format("Código del panel: {0}", _tools.Capitalize(_tools.Decrypt(res[0].IdPanel)));
            lb_Description.Text = string.Format("Descripción: {0}", _tools.Capitalize(_tools.Decrypt(res[0].Description)));
            lb_SpacesAvailable.Text = string.Format("Espacios Disponibles: {0}", _tools.Decrypt(res[0].SpacesAvailable));
            atxtComments.InnerText = _tools.Capitalize(_tools.Decrypt(res[0].Comments));
        }

        public void ListSwitches_01()
        {
            List<string> items = new List<string>();
            Random rnd = new Random();
            var res = _switchInfo.GetPanelSwitches(IdPanel);

            var n = 0;
            var color = 0;
            var IdSwitch = string.Empty;

            for (int i = 0; i < 42; i++)
            {                
                items.Add("<tr><td class='text-center padding'>" + i + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>Disponible</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center Remove'></td></tr>");
            }

            foreach (var item in res)
            {
                if (_tools.Decrypt(item.Type) == "Trifasico")
                {
                    color = rnd.Next(1, 20);
                    IdSwitch = item.IdSwitch;

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(0, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(3, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(6, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";
                }
                else if (_tools.Decrypt(item.Type) == "Bifasico")
                {
                    color = rnd.Next(1, 20);
                    IdSwitch = item.IdSwitch;

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(0, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(3, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";
                }

                else if (_tools.Decrypt(item.Type) == "Monofasico")
                {
                    color = rnd.Next(1, 20);
                    IdSwitch = item.IdSwitch;

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";
                }
            }

            for (int a = 0; a < 42; a++)
            {
                Response.Write(items[a+1]);
                a = a + 1;
            }
        }

        public void ListSwitches_02()
        {
            List<string> items = new List<string>();
            Random rnd = new Random();
            var res = _switchInfo.GetPanelSwitches(IdPanel);

            var n = 0;
            var color = 0;
            var IdSwitch = string.Empty;

            for (int i = 0; i < 43; i++)
            {
                items.Add("<tr><td class='text-center padding'>" + i + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>Disponible</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center Remove'></td></tr>");
            }

            foreach (var item in res)
            {
                if (_tools.Decrypt(item.Type) == "Trifasico")
                {
                    color = rnd.Next(1, 20);
                    IdSwitch = item.IdSwitch;

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(0, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(3, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(6, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";
                }
                else if (_tools.Decrypt(item.Type) == "Bifasico")
                {
                    color = rnd.Next(1, 20);
                    IdSwitch = item.IdSwitch;

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(0, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches).Substring(3, 2));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";
                }

                else if (_tools.Decrypt(item.Type) == "Monofasico")
                {
                    color = rnd.Next(1, 20);
                    IdSwitch = item.IdSwitch;

                    n = Convert.ToInt32(_tools.Decrypt(item.Switches));
                    items[n] = "<tr class='SetColor" + color + "'><td class='text-center'>" + n + "</td><td class='text-center Remove'>" + IdSwitch + "</td><td class='text-center'>En Uso</td><td class='text-center'>0</td><td class='text-center'>0</td><td class='text-center'></td></tr>";
                }
            }

            for (int a = 1; a < 43; a++)
            {
                Response.Write(items[a + 1]);
                a = a + 1;
            }
        }

        [WebMethod]
        public static void CreateSwitch(string Type, string Switches, string Current, string Caliber, string Comments)
        {
            var IdSwitch = _tools.Decrypt(IdPanel) + "_" + Switches;
            var NewSwitch = new SwitchInfo
            {
                IdSwitch = _tools.Encrypt(IdSwitch),
                IdPanel = IdPanel,
                Type = _tools.Encrypt(_tools.Capitalize(Type)),
                Switches = _tools.Encrypt(Switches),
                Current = _tools.Encrypt(Current),
                Caliber = _tools.Encrypt(Caliber),
                Comments = _tools.Encrypt(_tools.Capitalize(Comments)),
                IsAvailable = true
            };

            _switchInfo.CreateSwitch(NewSwitch);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

        }
    }
}