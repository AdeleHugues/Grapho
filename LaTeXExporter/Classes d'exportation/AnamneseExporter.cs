using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;    

namespace LaTeXExporter.Classes_d_exportation
{
    public class AnamneseExporter
    {
        public static string ExporterAnamnese(Anamnese A)
        {
            string variables = "";

            variables += "\newcommand{\\graphoInteret}{" + A.Interet + "}\n";
            variables += "\newcommand{\\graphoVolonte}{" + A.Volonte + "}\n";
            variables += "\newcommand{\\graphoPlace}{" + A.Place + "}\n";
            variables += "\newcommand{\\graphoCommentaireAnamnese}{" + A.Commentaire + "}\n";
            variables += "\newcommand{\\graphoDesignationVisuelle}{" + A.DesignationVisuelle + "}\n";
            variables += "\newcommand{\\graphoMimiques}{" + A.Mimiques + "}\n";
            variables += "\newcommand{\\graphoDiscours}{" + A.Discours + "}\n";
            variables += "\newcommand{\\graphoOpposition}{" + A.Opposition + "}\n";

            return variables;
        }
    }
}
