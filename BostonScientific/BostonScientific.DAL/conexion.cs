using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Diagnostics;
using Amazon.S3;
using Amazon.S3.Model;

namespace BostonScientific.DAL
{
    public class conexion
    {
        // DynamoDB Client
        public AmazonDynamoDBClient GetClient()
        {
            var awsKey = "aws_key";
            var awsSecret = "as_secret_key";
            var awsRegion = "region_endpoint";
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

        // S3 Client
        public AmazonS3Client S3_GetClient()"
        {
            var awsKey = "aws_key";
            var awsSecret = "aws_secret_key";
            var awsRegion = "region_endpoint";
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
