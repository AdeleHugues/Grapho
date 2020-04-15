using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;

namespace LaTeXExporter.Classes_d_exportation
{
    public class ProcheExporter
    {

        public static string ExporterProche(Proche P, int i)
        {
            string variables = "";

            variables += "\newcommand{\\graphoProcheNom" + i  + "}{" + P.ProcheNom + "}\n";
            variables += "\newcommand{\\graphoProchePrenom" + i + "}{" + P.ProchePrenom + "}\n";
            variables += "\newcommand{\\graphoProcheAge" + i + "}{" + P.ProcheAge + "}\n";

            if (P.ProcheSexe)
                variables += "\newcommand{\\graphoProcheSexe" + i + "}{" + "garçon" + "}\n";
            else
                variables += "\newcommand{\\graphoProcheSexe" + i + "}{" + "fille" + "}\n";


            variables += "\newcommand{\\graphoProchePlace" + i + "}{" + P.ProchePlace + "}\n";
            variables += "\newcommand{\\graphoProcheDisponibilite" + i + "}{" + P.ProcheDisponibilite + "}\n";
            variables += "\newcommand{\\graphoProcheLateralite" + i + "}{" + P.ProcheLateralite + "}\n";
            variables += "\newcommand{\\graphoProcheTrouble" + i + "}{" + P.ProcheTrouble + "}\n";

            return variables;
        }
    }
}
