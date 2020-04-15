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
    public class EcoleRepository
    {

        /// <summary>
        /// Retourne l'école d'un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <returns></returns>
        public static Ecole getEcolePatient(int idPatient)
        {
            Enseignant enseignant = EnseignantRepository.getEnseignantPatient(idPatient);
            int idEcole = enseignant.EcoleId;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Ecole>("SELECT * FROM ECOLE WHERE EcoleId=@idEcole", new { idEcole });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajoute une nouvelle école
        /// </summary>
        /// <param name="ecole"></param>
        public static void nouvelleEcole(Ecole ecole)
        {
            string nom = ecole.EcoleNom;
            string adresse = ecole.EcoleAdresse;
            string cp = ecole.EcoleCP;
            string ville = ecole.EcoleVille;
            string telephone = ecole.EcoleTelephone;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("INSERT INTO ECOLE (EcoleNom, EcoleAdresse, EcoleCP, EcoleVille, EcoleTelephone) VALUES " +
                    "(@nom, @adresse, @cp, @ville, @telephone)", new { nom, adresse, cp, ville, telephone });
            }
        }

        /// <summary>
        /// Supprime une école
        /// </summary>
        /// <param name="id"></param>
        public static void deleteEcole(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Ecole>("DELETE FROM ECOLE WHERE EcoleId=@id", new { id });
            }
        }

        /// <summary>
        /// Mise à jour du nom d'une école
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateEcoleNom(int id, string nom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ECOLE set EcoleNom=@nom WHERE EcoleId=@id", new { nom, id });
            }
        }
        public static void updateEcoleAdresse(int id, string adresse)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ECOLE set EcoleAdresse=@adresse WHERE EcoleId=@id", new { adresse, id });
            }
        }
        public static void updateEcoleCP(int id, string cp)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ECOLE set EcoleCP=@nom WHERE EcoleId=@id", new { cp, id });
            }
        }
        public static void updateEcoleVille(int id, string ville)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ECOLE set EcoleVille=@ville WHERE EcoleId=@id", new { ville, id });
            }
        }
        public static void updateEcoleTelephone(int id, string telephone)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ECOLE set EcoleTelephone=@telephone WHERE EcoleId=@id", new { telephone, id });
            }
        }
    }
}
