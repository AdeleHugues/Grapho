using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Anamnese
    {
        public int AnamneseId { get; set; }
        public string Interet { get; set; }
        public string Volonte { get; set; }
        public string Place { get; set; }
        public string Commentaire { get; set; }
        public string DesignationVisuelle { get; set; }
        public string Mimiques { get; set; }
        public string Discours { get; set; }
        public string Opposition { get; set; }
        public Dictionary<string, string> Exportation { get; set; }

        public Anamnese() {
            Exportation = new Dictionary<string, string> {
                { "Interet", "" },
                { "Volonte", "" },
                { "Place", "" },
                { "Commentaire", "" },
                { "DesignationVisuelle", "" },
                { "Mimiques", "" },
                { "Discours", "" },
                { "Opposition", "" },
            };
        }
        public Anamnese(string interet, string volonte, string place, string commentaire, string designationVisuelle, string mimiques, string discours, string opposition)
        {
            Interet = interet;
            Volonte = volonte;
            Place = place;
            Commentaire = commentaire;
            DesignationVisuelle = designationVisuelle;
            Mimiques = mimiques;
            Discours = discours;
            Opposition = opposition;
            Exportation = new Dictionary<string, string> {
                { "Interet", interet },
                { "Volonte", volonte },
                { "Place", place },
                { "Commentaire", commentaire },
                { "DesignationVisuelle", designationVisuelle },
                { "Mimiques", mimiques },
                { "Discours", discours },
                { "Opposition", opposition }
            };
        }
    }
}
