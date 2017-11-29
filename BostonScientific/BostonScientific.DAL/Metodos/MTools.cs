using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BostonScientific.DAL.Metodos
{
    public class MTools
    {
    /*    conexion con = new conexion();
        
        // Capitalize()
        public string Capitalize(string text)
        {
            string res = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return res;
        }
        

        #region Encryption

        // SecretKey (16 Characters)
        public string secretKey = "DrNbEsuT8y9YT2k2";

        // Encrypt()
        public string Encrypt(string data)
        {
            byte[] keyArray;
            byte[] encrypt = Encoding.UTF8.GetBytes(data);

            keyArray = Encoding.UTF8.GetBytes(secretKey);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] res = cTransform.TransformFinalBlock(encrypt, 0, encrypt.Length);
            tdes.Clear();

            return Convert.ToBase64String(res, 0, res.Length);
        }

        // Decrypt()
        public string Decrypt(string data)
        {
            byte[] keyArray;
            byte[] decrypt = Convert.FromBase64String(data);

            keyArray = Encoding.UTF8.GetBytes(secretKey);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] res = cTransform.TransformFinalBlock(decrypt, 0, decrypt.Length);
            tdes.Clear();

            return Encoding.UTF8.GetString(res);
        }

        #endregion

        #region Managment

        // CreateTable_Roles()
        public void CreateTable_Roles()
        {
            try
            {
                var db = new PocoDynamo(con.GetClient());
                db.RegisterTable<Roles>();
                db.InitSchema();

                var newRole = new Roles
                {
                    IdRole = 1,
                    Name = Encrypt("ADMINISTRADOR")
                };

                db.PutItem(newRole);

                newRole = new Roles
                {
                    IdRole = 2,
                    Name = Encrypt("TÉCNICO")
                };

                db.PutItem(newRole);


                Debug.WriteLine("\nCompletado: \nSe ha creado correctamente la tabla 'Roles'. \nSe han creado 2 tipos de roles Administrador y Técnico.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al crear la tabla 'Roles'. \nDescripción: " + ex.Message);
            }
        }

        // CreateTable_AccountStatus()
        public void CreateTable_AccountStatus()
        {
            try
            {
                var db = new PocoDynamo(con.GetClient());
                db.RegisterTable<AccountStatus>();
                db.InitSchema();

                var newStatus = new AccountStatus
                {
                    IdStatus = 1,
                    Status = Encrypt("ACTIVO")
                };

                db.PutItem(newStatus);

                newStatus = new AccountStatus
                {
                    IdStatus = 2,
                    Status = Encrypt("BLOQUEADO")
                };

                db.PutItem(newStatus);

                Debug.WriteLine("\nCompletado: \nSe ha creado correctamente la tabla 'AccountStatus'. \nSe han creado 2 tipos de estados ACTIVO y BLOQUEADO.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al crear la tabla 'AccountStatus'. \nDescripción: " + ex.Message);
            }
        }

        // CreateTable_Users()
        public void CreateTable_Users()
        {
            try
            {
                var db = new PocoDynamo(con.GetClient());
                db.RegisterTable<Users>();
                //db.InitSchema();

                var newUser = new Users
                {
                    UserName = Encrypt("MAR1234"),
                    Password = Encrypt("MARTINEZ"),
                    IdRole = 1,
                    FirstName = Encrypt("JUAN JOSE"),
                    LastName = Encrypt("MARTINEZ"),
                    Email = Encrypt("JUANJOSEMH73@HOTMAIL.COM"),
                    IdCard = Encrypt("112341234"),
                    Telephone = Encrypt("6052-1140"),
                    LastTime = Encrypt(DateTime.Now.ToShortDateString()),
                    Photo = Encrypt("https://s3-us-west-2.amazonaws.com/bostonscientific/Users/user.png"),
                    Phrase = Encrypt("La diferencia entre el fracaso y el éxito radica en la voluntad del corazón."),
                    IdStatus = 1,
                    FailedAttempts = 0,
                };

                db.PutItem(newUser);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al crear la tabla 'Users'. \nDescripción: " + ex.Message);
            }
        }

        // DropTable_Users()
        public void DropTable_Users()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.DeleteTable<Users>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MTools -> DropTable_Users(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }



        // CreateTable_Panels()
        public void CreateTable_Panels()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Panels>();
                db.InitSchema();

                for (int i = 0; i <= 15; i++)
                {
                    var NewPanel = new Panels
                    {
                        IdPanel = Encrypt("Panel" +i),
                        Area = Encrypt("Bodega"),
                        SpacesAvailable = Encrypt("42"),
                        Bus = Encrypt("120"),
                        Comments = Encrypt("Panel seminuevo"),
                        Description = Encrypt("Panel de paso"),
                        Frequency = Encrypt("50Hz"),
                        From = Encrypt("Bodega"),
                        Main = Encrypt("40"),
                        Model = Encrypt("XZ-11"),
                        Phases = Encrypt("3"),
                        Threads = Encrypt("4"),
                        Voltage = Encrypt("120V")
                    };

                    db.PutItem(NewPanel);
                }


                for (int i = 15; i <= 30; i++)
                {
                    var NewPanel = new Panels
                    {
                        IdPanel = Encrypt("Panel" +i),
                        Area = Encrypt("Cocina"),
                        SpacesAvailable = Encrypt("42"),
                        Bus = Encrypt("120"),
                        Comments = Encrypt("Panel Nuevo"),
                        Description = Encrypt("Panel Nuevo"),
                        Frequency = Encrypt("60Hz"),
                        From = Encrypt("Aula"),
                        Main = Encrypt("32"),
                        Model = Encrypt("AD-11"),
                        Phases = Encrypt("2"),
                        Threads = Encrypt("2"),
                        Voltage = Encrypt("120V")
                    };
                    db.PutItem(NewPanel);

                }

                for (int i = 30; i < 45; i++)
                {
                    var NewPanel = new Panels
                    {
                        IdPanel = Encrypt("Panel" +i),
                        Area = Encrypt("Laboratorios"),
                        SpacesAvailable = Encrypt("42"),
                        Bus = Encrypt("120"),
                        Comments = Encrypt("Panel Nuevo"),
                        Description = Encrypt("Panel Nuevo"),
                        Frequency = Encrypt("60Hz"),
                        From = Encrypt("Laboratorios"),
                        Main = Encrypt("32"),
                        Model = Encrypt("dad-121"),
                        Phases = Encrypt("1"),
                        Threads = Encrypt("1"),
                        Voltage = Encrypt("240V")
                    };
                    db.PutItem(NewPanel);

                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MTools -> CreateTable_Panels(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // DropTable_Panels()
        public void DropTable_Panels()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.DeleteTable<Panels>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MTools -> DropTable_Panels(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion Managment


        // CreateTable_PruebaJuan()
        public void CreateTable_PruebaJuan()
        {
            try
            {
                var db = new PocoDynamo(con.GetClient());
                db.RegisterTable<PruebaJuan>();
                db.InitSchema();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al crear la tabla. \nDescripción: " + ex.Message);
            }
        }
        */
    }
}