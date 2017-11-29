using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BostonScientific.DAL.Methods
{
    public class MPanels : IPanels
    {
        conexion con = new conexion();
        private ITools _tools;
        public MPanels()
        {
            _tools = new MTools();
        }

        // GetPanelsInfo()
        public Panels[] GetPanelsInfo()
        {
            var db = new PocoDynamo(con.GetClient());
            Panels[] res = { };

            try
            {
                res = db.ScanAll<Panels>().ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> GetPanelsInfo(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return res;
        }

        // CountPanels()
        public int CountPanels()
        {
            var db = new PocoDynamo(con.GetClient());
            var res = 0;

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

        // DeletePanel()
        public void DeletePanel(string IdPanel)
        {
            var db = new PocoDynamo(con.GetClient());
            db.RegisterTable<Panels>();

            try
            {
                db.DeleteItem<Panels>(IdPanel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> DeletePanel(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // GetPanelInfo()
        public Panels[] GetPanelInfo(string IdPanel)
        {
            var db = new PocoDynamo(con.GetClient());
            Panels[] res = { };

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

        // UpdatePanel()
        public void UpdatePanel(Panels PanelInfo)
        {
            var db = new PocoDynamo(con.GetClient());
            db.RegisterTable<Panels>();

            try
            {
                db.UpdateItem(PanelInfo.IdPanel,
                put: () => new Panels
                {
                    Model = PanelInfo.Model,
                    Description = PanelInfo.Description,
                    Bus = PanelInfo.Bus,
                    Main = PanelInfo.Main,
                    Area = PanelInfo.Area,
                    From = PanelInfo.From,
                    Comments = PanelInfo.Comments,
                    Voltage = PanelInfo.Voltage,
                    Phases = PanelInfo.Phases,
                    Threads = PanelInfo.Threads,
                    Frequency = PanelInfo.Frequency
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> UpdatePanel(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // CreatePanel()
        public bool CreatePanel(Panels PanelInfo)
        {
            var db = new PocoDynamo(con.GetClient());
            db.RegisterTable<Panels>();
            var res = false;

            try
            {
                db.PutItem(PanelInfo);
                res = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> CreatePanel(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return res;
        }

        // IfPanelExist()
        public bool IfPanelExist(string IdPanel)
        {
            var db = new PocoDynamo(con.GetClient());
            var res = false;

            try
            {
                if (db.ScanAll<Panels>().Where(x => x.IdPanel == IdPanel).Count() == 1)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> IfPanelExist(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return res;
        }

    }
}
