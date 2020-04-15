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
    public class AnamneseRepository
    {

        /// <summary>
        /// Retourne l'anamnèse d'un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <returns></returns>
        public static Anamnese getAnamnesePatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Anamnese>("SELECT * FROM ANAMNESE WHERE AnamneseId=@idPatient", new { idPatient });
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajoute une nouvelle anamnèse à un patient
        /// </summary>
        /// <param name="p"></param>
        public static void nouvelleAnamnese(int idPatient, Anamnese anamnese)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                string interet = anamnese.Interet;
                string volonte = anamnese.Volonte;
                string place = anamnese.Place;
                string commentaire = anamnese.Commentaire;
                string designationVisuelle = anamnese.DesignationVisuelle;
                string mimiques = anamnese.Mimiques;
                string discours = anamnese.Discours;
                string opposition = anamnese.Opposition;

                connection.Execute("INSERT INTO ANAMNESE (Interet, Volonte, Place, Commentaire, DesignationVisuelle, Mimiques, Discours, Opposition, PatientId) VALUES " +
                    "(@interet, @volonte, @place, @commentaire, @designationVisuelle, @mimiques, @discours, @opposition, @idPatient)", 
                    new { interet, volonte, place, commentaire, designationVisuelle, mimiques, discours, opposition, idPatient });
            }
        }

        /// <summary>
        /// Supprime l'anamnese dont l'Id est passé en paramètre
        /// </summary>
        /// <param name="Id"></param>
        public static void deleteAnamnese(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Anamnese>("DELETE FROM ANAMNESE WHERE AnamneseId=@id", new { id });
            }
        }

        /// <summary>
        /// Mise à jour de l'intérêt d'une anamnèse
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateInteretAnamnese(int id, string interet)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set Interet=@interet WHERE AnamneseId=@id", new { interet, id });
            }
        }
        public static void updateVolonteAnamnese(int id, string volonte)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set Volonte=@volonte WHERE AnamneseId=@id", new { volonte, id });
            }
        }
        public static void updatePlaceAnamnese(int id, string place)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set Place=@place WHERE AnamneseId=@id", new { place, id });
            }
        }
        public static void updateCommentaireAnamnese(int id, string commentaire)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set Commentaire=@commentaire WHERE AnamneseId=@id", new { commentaire, id });
            }
        }
        public static void updateDesignationVisuelleAnamnese(int id, string designationVisuelle)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set DesignationVisuelle=@designationVisuelle WHERE AnamneseId=@id", new { designationVisuelle, id });
            }
        }
        public static void updateMimiquesAnamnese(int id, string mimiques)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set Mimiques=@mimiques WHERE AnamneseId=@id", new { mimiques, id });
            }
        }
        public static void updateDiscoursAnamnese(int id, string discours)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set Discours=@discours WHERE AnamneseId=@id", new { discours, id });
            }
        }
        public static void updateOppositionAnamnese(int id, string opposition)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE ANAMNESE set Opposition=@opposition WHERE AnamneseId=@id", new { opposition, id });
            }
        }
    }
}
