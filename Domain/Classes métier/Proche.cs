using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Proche
    {
        public int ProcheId { get; set; }
        public string ProcheNom { get; set; }
        public string ProchePrenom { get; set; }
        public int ProcheAge { get; set; }
        public bool ProcheSexe { get; set; }
        public string ProchePlace { get; set; } //Place dans la fraterie
        public bool ProcheDisponibilite { get; set; } //Si le proche est disponible pour l'enfant ou non
        public bool ProcheLateralite { get; set; } //True=droitier
        public bool ProcheTrouble { get; set; } //Présente t-il des troubles de l'écriture

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public Proche() { }

        public Proche(string prenom, string nom, int age, bool sexe, string place, bool disponibilite, bool lateralite, bool trouble)
        {
            ProcheNom = nom;
            ProchePrenom = prenom;
            ProcheAge = age;
            ProcheSexe = sexe;
            ProchePlace = place;
            ProcheDisponibilite = disponibilite;
            ProcheLateralite = lateralite;
            ProcheTrouble = trouble;
        }
    }
}
