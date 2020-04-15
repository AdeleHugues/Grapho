using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Enseignant
    {
        public int EnseignantId { get; set; }
        public string EnseignantPrenom { get; set; }
        public string EnseignantNom { get; set; }

        public int EcoleId { get; set; }
        public virtual Ecole EnseignantEcole { get; set; }
        public Enseignant() { }

        public Enseignant(string prenom, string nom)
        {
            EnseignantPrenom = prenom;
            EnseignantNom = nom;
        }
    }
}
