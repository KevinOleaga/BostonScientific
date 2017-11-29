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
using System.Collections.Generic;
using System.IO;
using Amazon.S3;

namespace BostonScientific.DAL.Metodos
{
    public class MUsers : IUsers
    {
        conexion con = new conexion();
        private ITools _tools;

        public MUsers()
        {
         //   _tools = new MTools();
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
            Users[] res_Users = { };
            AccountStatus[] res_AccountStatus = { };

            try
            {
                var SQLQuery = string.Format("SELECT IdStatus FROM Users WHERE UserName = \"{0}\"", UserName);
                res_Users = con.GetContext().ExecQuery<Users>(SQLQuery).ToArray();

                SQLQuery = string.Format("SELECT Status FROM AccountStatus WHERE IdStatus = {0}", res_Users[0].IdStatus);
                res_AccountStatus = con.GetContext().ExecQuery<AccountStatus>(SQLQuery).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetUserStatus(). \nDescripción: " + ex.Message);
            }
            return (_tools.Capitalize(_tools.Decrypt(res_AccountStatus[0].Status)));
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
                            _LockAccount(UserName);
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
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> DeleteFailedAttempts(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // LockAccount()
        private void _LockAccount(string UserName)
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

        // UserExist()
        public bool UserExist(string UserName)
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
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> UserExist(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
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
            return (_tools.Decrypt(res[0].Email));
        }

        // ResetPassword()
        public bool ResetPassword(string UserEmail, string Body, string UserName)
        {
            var res = false;
            var NewLink = "http://localhost:59133/ResetPassword.aspx?U=" + UserName;
            var NewSecretCode = _UpdateSecretCode(UserName);

            var SystemEmail = "EPICBostonScientific@outlook.com";
            var SystemPassword = "EPIC1234";

            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                MailMessage email = new MailMessage();

                email.From = new MailAddress(SystemEmail, "EPIC Boston Scientific");
                email.Body = "Se ha solicitado la restauración de su contraseña. \nSi presenta problemas para iniciar sesión comuniquese con el administrador.";
                email.Subject = "Restauración de Contraseña";
                email.To.Add("oleaga@outlook.com");
                Body = Body.Replace("{NewLink}", NewLink);
                Body = Body.Replace("{NewCode}", NewSecretCode);
                email.Body = Body;
                email.IsBodyHtml = true;

                client.Credentials = new NetworkCredential(SystemEmail, SystemPassword);
                client.EnableSsl = true;
                client.Send(email);

                res = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> ResetPassword(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        // UpdateSecretCode()
        private string _UpdateSecretCode(string UserName)
        {
            var db = new PocoDynamo(con.GetClient());
            var NewSecretCode = _CreateRandomPassword();

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    SecretCode = _tools.Encrypt(NewSecretCode)
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> UpdateSecretCode(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return NewSecretCode;
        }

        // CreateRandomPassword()
        private string _CreateRandomPassword()
        {
            // Password Size
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

        #endregion ForgotPassword.aspx

        #region ResetPassword.aspx

        // CheckCode()
        public bool CheckCode(string UserName, string SecretCode)
        {
            var res = false;
            var db = new PocoDynamo(con.GetClient());

            try
            {
                if (db.ScanAll<Users>().Where(x => x.UserName == UserName && x.SecretCode == SecretCode).Count() == 1)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> CheckCode(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return res;
        }

        // DeleteSecretCode()
        public void SetRandomSecretCode(string UserName)
        {
            var db = new PocoDynamo(con.GetClient());
            var RandomCode = _CreateRandomPassword();

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    SecretCode = RandomCode
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> DeleteSecretCode(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // UpdatePassword()
        public void UpdatePassword(string UserName, string NewPassword)
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

        #endregion ResetPassword.aspx

        #region MyProfile.aspx

        // GetUserInfo()
        public Users[] GetUserInfo(string UserName)
        {
            Users[] res = { };
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<Users>().Where(x => x.UserName == UserName).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetUserInfo(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        // GetUserRole()
        public string GetUserRole(int IdRole)
        {
            Roles[] res = { };

            try
            {
                var SQLQuery = string.Format("SELECT Name FROM Roles WHERE IdRole = {0}", IdRole);
                res = con.GetContext().ExecQuery<Roles>(SQLQuery).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetUserRole(). \nDescripción: " + ex.Message);
            }
            return _tools.Decrypt(res[0].Name);
        }

        // GetTotalUsers()
        public int GetTotalMembers()
        {
            int res = 0;
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<Users>().Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetTotalMembers(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return res;
        }

        // GetMembersInfo()
        public Users[] GetMembersInfo()
        {
            Users[] res = { };
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<Users>().ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetMembersInfo(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        // GetMembersInfo()
        public Roles[] GetMembersRole(int IdRole)
        {
            Roles[] res = { };

            try
            {
                var SQLQuery = string.Format("SELECT Name FROM Roles WHERE IdRole = {0}", IdRole);
                res = con.GetContext().ExecQuery<Roles>(SQLQuery).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetMembersRole(). \nDescripción: " + ex.Message);
            }
            return res;
        }

        public void SendFileToS3(Stream FileAddress, string FileName, string UserName)
        {
            var client = con.S3_GetClient();

            var BucketName = "bostonscientific";
            var SubDirectory = "Users";

            try
            {
                TransferUtility utility = new TransferUtility(client);
                TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                request.BucketName = BucketName + @"/" + SubDirectory;

                request.Key = FileName;
                request.InputStream = FileAddress;
                request.CannedACL = S3CannedACL.PublicRead;
                utility.Upload(request);

                var NewPhoto = _tools.Encrypt(string.Format("https://s3-us-west-2.amazonaws.com/bostonscientific/Users/{0}", FileName));
                _UpdatePhoto(UserName, NewPhoto);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> SendFileToS3(). \nDescripción: " + ex.Message);
            }
        }

        // UpdatePhoto()
        private void _UpdatePhoto(string UserName, string NewPhoto)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    Photo = NewPhoto
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> _UpdatePhoto(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // UpdateProfile()
        public void UpdateProfile(List<string> data, string UserName)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Users>();

                db.UpdateItem(UserName,
                put: () => new Users
                {
                    FirstName = data[0],
                    LastName = data[1],
                    Email = data[2],
                    Telephone = data[3],
                    Phrase = data[4]
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> UpdateProfile(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion MyProfile.aspx



        public Users[] GetUsersInfo()
        {
            Users[] res = { };
            var db = new PocoDynamo(con.GetClient());

            try
            {
                res = db.ScanAll<Users>().ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> GetUsersInfo(). \nDescripción: " + ex.Message);
            }
            return res;
        }









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




        public void CreateTable_Users()
        {
            throw new NotImplementedException();
        }

        /*
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
*/
    }
}