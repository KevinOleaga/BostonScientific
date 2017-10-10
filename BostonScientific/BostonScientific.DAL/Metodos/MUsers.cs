using BostonScientific.DATA;
using BostonScientific.DAL.Interfaces;
using System;
using ServiceStack.Aws.DynamoDb;
using System.Linq;
using System.Diagnostics;
using Amazon.S3.Transfer;
using System.Collections.Generic;

namespace BostonScientific.DAL.Metodos
{
    public class MUsers : IUsers
    {
        conexion con = new conexion();

        // Login01()
        public bool Login01(string email)
        {
            var res = false;
            try
            {
                var db = new PocoDynamo(con.GetClient());
                if (db.ScanAll<Users>().Where(x => x.Email == email).Count() == 1)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al verificar el usuario. \nDescripción: " + ex.Message);
            }
            return res;
        }

        // Login02()
        public bool Login02(string email, string password)
        {
            var res = false;
            try
            {
                var db = new PocoDynamo(con.GetClient());
                if (db.ScanAll<Users>().Where(x => x.Email == email && x.Password == password).Count() == 1)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al verificar la contraseña. \nDescripción: " + ex.Message);
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
                res = db.ScanAll<Users>().Where(x => x.Email == email).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al obtener la información del usuario. \nDescripción: " + ex.Message);
            }
            return res;
        }

        // UserRole()
        public Roles[] UserRole(int idRole)
        {
            Roles[] res = { };

            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Roles>().Where(x => x.IdRole == idRole).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al obtener la información del role. \nDescripción: " + ex.Message);
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

        // TotalUsers()
        public int TotalUsers()
        {
            int res = 0;
            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Users>().Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al obtener la cantidad de usuarios. \nDescripción: " + ex.Message);
            }
            return res;
        }

        // SendFileToS3()
        public void SendFileToS3(string Name, string FileAddress)
        {
            var BucketName = "bostonscientific";
            var SubDirectory = "Users";
            var FileName = Name + "jpg";

            try
            {
                var client = con.S3_GetClient();

                TransferUtility utility = new TransferUtility(client);
                TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                request.BucketName = BucketName + @"/" + SubDirectory;

                request.Key = FileName;
                request.FilePath = FileAddress;
                utility.Upload(request);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al subir la imagen. \nDescripción: " + ex.Message);
            }
        }

        // UpdateProfile()
        public void UpdateProfile()
        {
            try
            {
                var user = new Users
                {
                    Email = "OLEAGA@OUTLOOK.COM"
                };

                var db = new PocoDynamo(con.GetClient());
                db.RegisterTable<Users>();
                db.InitSchema();
                Debug.WriteLine(user.Email);
                //db.UpdateItemNonDefaults(new Users { Email = user.Email, FirstName = "42" });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al actualizar el perfil. \nDescripción: " + ex.Message);
            }
        }
    }
}
