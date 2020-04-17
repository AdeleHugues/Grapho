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
    public class PatientRepository
    {

        /// <summary>
        /// Retourne la liste de tous les patients
        /// </summary>
        /// <returns></returns>
        public static List<Patient> getPatients()
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Patient>("SELECT * FROM PATIENT", new DynamicParameters());
                return sortie.ToList();
            }
        }

        /// <summary>
        /// Retourne le patient dont l'id est passé en paramètres
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Patient getPatient(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Patient>("SELECT * FROM PATIENT WHERE PatientId=@id", new { id });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajoute un nouveau patient
        /// </summary>
        /// <param name="p"></param>
        public static int nouveauPatient(Patient patient, int idEnseignant)
        {
            string nom = patient.PatientNom;
            string prenom = patient.PatientPrenom;
            bool sexe = patient.PatientSexe;
            DateTime naissance = patient.PatientNaissance;
            string commentaire = patient.Commentaire;
            string photo = patient.PatientPhoto;
            string photoEcriture = patient.PatientPhotoEcriture;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Patient>("INSERT INTO PATIENT (PatientNom, PatientPrenom, PatientSexe, PatientNaissance, Commentaire, PatientPhoto, PatientPhotoEcriture, EnseignantId) " +
                    "VALUES (@nom, @prenom, @sexe, @naissance, @commentaire, @photo, @photoEcriture, @idEnseignant)", 
                    new { nom, prenom, sexe, naissance, commentaire, photo, photoEcriture, idEnseignant });

                var dernier = connection.Query<int>("SELECT MAX(PatientId) FROM Patient");
                int dernierId = dernier.ToList()[0];
                return dernierId;
            }
        }

        /// <summary>
        /// Supprime le patient dont l'id est passé en paramètres
        /// </summary>
        /// <param name="Id"></param>
        public static void deletePatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Patient>("DELETE FROM PATIENT WHERE PatientId=@idPatient", new { idPatient });
            }
        }

        /// <summary>
        /// Mise à jour d'un patient
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateNomPatient(int idPatient, string nom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET PatientNom=@nom WHERE PatientId=@idPatient", new { nom, idPatient });
            }
        }
        public static void updatePrenomPatient(int idPatient, string prenom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET PatientPrenom=@prenom WHERE PatientId=@idPatient", new { prenom, idPatient });
            }
        }
        public static void updateSexePatient(int idPatient, bool sexe)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET PatientSexe=@sexe WHERE PatientId=@idPatient", new { sexe, idPatient });
            }
        }
        public static void updateNaissancePatient(int idPatient, DateTime date)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET PatientNaissance=@date WHERE PatientId=@idPatient", new { date, idPatient });
            }
        }
        public static void updateDateBilanPatient(int idPatient, DateTime date)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET PatientDateBilan=@date WHERE PatientId=@idPatient", new { date, idPatient });
            }
        }
        public static void updateCommentairePatient(int idPatient, string commentaire)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET Commentaire=@commentaire WHERE PatientId=@idPatient", new { commentaire, idPatient });
            }
        }
        public static void updatePhotoPatient(int idPatient, string photo)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET PatientPhoto=@photo WHERE PatientId=@idPatient", new { photo, idPatient });
            }
        }
        public static void updatePhotoEcriturePatient(int idPatient, string photoEcriture)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET PatientPhotoEcriture=@photoEcriture WHERE PatientId=@idPatient", new { photoEcriture, idPatient });
            }
        }
        public static void updateEcolePatient(int idPatient, Enseignant enseignant)
        {
            int idEnseignant = enseignant.EnseignantId;
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PATIENT SET EnseignantId=@idEnseignant WHERE PatientId=@idPatient", new { idEnseignant, idPatient });
            }
        }


    }
}
