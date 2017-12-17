using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            finally
            {
                db.Close();
            }
            return res;
        }

        // DeleteSwitch()
        public void DeleteSwitch(string IdSwitch)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<DATA.Switch>();
                db.DeleteItem<DATA.Switch>(IdSwitch);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitchInfo -> GetPanelSwitches(). \nDescripción: " + ex.Message);
            }
        }

        // SendFileToS3()
        public void SendFileToS3(Stream FileStream, string FileName, string IdSwitch)
        {
            var client = con.S3_GetClient();

            var BucketName = "bostonscientific";
            var SubDirectory = "Files";

            try
            {
                TransferUtility utility = new TransferUtility(client);
                TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                request.BucketName = BucketName + @"/" + SubDirectory;

                request.Key = FileName;
                request.InputStream = FileStream;
                request.CannedACL = S3CannedACL.PublicRead;
                utility.Upload(request);

                var NewFile = _tools.Encrypt(string.Format("https://s3-us-west-2.amazonaws.com/bostonscientific/Files/{0}", FileName));
                FileName = _tools.Encrypt(FileName);

                AddFile(IdSwitch, NewFile, FileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> SendFileToS3(). \nDescripción: " + ex.Message);
            }
        }

        // AddFile()
        private void AddFile(string IdSwitch, string NewFile, string FileName)
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Files>();
                
                var NewFile_ = new Files
                {
                    IdSwitch = IdSwitch,
                    Location = NewFile,
                    FileName = FileName
                };

                db.PutItem(NewFile_);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MSwitchInfo -> GetPanelSwitches(). \nDescripción: " + ex.Message);
            }
        }

        public Files[] GetFiles(string IdSwitch)
        {
            var db = new PocoDynamo(con.GetClient());
            Files[] res = { };

            try
            {
                res = db.ScanAll<Files>().Where(x => x.IdSwitch == IdSwitch).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> GetPanelsInfo(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return res;
        }

        public int CountFiles(string IdSwitch)
        {
            var db = new PocoDynamo(con.GetClient());
            var res = 0;

            try
            {
                res = db.ScanAll<Files>().Where(x => x.IdSwitch == IdSwitch).Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> CountPanels(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return res;
        }

        public void DownloadDoc(string FileName)
        {
            var client = con.S3_GetClient();

            var BucketName = "bostonscientific";
            var SubDirectory = "Files";
            
            try
            {
                GetObjectRequest request = new GetObjectRequest();
                request.BucketName = BucketName + @"/" + SubDirectory;
                request.Key = FileName;
                GetObjectResponse response = client.GetObject(request);
                response.WriteResponseStreamToFile("E:\\BostonFiles\\" + FileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MUsers -> Download(). \nDescripción: " + ex.Message);
            }
        }

        // GetInfo()
        public int GetData2(string IdSwitch)
        {
            Debug.WriteLine(IdSwitch);

            var db = new PocoDynamo(con.GetClient());
            var r = 0;
            try
            {
                var q = db.FromQuery<testData>(x => x.Id == IdSwitch);
                var dbOrders = db.Query(q).Last();

                var results = dbOrders;
                r = results.payload.Medicion;
                Debug.WriteLine(results.Id);
                Debug.WriteLine(r);
                Debug.WriteLine(results.payload.Time);

                //res = db.ScanAll<testData>().Where(x => x.Id == "thing01/data").ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPanels -> GetInfo(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return r;
        }

        testData[] ISwitch.GetData(string IdSwitch)
        {
            throw new NotImplementedException();
        }
    }
}
