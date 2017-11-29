using BostonScientific.DATA;
using BostonScientific.DAL.Interfaces;
using System;
using ServiceStack.Aws.DynamoDb;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace BostonScientific.DAL.Metodos
{
    public class MPanels
    {
        /*conexion con = new conexion();
        private ITools _tools;

        public MPanels()
        {
            _tools = new MTools();
        }
        












        



        #region Index.aspx

        // CountPanels()
        public int CountPanels()
        {
            var res = 0;
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<Panels>().Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> CountPanels(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return res;
        }

        #endregion Index.aspx

        #region CreatePanel.aspx

        // CreatePanel()
        public void CreatePanel(List<string> PanelInfo)
        {
            var db = new PocoDynamo(con.GetClient());
            db.RegisterTable<Panels>();

            try
            {
                var newPanel = new Panels
                {
                    IdPanel = PanelInfo[0],
                    Model = PanelInfo[1],
                    Bus = PanelInfo[2],
                    Main = PanelInfo[3],
                    
                    Area = PanelInfo[4],
                    From = PanelInfo[5],
                    Comments = PanelInfo[6],

                    Voltage = PanelInfo[7],
                    Phases = PanelInfo[8],
                    Threads = PanelInfo[9],
                    Frequency = PanelInfo[10],

                    SpacesAvailable = _tools.Encrypt("42"),
                    Description = _tools.Encrypt("Panel Nuevo")
                };

                db.PutItem(newPanel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> CreatePanel(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion CreatePanel.aspx

        #region Switches.aspx

        // GetPanelInfo()
        public Panels[] GetPanelInfo(string IdPanel)
        {
            Panels[] res = { };
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<Panels>().Where(x => x.IdPanel == IdPanel).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> GetPanelInfo(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return res;
        }

        #endregion Switches.aspx


        // PanelsInfo()
        public Panels[] PanelsInfo()
        {
            Panels[] res = { };

            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Panels>().ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al obtener la información de los paneles. \nDescripción: " + ex.Message);
            }
            return res;
        }

        public Dictionary<string, string> OpcionesCategorias()
        {
            var db = new PocoDynamo(con.GetClient());
            var res = db.ScanAll<Panels>();

            Dictionary<string, string> opcionesCategorias = new Dictionary<string, string>();
            foreach (var panel in res)
            {
                opcionesCategorias.Add(panel.IdPanel, panel.Description);
            }

            Debug.WriteLine(opcionesCategorias.Select(x => x.Value));
            return opcionesCategorias;
        }
        */
    }
}
