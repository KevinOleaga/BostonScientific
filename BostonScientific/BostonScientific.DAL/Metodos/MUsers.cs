using BostonScientific.DATA;
using BostonScientific.DAL.Interfaces;
using System;
using ServiceStack.Aws.DynamoDb;
using System.Linq;
using System.Diagnostics;
using Amazon.S3.Transfer;
using System.Net.Mail;
using System.Text;
using System.Net;
using Amazon.DynamoDBv2.DataModel;
using ServiceStack;

namespace BostonScientific.DAL.Metodos
{
    public class MUsers : IUsers
    {
        conexion con = new conexion();
        private ITools tools;

        public MUsers()
        {
            tools = new MTools();
        }

        #region Login.aspx

        // Login01()
        public bool Login01(string UserName)
        {
            var res = false;
            var db = new PocoDynamo(con.GetClient());

            try
            {
                if (db.ScanAll<Users>().Where(x => x.UserName == UserName).Count() == 1)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> Login01(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return res;
        }

        // Login02()
        public bool Login02(string UserName, string Password)
        {
            var res = false;
            var db = new PocoDynamo(con.GetClient());

            try
            {
                if (db.ScanAll<Users>().Where(x => x.UserName == UserName && x.Password == Password).Count() == 1)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> Login02(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return res;
        }

        // GetUserStatus()
        public string GetUserStatus(string UserName)
        {
            Users[] res_01 = { };
            AccountStatus[] res_02 = { };

            try
            {
                var SQLQuery = string.Format("SELECT IdStatus FROM Users WHERE UserName = \"{0}\"", UserName);
                res_01 = con.GetContext().ExecQuery<Users>(SQLQuery).ToArray();

                SQLQuery = string.Format("SELECT Status FROM AccountStatus WHERE IdStatus = {0}", res_01[0].IdStatus);
                res_02 = con.GetContext().ExecQuery<AccountStatus>(SQLQuery).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetUserStatus(). \nDescripción: " + ex.Message);
            }
            return (tools.Capitalize(tools.Decrypt(res_02[0].Status)));
        }

        // GetFailedAttempts()
        public int GetFailedAttempts(string UserName)
        {
            Users[] res = { };

            try
            {
                var SQLQuery = string.Format("SELECT FailedAttempts FROM Users WHERE UserName = \"{0}\"", UserName);
                res = con.GetContext().ExecQuery<Users>(SQLQuery).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetFailedAttempts(). \nDescripción: " + ex.Message);
            }
            return (Convert.ToInt32(res[0].FailedAttempts));
        }

        // CreateNewFailedAttempt()
        public void CreateNewFailedAttempt(string UserName)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                var res = GetFailedAttempts(UserName);

                if (res < 3)
                {
                    res = res + 1;
                    db.RegisterTable<Users>();

                    db.UpdateItem(UserName,
                    put: () => new Users
                    {
                        FailedAttempts = res
                    });

                    switch (res)
                    {
                        case 3:
                            LockAccount(UserName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> CreateNewFailedAttempt(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // DeleteFailedAttempts()
        public void DeleteFailedAttempts(string UserName)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    FailedAttempts = 0
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> DeleteFailedAttempt(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // LockAccount()
        private void LockAccount(string UserName)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    IdStatus = 2
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> LockAccount(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        #region ForgotPassword.aspx 

        // CreateRandomPassword()
        private string CreateRandomPassword()
        {
            // Cantidad de caracteres
            int length = 8;
            var res = "";

            try
            {
                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder SB = new StringBuilder();
                Random rnd = new Random();

                while (0 < length--)
                {
                    SB.Append(valid[rnd.Next(valid.Length)]);
                }
                res = SB.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> CreateRandomPassword(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        // UpdateProfile()
        private void UpdatePassword(string UserName, string NewPassword)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    Password = NewPassword
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> UpdatePassword(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }
        
        // ResetPassword()
        public bool ResetPassword(string UserEmail, string Body, string UserName)
        {
            var res = false;
            var NewPassword = "ResetPassword.aspx?U=" + tools.Encrypt(UserName);

            var SystemEmail = "EPICBostonScientific@outlook.com";
            var SystemPassword = "EPIC1234";

            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                MailMessage email = new MailMessage();

                email.From = new MailAddress(SystemEmail, "EPIC Boston Scientific");
                email.Body = "Su contraseña se ha restaurado. \nSu nueva contraseña es: " + NewPassword + "\nSi presenta problemas para iniciar sesión comuniquese con el administrador.";
                email.Subject = "Restauración de Contraseña";
                email.To.Add(UserEmail);
                Body = Body.Replace("{NewPassword}", NewPassword);
                email.Body = Body;
                email.IsBodyHtml = true;

                client.Credentials = new NetworkCredential(SystemEmail, SystemPassword);
                client.EnableSsl = true;
                client.Send(email);

                NewPassword = tools.Encrypt(NewPassword.ToUpper());

                //UpdatePassword(UserName, NewPassword);
                res = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> ResetPassword(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        // GetUserEmail()
        public string GetUserEmail(string UserName)
        {
            Users[] res = { };

            try
            {
                var SQLQuery = string.Format("SELECT Email FROM Users WHERE UserName = \"{0}\"", UserName);
                res = con.GetContext().ExecQuery<Users>(SQLQuery).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetUserEmail(). \nDescripción: " + ex.Message);
            }
            return (tools.Decrypt(res[0].Email));
        }

        #endregion ForgotPassword.aspx



        //---------------------------------------------


        // UnlockAccount()
        public void UnlockAccount(string UserName)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    IdStatus = 1
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> UnlockAccount(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }
        
        // UpdateProfile()
        public void DeleteUser(string UserName)
        {
            try
            {
                var db = new PocoDynamo(con.GetClient());
                db.RegisterTable<Users>();

                db.DeleteItem<Users>(UserName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> CreateRandomPassword(). \nDescripción: " + ex.Message);
            }
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
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al subir la imagen. \nDescripción: " + ex.Message);
            }
        }

        // UpdateProfile()
        public void UpdateProfile(string Email_, string FirstName_, string LastName_, string Telephone_, string Phrase_, string Photo_)
        {
            try
            {
                var db = new PocoDynamo(con.GetClient());
                db.RegisterTable<Users>();

                db.UpdateItem(Email_,
                put: () => new Users
                {
                    FirstName = FirstName_,
                    LastName = LastName_,
                    Telephone = Telephone_,
                    Phrase = Phrase_,
                    Photo = Photo_
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al actualizar el perfil. \nDescripción: " + ex.Message);
            }
        }

        public Users[] GetUserInfo(string UserName)
        {
            Users[] res = { };
            UserName = tools.Encrypt(UserName.ToUpper());

            try
            {
                var db = new PocoDynamo(con.GetClient());
                res = db.ScanAll<Users>().Where(x => x.UserName == UserName).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: \nSe a producido un error al obtener la información del usuario. \nDescripción: " + ex.Message);
            }
            return res;
        }


    }
}