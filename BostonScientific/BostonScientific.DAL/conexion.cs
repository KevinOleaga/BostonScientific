using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Diagnostics;
using Amazon.S3;

namespace BostonScientific.DAL
{
    public class conexion
    {
        private string awsKey = "AKIAIBK3JJO36MVM5ISQ";
        private string awsSecret = "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";
        private RegionEndpoint awsRegion = RegionEndpoint.USWest2;
        
        // DynamoDB Client
        public AmazonDynamoDBClient GetClient()
        {
            AmazonDynamoDBClient client;

            try
            {
                client = new AmazonDynamoDBClient(awsKey, awsSecret, awsRegion);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: Ha ocurriodo un error al obtener el cliente DynamoDB. \nDescripción: " + ex.Message + "\n");
                return (null);
            }
            return (client);
        }

        // DynamoDB Context
        public DynamoDBContext GetContext()
        {
            var ctx = new DynamoDBContext(GetClient());
            return ctx;
        }

        // S3 Client
        public AmazonS3Client S3_GetClient()
        {
            var awsKey = "AKIAIBK3JJO36MVM5ISQ";
            var awsSecret = "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";
            var awsRegion = RegionEndpoint.USWest2;
            AmazonS3Client client;

            try
            {
                client = new AmazonS3Client(awsKey, awsSecret, awsRegion);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: Ha ocurriodo un error al obtener el cliente de la capa S3. \nDescripción: " + ex.Message + "\n");
                return (null);
            }
            return (client);
        }
    }
}
