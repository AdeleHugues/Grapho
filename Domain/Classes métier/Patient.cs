    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientNom { get; set; }
        public string PatientPrenom { get; set; }
        public bool PatientSexe { get; set; } //si vrai, garçon
        public DateTime PatientNaissance { get; set; }
        public string Commentaire { get; set; }
        public string PatientPhoto { get; set; }
        public string PatientPhotoEcriture { get; set; }
        public string PatientNomComplet { get { return PatientNom + " " + PatientPrenom; } }
        public int EnseignantId { get; set; }
        public virtual Enseignant PatientEnseignant { get; set; }

        public Patient() { }
        public Patient(string nom, string prenom, bool sexe, DateTime dateNaissance, string photo, string photoEcriture, string commentaire, Enseignant enseignant)
        {
            PatientNom = nom;
            PatientPrenom = prenom;
            PatientSexe = sexe;
            PatientNaissance = dateNaissance;
            Commentaire = commentaire;
            PatientPhoto = photo;
            PatientPhotoEcriture = photoEcriture;
            PatientEnseignant = enseignant;
        }

        public Patient(string nom, string prenom, bool sexe, DateTime dateNaissance, string photo, string photoEcriture, Enseignant enseignant) : this(nom, prenom, sexe, dateNaissance, photo, photoEcriture, "", enseignant) { }
    }
}
