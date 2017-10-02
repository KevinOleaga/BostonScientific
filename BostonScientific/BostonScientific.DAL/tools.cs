using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Diagnostics;

namespace BostonScientific.DAL
{
    public class tools
    {
        conexion con = new conexion();
        public void CreateTable()
        {
            try
            {
                string tableName = "Users";
                
                var db = new PocoDynamo(con.GetClient()).RegisterTable<Users>();
                db.InitSchema();

                Debug.WriteLine("\nCompletado! \nSe a creado la tabla " + tableName + " correctamente.\n");

                var newUser = new Users
                {
                    Email = "OLEAGA@OUTLOOK.COM",
                    Password = "1234",
                    FirstName = "KEVIN",
                    LastName = "OLEAGA GARCIA",
                    IdRole = "1",
                    Telephone = "6076-7225",
                    LastTime = "1/10/2017"
                };

                db.PutItem(newUser);

                Debug.WriteLine("\nCompletado! \nSe a creado un usuario default \nUsuario: ADMIN@OUTLOOK.COM \nPassword: 1234 \nRol: ADMIN.\n");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError: Ha ocurrido un error en la creación de la tabla 'Users'. \nDescripcion: " + ex.Message + "\n");
            }
        }
    }
}
