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
    public class EnseignantRepository
    {

        /// <summary>
        /// Retourne l'enseignant d'un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <returns></returns>
        public static Enseignant getEnseignantPatient(int idPatient)
        {
            Patient patient = PatientRepository.getPatient(idPatient);
            int idEnseignant = patient.EnseignantId;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Enseignant>("SELECT * FROM ENSEIGNANT WHERE EnseignantId=@idEnseignant", new { idEnseignant });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajouter un nouvel enseignant à une école
        /// </summary>
        /// <param name="idEcole"></param>
        /// <param name="enseignant"></param>
        public static void nouvelEnseignant(int idEcole, Enseignant enseignant)
        {
            string nom = enseignant.EnseignantNom;
            string prenom = enseignant.EnseignantPrenom;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("INSERT INTO ENSEIGNANT (EnseignantNom, EnseignantPrenom, EcoleId) VALUES (@nom, @prenom, @idEcole)", new { nom, prenom, idEcole });
            }
        }

        /// <summary>
        /// Supprime un enseignant
        /// </summary>
        /// <param name="id"></param>
        public static void deleteProche(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Patient>("DELETE FROM ENSEIGNANT WHERE EnseignantId=@id", new { id });
            }
        }

        /// <summary>
        /// Mise à jour d'un enseignant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        public static void updateNomEnseignant(int id, string nom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ENSEIGNANT SET EnseignantNom=@nom WHERE EnseignantId=@id", new { nom, id });
            }
        }
        public static void updatePrenomEnseignant(int id, string prenom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ENSEIGNANT SET EnseignantPrenom=@prenom WHERE EnseignantId=@id", new { prenom, id });
            }
        }
        
    }
}
