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
    public class SpecialisteRepository
    {

        /// <summary>
        /// Retourne la liste de tous les spécialistes
        /// </summary>
        /// <returns></returns>
        public static List<Specialiste> getSpecialistes()
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Specialiste>("SELECT * FROM SPECIALISTE", new DynamicParameters());
                return sortie.ToList();
            }
        }

        /// <summary>
        /// Retourne le spécialiste dont l'id est passé en paramètres
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Specialiste getSpecialiste(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Specialiste>("SELECT * FROM SPECIALISTE WHERE SpecialisteId=@id", new { id });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Retourne tous les spécialistes ayant déjà pris en charge un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <returns></returns>
        public static List<Specialiste> getSpecialistesPatient(int idPatient)
        {
            List<Suivi> suivis = SuiviRepository.getSuivisPatient(idPatient);
            List<Specialiste> specialistes = new List<Specialiste>();

            foreach (Suivi suivi in suivis)
                specialistes.Add(getSpecialiste(suivi.SpecialisteId));
            return specialistes;
        }

        /// <summary>
        /// Ajoute un nouveau spécialiste
        /// </summary>
        /// <param name="p"></param>
        public static void nouveauSpecialiste(Specialiste specialiste)
        {
            string nom = specialiste.SpecialisteNom;
            string prenom = specialiste.SpecialistePrenom;
            string specialite = specialiste.SpecialisteSpecialite;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("INSERT INTO SPECIALISTE (SpecialisteNom, SpecialistePrenom, SpecialisteSpecialite) VALUES (@nom, @prenom, @specialite)",
                    new { nom, prenom, specialite });
            }
        }

        /// <summary>
        /// Supprime le spécialiste dont l'id est passé en paramètres
        /// </summary>
        /// <param name="Id"></param>
        public static void deleteSpecialiste(int idSpecialiste)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Patient>("DELETE FROM SPECIALISTE WHERE SpecialisteId=@idSpecialiste", new { idSpecialiste });
            }
        }

        /// <summary>
        /// Mise à jour d'un spécialiste
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateNomSpecialiste(int idSpecialiste, string nom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE SPECIALISTE SET SpecialisteNom=@nom WHERE SpecialisteId=@idSpecialiste", new { nom, idSpecialiste });
            }
        }
        public static void updatePrenomSpecialiste(int idSpecialiste, string prenom)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE SPECIALISTE SET SpecialistePrenom=@prenom WHERE SpecialisteId=@idSpecialiste", new { prenom, idSpecialiste });
            }
        }
        public static void updateSpecialiteSpecialiste(int idSpecialiste, string specialite)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE SPECIALISTE SET SpecialisteSpecialite=@specialite WHERE SpecialisteId=@idSpecialiste", new { specialite, idSpecialiste });
            }
        }


    }
}
