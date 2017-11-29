using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace BostonScientific.DAL.Methods
{
    public class MTools : ITools
    {
        conexion con = new conexion();

        // Capitalize()
        public string Capitalize(string text)
        {
            string res = string.Empty;

            try
            {
                res = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MTools -> Capitalize(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        #region Encryption

        // SecretKey (16 Characters)
        private static string secretKey = "DrNbEsuT8y9YT2k2";

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

        #region  Managment

        // CreateTable_Panels()
        public void CreateTable_Panels()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Panels>();
                db.InitSchema();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> CreateTable_Panels(). \nDescripción: " + ex.Message);
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

        // DeleteTable_Panels()
        public void DeleteTable_Panels()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                DropTable_Panels();
                CreateTable_Panels();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> DeleteTable_Panels(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion  Managment
    }
}
