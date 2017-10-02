using BostonScientific.DATA;
using BostonScientific.DAL.Interfaces;
using System;
using ServiceStack.Aws.DynamoDb;
using System.Linq;
using System.Diagnostics;

namespace BostonScientific.DAL.Metodos
{
    public class MUsers : IUsers
    {
        conexion con = new conexion();

        // Login01()
        public int Login01(string email)
        {
            var res = 0;
            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Users>().Where(x => x.Email == email).Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al verificar el usuario. \nDescripción: " + ex.Message);
            }
            return res;
        }

        // Login02()
        public int Login02(string email, string password)
        {
            var res = 0;
            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Users>().Where(x => x.Email == email && x.Password == password).Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al verificar la contraseña. \nDescripción: " + ex.Message);
            }
            return res;
        }

        // UsersInfo()
        public Users[] UsersInfo()
        {
            Users[] res = { };

            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Users>().ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al obtener la información de los usuarios. \nDescripción: " + ex.Message);
            }
            return res;
        }

        // UserInfo()
        public Users[] UserInfo(string email)
        {
            Users[] res = { };

            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Users>().Where(x => x.Email == email && x.IdRole == x.IdRole).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al obtener la información del usuario. \nDescripción: " + ex.Message);
            }
            return res;
        }
    }
}
