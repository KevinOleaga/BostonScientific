using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Diagnostics;
using System.Linq;

namespace BostonScientific.DAL.Methods
{
    public class MSwitchInfo : ISwitchInfo
    {
        conexion con = new conexion();
        private ITools _tools;

        public MSwitchInfo()
        {
            _tools = new MTools();
        }

        // GetPanelSwitches()
        public SwitchInfo[] GetPanelSwitches(string IdPanel)
        {
            SwitchInfo[] res = { };
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<SwitchInfo>().Where(x => x.IdPanel == IdPanel).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitchInfo -> GetPanelSwitches(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        // CreateSwitch()
        public void CreateSwitch(SwitchInfo NewSwitch)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<SwitchInfo>();
                db.PutItem(NewSwitch);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitchInfo -> CreateSwitch(). \nDescripción: " + ex.Message);
            }
        }

        #region Managment

        // CreateTable()
        public void CreateTable()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<SwitchInfo>();
                db.InitSchema();
            }

            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitchInfo -> CreateTable(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // DropTable()
        public void DropTable()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.DeleteTable<SwitchInfo>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitchInfo -> DropTable(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // DeleteTable()
        public void DeleteTable()
        {
            try
            {
                DropTable();
                CreateTable();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitchInfo -> DeleteTable(). \nDescripción: " + ex.Message);
            }
        }

        #endregion Managment
    }
}
