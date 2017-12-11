using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.Diagnostics;
using System.Web.Services;

namespace BostonScientific.UI
{
    public partial class Switch : System.Web.UI.Page
    {
        private static ISwitch _switch;
        private static ITools _tools;
        private static IPanels _panels;
        public static string IdSwitch = "1";

        public Switch()
        {
            _switch = new MSwitch();
            _tools = new MTools();
            _panels = new MPanels();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var res = _panels.GetInfo();

            //IdSwitch = _tools.Encrypt(IdSwitch);
        }

        [WebMethod]
        public static int GetData()
        {
            var res = _panels.GetInfo();
            //Debug.WriteLine("EL result es : " + res[0].Voltage);
            Debug.WriteLine("hola" + res);
            //var res = _switch.GetData(IdSwitch);
            //Debug.WriteLine("EL result es : " + res[0].Voltage);
            return Convert.ToInt32(res);//Convert.ToInt32(res[0].payload);//res[0].Voltage;
        }        
    }
}