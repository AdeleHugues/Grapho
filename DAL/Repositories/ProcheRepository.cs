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
    public class ProcheRepository
    {

        /// <summary>
        /// Retourne tous les proches d'un patient
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static List<Proche> getProchesPatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Proche>("SELECT * FROM PROCHE WHERE PatientId=@idPatient", new { idPatient });
                return sortie.ToList();
            }
        }

        /// <summary>
        /// Retourne un proche particulier d'un patient
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Proche getProche(int idPatient, int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Proche>("SELECT * FROM PROCHE WHERE PatientId=@idPatient AND ProcheId=@id", new { idPatient, id });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajoute un nouveau proche à un patient
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Pr"></param>
        public static void nouveauProche(int idPatient, Proche proche)
        {
            string nom = proche.ProcheNom;
            string prenom = proche.ProchePrenom;
            int age = proche.ProcheAge;
            bool sexe = proche.ProcheSexe;
            string place = proche.ProchePlace;
            bool disponibilite = proche.ProcheDisponibilite;
            bool lateralite = proche.ProcheLateralite;
            bool trouble = proche.ProcheTrouble;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("INSERT INTO PROCHE (ProcheNom, ProchePrenom, ProcheAge, ProcheSexe, ProchePlace, ProcheDisponibilite, ProcheLateralite, ProcheTrouble, PatientId) " +
                    "VALUES (@nom, @prenom, @age, @sexe, @place, @disponibilite, @lateralite, @trouble, @idPatient)",
                    new { nom, prenom, age, sexe, place, disponibilite, lateralite, trouble, idPatient });
            }
        }

        /// <summary>
        /// Supprime un proche
        /// </summary>
        /// <param name="Id"></param>
        public static void deleteProche(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Patient>("DELETE FROM PROCHE WHERE ProcheId=@id", new { id });
            }
        }

        /// <summary>
        /// Mise à jour d'un patient
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateNomProche(int id, string nom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProcheNom=@nom WHERE ProcheId=@id", new { nom, id });
            }
        }
        public static void updatePrenomProche(int id, string prenom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProchePrenom=@prenom WHERE ProcheId=@id", new { prenom, id });
            }
        }
        public static void updateAgeProche(int id, int age)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProcheAge=@age WHERE ProcheId=@id", new { age, id });
            }
        }
        public static void updateSexeProche(int id, bool sexe)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProcheSexe=@sexe WHERE ProcheId=@id", new { sexe, id });
            }
        }
        public static void updatePlaceProche(int id, string place)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProchePlace=@place WHERE ProcheId=@id", new { place, id });
            }
        }
        public static void updateDisponibiliteProche(int id, bool disponibilite)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProcheDisponibilite=@disponibilite WHERE ProcheId=@id", new { disponibilite, id });
            }
        }
        public static void updateLateraliteProche(int id, bool lateralite)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProcheLateralite=@lateralite WHERE ProcheId=@id", new { lateralite, id });
            }
        }
        public static void updateTroubleProche(int id, bool trouble)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE PROCHE SET ProcheTrouble=@trouble WHERE ProcheId=@id", new { trouble, id });
            }
        }

    }
}
