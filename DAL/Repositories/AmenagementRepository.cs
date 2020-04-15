using Dapper;
using Domain.Classes_métier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AmenagementRepository
    {

        /// <summary>
        /// Retourne toutes les amnénagements d'un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <returns></returns>
        public static List<Amenagement> getAmenagementsPatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Amenagement>("SELECT * FROM AMENAGEMENT WHERE PatientId=@idPatient", new { idPatient });
                return sortie.ToList();
            }
        }

        /// <summary>
        ///  Retourne un aménagement spécifique d'un patient 
        /// </summary>
        /// <param name="idPatient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Amenagement getAmenagementPatient(int idPatient, int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Amenagement>("SELECT * FROM AMENAGEMENT WHERE PatientId=@idPatient AND AmenagementId=@id", new { idPatient, id });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajoute un nouvel aménagement à un patient
        /// </summary>
        /// <param name="p"></param>
        public static void nouvelAmenagement(int idPatient, Amenagement amenagement)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                string amenagementType = amenagement.AmenagementType;

                connection.Execute("INSERT INTO AMENAGEMENT (AmenagementType, PatientId) VALUES (@amenagementType, @idPatient)", new { amenagementType, idPatient });
            }
        }

        /// <summary>
        /// Supprime l'aménagement dont l'Id est passé en paramètre
        /// </summary>
        /// <param name="Id"></param>
        public static void deleteAmenagement(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Amenagement>("DELETE FROM AMENAGEMENT WHERE AmenagementId=@id", new { id });
            }
        }

        /// <summary>
        /// Mise à jour du type d'un aménagement
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateTypeAmenagement(int id, string type)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE AMENAGEMENT set AmenagementType=@type WHERE AmenagementId=@id", new { type, id });
            }
        }

    }
}
