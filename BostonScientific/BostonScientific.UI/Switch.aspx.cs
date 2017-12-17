using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;
using System.Diagnostics;
using System.IO;
using System.Web.Services;

namespace BostonScientific.UI
{
    public partial class Switch : System.Web.UI.Page
    {
        static ISwitch _switch;
        static ISwitchInfo _switchInfo;
        static ITools _tools;

        public Switch()
        {
            _switch = new MSwitch();
            _switchInfo = new MSwitchInfo();
            _tools = new MTools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var Id = Request.QueryString["S"];
            var res = _switchInfo.GetInfo(Id);
            var Type = _tools.Capitalize(_tools.Decrypt(res[0].Type));

            txtType.Text = Type;
            txtCurrent.Text = _tools.Decrypt(res[0].Current);
            txtCaliber.Text = _tools.Decrypt(res[0].Caliber);
            txtCaliber.Text = _tools.Decrypt(res[0].Caliber);

            var Switches = _tools.Decrypt(res[0].Switches);
            if(Type == "Monofasico")
            {
                txtS1.Visible = false;
                txtS2.Text = _tools.Decrypt(res[0].Switches);
                txtS3.Visible = false;
            }
            else if (Type == "Bifasico")
            {
                txtS1.Text = _tools.Decrypt(res[0].Switches).Substring(0,2);
                txtS2.Text = _tools.Decrypt(res[0].Switches).Substring(3,2);
                txtS3.Visible = false;
            }
            else if (Type == "Trifasico")
            {
                txtS1.Text = _tools.Decrypt(res[0].Switches).Substring(0, 2);
                txtS2.Text = _tools.Decrypt(res[0].Switches).Substring(3, 2);
                txtS3.Text = _tools.Decrypt(res[0].Switches).Substring(6, 2);
            }

            txtComments.Value = _tools.Capitalize(_tools.Decrypt(res[0].Comments));
        }

        [WebMethod]
        public static int GetData2(string IdSwitch)
        {
            var res = _switch.GetData2(IdSwitch);
            return res;
        }

        [WebMethod]
        public static void DeleteSwitch(string IdSwitch)
        {
            _switchInfo.DeleteSwitchInfo(IdSwitch);
            _switch.DeleteSwitch(IdSwitch);
        }

        protected void btn_AddFile_Click(object sender, EventArgs e)
        {
            Stream FileStream = fuFiles.PostedFile.InputStream;
            string FileName = Path.GetFileName(fuFiles.FileName);

            if (FileName != string.Empty)
            {
                _switch.SendFileToS3(FileStream, FileName, Request.QueryString["S"]);
            }

            Response.Redirect("Panels.aspx");
        }

        protected void GetFiles()
        {
            var res = _switch.GetFiles(Request.QueryString["S"]);
            for (int i = 0; i < _switch.CountFiles(Request.QueryString["S"]); i++)
            {
                var table = string.Format("<tr> <td>{0}</td> <td>{1}</td> </tr>", res[i].Id, _tools.Decrypt(res[i].FileName));
                Response.Write(table);
            }
        }

        [WebMethod]
        public static void DownloadDocs(string FileName)
        {
            _switch.DownloadDoc(FileName);
        }
    }
}