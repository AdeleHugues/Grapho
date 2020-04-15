using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;

namespace LaTeXExporter.Classes_d_exportation
{
    public class EnseignantExporter
    {
        public static string ExporterEnseignant(Enseignant E)
        {
            string variables = "";

            variables += "\newcommand{\\graphoEnseignantNom}{" + E.EnseignantNom + "}\n";
            variables += "\newcommand{\\graphoEnseignantPrenom}{" + E.EnseignantPrenom + "}\n";

            return variables;
        }
    }
}
