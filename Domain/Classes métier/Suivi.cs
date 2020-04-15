using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Suivi
    {
        public int PatientId { get; set; }
        public int SpecialisteId { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public bool Adressage { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Specialiste Specialiste { get; set; }

        public Suivi() { }

        public Suivi(Patient patient, Specialiste specialiste, DateTime debut, DateTime fin, bool adressage)
        {
            Patient = patient;
            Specialiste = specialiste;
            Debut = debut;
            Fin = fin;
            Adressage = adressage;
        }

    }
}
