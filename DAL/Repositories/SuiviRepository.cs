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
    public class SuiviRepository
    {

        /// <summary>
        /// Retourne la liste de tous les suivis d'un patient
        /// </summary>
        /// <returns></returns>
        public static List<Suivi> getSuivisPatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Suivi>("SELECT * FROM SUIVI WHERE PatientId=@idPatient", new { idPatient });
                return sortie.ToList();
            }
        }

        /// <summary>
        /// Ajoute un nouveau suivi
        /// </summary>
        /// <param name="p"></param>
        public static void nouveauSuivi(Suivi suivi)
        {
            int idPatient = suivi.PatientId;
            int idSpecialiste = suivi.SpecialisteId;
            DateTime debut = suivi.Debut;
            DateTime fin = suivi.Fin;
            bool adressage = suivi.Adressage;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("INSERT INTO SUIVI (PatientId, SpecialisteId, Debut, Fin, Adressage) VALUES (@idPatient, @idSpecialiste, @debut, @fin, @adressage)",
                    new { idPatient, idSpecialiste, debut, fin, adressage });
            }
        }

        /// <summary>
        /// Supprime le suivi dont les id sont passés en paramètres
        /// </summary>
        /// <param name="Id"></param>
        public static void deleteSuivi(int idSpecialiste, int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Suivi>("DELETE FROM SUIVI WHERE SpecialisteId=@idSpecialiste AND PatientId=@idPatient", new { idSpecialiste, idPatient });
            }
        }

        /// <summary>
        /// Mise à jour d'un suivi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateDebutSuivi(int idSpecialiste, int idPatient, DateTime debut)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE SUIVI SET Debut=@debut WHERE SpecialisteId=@idSpecialiste AND PatientId=@idPatient", new { debut, idSpecialiste, idPatient });
            }
        }
        public static void updateFinSuivi(int idSpecialiste, int idPatient, DateTime fin)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE SUIVI SET Fin=@fin WHERE SpecialisteId=@idSpecialiste AND PatientId=@idPatient", new { fin, idSpecialiste, idPatient });
            }
        }
        public static void updateAdressageSuivi(int idSpecialiste, int idPatient, bool adressage)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE SUIVI SET Adressage=@adressage WHERE SpecialisteId=@idSpecialiste AND PatientId=@idPatient", new { adressage, idSpecialiste, idPatient });
            }
        }

    }
}
