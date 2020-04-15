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
    public class ContactRepository
    {
        /// <summary>
        /// Retourne tous les contacts d'un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <returns></returns>
        public static List<Contact> getContactsPatient(int idPatient)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Contact>("SELECT * FROM CONTACT WHERE PatientId=@idPatient", new { idPatient });
                return sortie.ToList();
            }
        }

        /// <summary>
        /// Retourne un contact spécifique d'un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Contact getContactPatient(int idPatient, int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                var sortie = connection.Query<Contact>("SELECT * FROM CONTACT WHERE PatientId=@idPatient AND ContactId=@id", new { idPatient, id});
                return sortie.ToList()[0];
            }
        }

        /// <summary>
        /// Ajoute un nouveau contact à un patient
        /// </summary>
        /// <param name="idPatient"></param>
        /// <param name="C"></param>
        public static void nouveauContact(int idPatient, Contact contact)
        {
            string designation = contact.ContactDesignation;
            string telephone = contact.ContactTelephone;
            string mail = contact.ContactMail;

            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("INSERT INTO CONTACT (ContactDesignation, ContactTelephone, ContactMail, PatientId) VALUES (@designation, @telephone, @mail, @idPatient)", new { designation, telephone, mail, idPatient });
            }
        }

        /// <summary>
        /// Supprime un contact d'un patient
        /// </summary>
        /// <param name="id"></param>
        public static void deleteContact(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Query<Contact>("DELETE FROM CONTACT WHERE ContactId=@id", new { id });
            }
        }


        /// <summary>
        /// Mise à jour de la designation d'un contact
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nom"></param>
        public static void updateContactDesignation(int id, string designation)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE CONTACT set ContactDesignation=@designation WHERE ContactId=@id", new { designation, id });
            }
        }
        public static void updateContactTelephone(int id, string telephone)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE CONTACT set ContactTelephone=@telephone WHERE ContactId=@id", new { telephone, id });
            }
        }
        public static void updateContactMail(int id, string mail)
        {
            using (IDbConnection connection = new SQLiteConnection(DBAccess.connectionString()))
            {
                connection.Execute("UPDATE CONTACT set ContactMail=@mail WHERE ContactId=@id", new { mail, id });
            }
        }
    }
}
