using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.DAL.Methods
{
    public class MSwitch : ISwitch
    {
        conexion con = new conexion();
        private ITools _tools;

        public MSwitch()
        {
            _tools = new MTools();
        }

        
        // GetData()
        public DATA.Switch[] GetData(string IdSwitch)
        {
            DATA.Switch[] res = { };
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<DATA.Switch>().Where(x => x.IdSwitch == IdSwitch).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitch -> GetData(). \nDescripción: " + ex.Message);
            }
            return res;
        }
    }
}
