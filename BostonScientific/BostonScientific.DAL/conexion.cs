using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Diagnostics;
using System.Globalization;

namespace BostonScientific.DAL
{
    public class conexion
    {
        // DynamoDB Client
        public AmazonDynamoDBClient GetClient()
        {
            var awsKey = "AKIAIBK3JJO36MVM5ISQ";
            var awsSecret = "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";
            var awsRegion = RegionEndpoint.USWest2;
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

        // Capitalize
        public string Capitalize(string text)
        {
            string res = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return res;
        }
       
    }
}
