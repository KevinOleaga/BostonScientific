using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace BostonScientific.DAL.Metodos
{
    public class MTools : ITools
    {
        conexion con = new conexion();
        
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

        #region DynamoDB

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
                db.InitSchema();

                var newUser = new Users
                {
                    UserName = Encrypt("EPICBS"),
                    Password = Encrypt("EPIC1234"),
                    IdRole = 1,
                    FirstName = Encrypt("EPIC"),
                    LastName = Encrypt("USER"),
                    Email = Encrypt("EPICBS@OUTLOOK.COM"),
                    IdCard = Encrypt("123456789"),
                    Telephone = Encrypt("8888-8888"),
                    LastTime = Encrypt(DateTime.Now.Date.ToString()),
                    Photo = Encrypt("https://s3-us-west-2.amazonaws.com/bostonscientific/Users/default.png"),
                    Phrase = Encrypt("La diferencia entre el fracaso y el éxito radica en la voluntad del corazón."),
                    IdStatus = 1,
                    FailedAttempts = 0,
                };

                db.PutItem(newUser);

                Debug.WriteLine("\nCompletado: \nSe a creado correctamente la tabla 'Users'. \nSe ha asignado un usuario por default. \nUsuario: EPICBS \nContraseña: EPIC1234");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al crear la tabla 'Users'. \nDescripción: " + ex.Message);
            }
        }
        
        #endregion
    }
}