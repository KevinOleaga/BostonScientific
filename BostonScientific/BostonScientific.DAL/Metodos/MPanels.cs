using BostonScientific.DATA;
using BostonScientific.DAL.Interfaces;
using System;
using ServiceStack.Aws.DynamoDb;
using System.Linq;
using System.Diagnostics;

namespace BostonScientific.DAL.Metodos
{
    public class MPanels : IPanels
    {
        conexion con = new conexion();

        // CountPanels()
        public int CountPanels()
        {
            var res = 0;
            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Panels>().Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: Se a producido un error al verificar la cantidad de paneles existentes \nDescripcion: " + ex.Message + "\n");
            }
            return res;
        }

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
    }
}
