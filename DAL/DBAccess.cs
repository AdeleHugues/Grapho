using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBAccess
    {
        /// <summary>
        /// Retourne la châine de connexion à la base de données
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string connectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
