using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;

namespace LaTeXExporter.Classes_d_exportation
{
    public class EcoleExporter
    {
        public static string ExporterEcole(Ecole E)
        {
            string variables = "";

            variables += "\newcommand{\\graphoEcoleNom}{" + E.EcoleNom + "}\n";
            variables += "\newcommand{\\graphoEcoleAdresse}{" + E.EcoleAdresse + "}\n";
            variables += "\newcommand{\\graphoEcoleCP}{" + E.EcoleCP + "}\n";
            variables += "\newcommand{\\graphoEcoleVille}{" + E.EcoleVille + "}\n";
            variables += "\newcommand{\\graphoEcoleTelephone}{" + E.EcoleTelephone + "}\n";

            return variables;
        }

    }
}
