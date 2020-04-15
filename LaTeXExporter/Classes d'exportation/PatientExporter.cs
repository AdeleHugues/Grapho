using Domain.Classes_métier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaTeXExporter.Classes_d_exportation
{
    public class PatientExporter
    {
        public static string ExporterPatient(Patient P)
        {
            string variables = "";

            variables += "\newcommand{\\graphoNom}{" + P.PatientNom + "}\n";
            variables += "\newcommand{\\graphoPrenom}{" + P.PatientPrenom + "}\n";

            if(P.PatientSexe)
            {
                variables += "\newcommand{\\graphoSexe}{garçon}\n";
                variables += "\newcommand{\\graphoPronom}{il}\n";
                variables += "\newcommand{\\graphoPronomMaj}{Il}\n";
            }
            else
            {
                variables += "\newcommand{\\graphoSexe}{fille}\n";
                variables += "\newcommand{\\graphoPronom}{elle}\n";
                variables += "\newcommand{\\graphoPronomMaj}{Elle}\n";
            }

            variables += "\newcommand{\\graphoDateNaissance}{" + P.PatientNaissance + "}\n";
            variables += "\newcommand{\\graphoCommentairePatient}{" + P.Commentaire + "}\n";
            variables += "\newcommand{\\graphoDateNaissance}{" + P.PatientNaissance + "}\n";

            return variables;
        }
    }
}
