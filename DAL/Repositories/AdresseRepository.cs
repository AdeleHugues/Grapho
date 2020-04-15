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
    public class AdresseRepository
    {

        /// <summary>
        /// Retourne toutes les adresses d'un patient
        /// </summary>
        /// <returns></returns>
        public static List<Adresse> getAdressesPatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Adresse>("SELECT * FROM ADRESSE WHERE PatientId=@idPatient", new { idPatient });
                return sortie.ToList();
            }
        }

        /// <summary>
        /// Retourne une adresse spécifique d'un patient 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Adresse getAdressePatient(int idPatient, int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Adresse>("SELECT * FROM ADRESSE WHERE PatientId=@idPatient AND AdresseId=@id", new { idPatient, id });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajoute une nouvelle adresse d'un patient
        /// </summary>
        /// <param name="p"></param>
        public static void nouvelleAdresse(int idPatient, Adresse adresse)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                string designation = adresse.AdresseDesignation;
                string rue = adresse.AdresseRue;
                string cp = adresse.AdresseCP;
                string ville = adresse.AdresseVille;

                connection.Execute("INSERT INTO ADRESSE (AdresseDesignation, AdresseRue, AdresseCP, AdresseVille, PatientId) VALUES (@designation, @rue, @cp, @ville, @idPatient)", new { designation, rue, cp, ville, idPatient});
            }
        }

        /// <summary>
        /// Supprime l'adresse dont l'Id est passé en paramètre
        /// </summary>
        /// <param name="Id"></param>
        public static void deleteAdresse(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Adresse>("DELETE FROM ADRESSE WHERE AdresseId=@id", new { id });
            }
        }

        /// <summary>
        /// Mise à jour de la designation d'une adresse
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateDesignationAdresse(int id, string designation)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ADRESSE set AdresseDesignation=@designation WHERE AdresseId=@id", new { designation, id });
            }
        }
        public static void updateRueAdresse(int id, string rue)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ADRESSE SET AdresseRue=@rue WHERE AdresseId=@id", new { rue, id });
            }
        }
        public static void updateCPAdresse(int id, string cp)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ADRESSE SET AdresseCP=@cp WHERE AdresseId=@id", new { cp, id });
            }
        }
        public static void updateVilleAdresse(int id, string ville)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ADRESSE SET AdresseVille=@ville WHERE AdresseId=@id", new { ville, id });
            }
        }


    }
}
