using BostonScientific.BLL.Interfaces;
using BostonScientific.BLL.Methods;
using System;

namespace BostonScientific.UI
{
    public partial class PanelView : System.Web.UI.Page
    {
        private ITools _tools;
        private IPanels _panels;

        public PanelView()
        {
            _tools = new MTools();
            _panels = new MPanels();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var IdPanel = Request.QueryString["C"];
            
            var res = _panels.GetPanelInfo(IdPanel);

            lb_IdPanel.Text = string.Format("Código del panel: {0}", _tools.Capitalize(_tools.Decrypt(res[0].IdPanel)));
            lb_Description.Text = string.Format("Descripción: {0}", _tools.Capitalize(_tools.Decrypt(res[0].Description)));
        }

        public void prueba()
        {
            var num = 1;
            for (int i = 0; i < 21; i++)
            {
                Response.Write("<tr>" +
                            "<td class='text-center'>" + num +"</td>"+
                            "<td class='text-center'>Disponible</td>" +
                            "<td class='text-center'>0</td>" +
                            "<td class='text-center'>0</td>" +
                            "<td class='text-center'>"+
                                "<asp:Button class='btn btn-primary' ID='btnCrear' runat='server' Text='Ver' />"+
                            "</td>"+
                        "</tr>");
                num = num + 2;

            }
        }

        public void prueba1()
        {

            var num = 2;
            for (int i = 0; i < 21; i++)
            {
                Response.Write("<tr>" +
                            "<td class='text-center'>" + num + "</td>" +
                            "<td class='text-center'>Disponible</td>" +
                            "<td class='text-center'>0</td>" +
                            "<td class='text-center'>0</td>" +
                            "<td class='text-center'>" +
                                "<asp:Button class='btn btn-primary' ID='btnCrear' runat='server' Text='Ver' />" +
                            "</td>" +
                        "</tr>");
                num = num + 2;

            }
        }
    }
}