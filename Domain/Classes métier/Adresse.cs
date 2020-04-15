using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        public string AdresseDesignation { get; set; }
        public string AdresseRue { get; set; }
        public string AdresseCP { get; set; }
        public string AdresseVille { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public Adresse() { }
        public Adresse(string designation, string rue, string cp, string ville)
        {
            AdresseDesignation = designation;
            AdresseRue = rue;
            AdresseCP = cp;
            AdresseVille = ville;
        }
    }
}
