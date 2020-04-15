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
    public class TestsRepository
    {

        /// <summary>
        /// Retourne les tests d'un patient
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static Tests getTestsPatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Tests>("SELECT * FROM TESTS WHERE TestsId=@idPatient", new { idPatient });
                if (sortie.ToList().Count > 0)
                    return sortie.ToList()[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Ajoute de nouveaux tests à un patient
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Pr"></param>
        public static void nouveauxTests(int idPatient, Tests tests)
        {
            string acuite = tests.Acuite;
            string orthoptie = tests.Orthoptie;
            string reflexe = tests.Reflexe;
            string lateralite = tests.Lateralite;
            string connaissanceLateralite = tests.ConnaissanceLateralite;
            string pattes = tests.Pattes;
            string reflexeAsymetriqueCou = tests.ReflexeAsymetriqueCou;
            string reflexeSymetriqueCou = tests.ReflexeSymetriqueCou;
            string reflexePrehension = tests.ReflexePrehension;
            string reflexeSuccion = tests.ReflexeSuccion;
            string reflexeMoro = tests.ReflexeMoro;
            string reflexeRedressement = tests.ReflexeRedressement;
            string reflexeFouissement = tests.ReflexeFouissement;
            string reflexePoints = tests.ReflexePoints;
            string reflexeSurvie = tests.ReflexeSurvie;
            string reflexeNage = tests.ReflexeNage;
            string reflexeGlabellaire = tests.ReflexeGlabellaire;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("INSERT INTO TESTS (Acuite, Orthoptie, Reflexe, Lateralite, ConnaissanceLateralite, Pattes, ReflexeAsymetriqueCou, ReflexeSymetriqueCou, ReflexePrehension, ReflexeSuccion," +
                    "ReflexeMoro, ReflexeRedressement, ReflexeFouissement, ReflexePoints, ReflexeSurvie, ReflexeNage, ReflexeGlabellaire, TestsId) " +
                    "VALUES (@acuite, @orthoptie, @reflexe, @lateralite, @connaissanceLateralite,@pattes, @reflexeAsymetriqueCou, @reflexeSymetriqueCou, @reflexePrehension, @reflexeSuccion," +
                    "@reflexeMoro, @reflexeRedressement, @reflexeFouissement, @reflexePoints, @reflexeSurvie, @reflexeNage, @reflexeGlabellaire, @idPatient)",
                    new { acuite, orthoptie, reflexe, lateralite, connaissanceLateralite, pattes, reflexeAsymetriqueCou, reflexeSymetriqueCou, reflexePrehension, reflexeSuccion,
                        reflexeMoro, reflexeRedressement, reflexeFouissement, reflexePoints, reflexeSurvie, reflexeNage, reflexeGlabellaire, idPatient});
            }
        }

        /// <summary>
        /// Supprime des tests
        /// </summary>
        /// <param name="Id"></param>
        public static void deleteTests(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Patient>("DELETE FROM TESTS WHERE TestsId=@idPatient", new { idPatient });
            }
        }

        /// <summary>
        /// Mise à jour des tests d'un patient
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateOrigineDemandeTests(int idPatient, string origineDemande)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET OrigineDemande=@origineDemande WHERE TestsId=@idPatient", new { origineDemande, idPatient });
            }
        }
        public static void updateAcuiteTests(int idPatient, string acuite)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET Acuite=@acuite WHERE TestsId=@idPatient", new { acuite, idPatient });
            }
        }
        public static void updateOrthoptieTests(int idPatient, string orthoptie)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET Orthoptie=@orthoptie WHERE TestsId=@idPatient", new { orthoptie, idPatient });
            }
        }
        public static void updateReflexeTests(int idPatient, string reflexe)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET Reflexe=@reflexe WHERE TestsId=@idPatient", new { reflexe, idPatient });
            }
        }
        public static void updateLateraliteTests(int idPatient, string lateralite)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET Lateralite=@lateralite WHERE TestsId=@idPatient", new { lateralite, idPatient });
            }
        }
        public static void updateConnaissanceLateraliteTests(int idPatient, string connaissanceLateralite)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ConnaissanceLateralite=@connaissanceLateralite WHERE TestsId=@idPatient", new { connaissanceLateralite, idPatient });
            }
        }
        public static void updatePattesTests(int idPatient, string pattes)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET Pattes=@pattes WHERE TestsId=@idPatient", new { pattes, idPatient });
            }
        }
        public static void updateReflexeAsymetriqueCouTests(int idPatient, string reflexeAsymetriqueCou)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeAsymetriqueCou=@reflexeAsymetriqueCou WHERE TestsId=@idPatient", new { reflexeAsymetriqueCou, idPatient });
            }
        }
        public static void updateReflexeSymetriqueCouTests(int idPatient, string reflexeSymetriqueCou)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeSymetriqueCou=@reflexeSymetriqueCou WHERE TestsId=@idPatient", new { reflexeSymetriqueCou, idPatient });
            }
        }
        public static void updateReflexePrehensionTests(int idPatient, string reflexePrehension)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexePrehension=@reflexePrehension WHERE TestsId=@idPatient", new { reflexePrehension, idPatient });
            }
        }
        public static void updateReflexeSuccionTests(int idPatient, string reflexeSuccion)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeSuccion=@reflexeSuccion WHERE TestsId=@idPatient", new { reflexeSuccion, idPatient });
            }
        }
        public static void updateReflexeMoroTests(int idPatient, string reflexeMoro)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeMoro=@reflexeMoro WHERE TestsId=@idPatient", new { reflexeMoro, idPatient });
            }
        }
        public static void updateReflexeRedressementTests(int idPatient, string reflexeRedressement)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeRedressement=@reflexeRedressement WHERE TestsId=@idPatient", new { reflexeRedressement, idPatient });
            }
        }
        public static void updateReflexeFouissementTests(int idPatient, string reflexeFouissement)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeFouissement=@reflexeFouissement WHERE TestsId=@idPatient", new { reflexeFouissement, idPatient });
            }
        }
        public static void updateReflexePointsTests(int idPatient, string reflexePoints)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexePoints=@reflexePoints WHERE TestsId=@idPatient", new { reflexePoints, idPatient });
            }
        }
        public static void updateReflexeSurvieTests(int idPatient, string reflexeSurvie)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeSurvie=@reflexeSurvie WHERE TestsId=@idPatient", new { reflexeSurvie, idPatient });
            }
        }
        public static void updateReflexeNageTests(int idPatient, string reflexeNage)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeNage=@reflexeNage WHERE TestsId=@idPatient", new { reflexeNage, idPatient });
            }
        }
        public static void updateReflexeGlabellaireTests(int idPatient, string reflexeGlabellaire)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE TESTS SET ReflexeGlabellaire=@reflexeGlabellaire WHERE TestsId=@idPatient", new { reflexeGlabellaire, idPatient });
            }
        }
    }
}
