using BostonScientific.DAL.Interfaces;
using BostonScientific.DATA;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BostonScientific.DAL.Methods
{
    public class MPhrases : IPhrases
    {
        conexion con = new conexion();
        
        #region Site.Master

        // GetRandomPhrase()
        public string GetRandomPhrase()
        {
            var res = string.Empty;
            var db = new PocoDynamo(con.GetClient());

            try
            {
                Random rnd = new Random();
                var n = rnd.Next(1, 21);

                db.RegisterTable<Phrases>();
                res = db.GetItem<Phrases>(n).Phrase;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPharses -> GetRandomPharse(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return res;
        }

        #endregion Site.Master

        #region Managment

        // CreateTable()
        public void CreateTable()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.RegisterTable<Phrases>();
                db.InitSchema();

                List<string> phrases = new List<string>();
                phrases.Add("Para ganar en la vida, antes hay que saber perder");
                phrases.Add("Educa a los niños, y no será necesario castigar a los hombres");
                phrases.Add("Vive el presente sin olvidar el pasado, pero mirando siempre hacia el futuro");
                phrases.Add("La gente inteligente cuida lo que dice, respeta lo que escucha y medita lo que calla");
                phrases.Add("Si quieres una mano que te ayude, la encontraras al final de tu brazo");
                phrases.Add("La medida de la inteligencia es la habilidad para cambiar y adaptarse");
                phrases.Add("La mente es como un paracaídas, sólo funciona si se abre");
                phrases.Add("Eres el juez de tus propios actos y el árbitro de tu propio destino");
                phrases.Add("El dinero hace personas ricas, el conocimiento hace personas sabias, la humildad hace grandes personas");
                phrases.Add("Hace falta toda una vida para aprender a vivir");
                phrases.Add("No es sabia el que sabe sino el que no sabe y quiere aprender");
                phrases.Add("La sabiduría comienza donde termina el conocimiento");
                phrases.Add("Aprende del pasado, vive el presente y trabaja para el futuro");
                phrases.Add("En la vida algunas veces se gana, otras veces se aprende");
                phrases.Add("Un hombre inteligente jamás se irritaría, si tuviera delante siempre un espejo y se viera cuando discute");
                phrases.Add("Si quieres algo que nunca tuviste, debes hacer algo que nunca hiciste");
                phrases.Add("Lo malo de aprender con la experiencia, es que nunca nos graduamos");
                phrases.Add("El mayor defecto de los defectos es no darse cuenta de ninguno de ellos");
                phrases.Add("Experiencia es lo que conseguimos cuando no leemos las instrucciones");
                phrases.Add("Un tropezón puede prevenir una caída");

                for (int i = 1; i < 21; i++)
                {
                    var pharse = new Phrases
                    {
                        Id = i,
                        Phrase = phrases[i-1]
                    };

                    db.PutItem(pharse);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPhrases -> CreateTable(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }
        
        // DropTable()
        public void DropTable()
        {
            var db = new PocoDynamo(con.GetClient());

            try
            {
                db.DeleteTable<Phrases>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPhrases -> DropTable(). \nDescripción: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        // DeleteTable()
        public void DeleteTable()
        {
            try
            {
                DropTable();
                CreateTable();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nError \nUbicación: Capa DAL -> MPhrases -> DeleteTable(). \nDescripción: " + ex.Message);
            }
        }

        #endregion Managment
    }
}