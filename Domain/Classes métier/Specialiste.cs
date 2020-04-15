using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Specialiste
    {
        public int SpecialisteId { get; set; }
        public string SpecialisteNom { get; set; }
        public string SpecialistePrenom { get; set; }
        public string SpecialisteSpecialite { get; set; }

        public virtual ICollection<Suivi> Suivis { get; set; }

        public Specialiste() { }
        public Specialiste(string prenom, string nom, string specialite)
        {
            SpecialistePrenom = prenom;
            SpecialisteNom = nom;
            SpecialisteSpecialite = specialite;
        }

    }
}
