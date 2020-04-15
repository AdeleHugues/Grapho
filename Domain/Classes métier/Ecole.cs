using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Ecole
    {
        public int EcoleId { get; set; }
        public string EcoleNom { get; set; }
        public string EcoleAdresse { get; set; }
        public string EcoleCP { get; set; }
        public string EcoleVille { get; set; }
        public string EcoleTelephone { get; set; }

        public Ecole(string nom, string adresse, string cp, string ville, string telephone)
        {
            EcoleNom = nom;
            EcoleAdresse = adresse;
            EcoleCP = cp;
            EcoleVille = ville;
            EcoleTelephone = telephone;
        }


    }
}
