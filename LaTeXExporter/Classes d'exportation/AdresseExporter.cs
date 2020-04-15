using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;


namespace LaTeXExporter.Classes_d_exportation
{
    public class AdresseExporter
    { 
        /// <summary>
        /// Exporte l'adresse n°i, on sait que potentiellement un patient a plusieurs adresses
        /// Il faut pouvoir les distinguer
        /// </summary>
        /// <param name="A"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string ExporterAdresse(Adresse A, int i)
        {
            string variables = "";

            variables += "\newcommand{\\graphoAdresseDesignation" + i + "}{" + A.AdresseDesignation + "}\n";
            variables += "\newcommand{\\graphoAdresseRue" + i + "}{" + A.AdresseRue + "}\n";
            variables += "\newcommand{\\graphoAdresseCP" + i + "}{" + A.AdresseCP + "}\n";
            variables += "\newcommand{\\graphoAdresseVille" + i + "}{" + A.AdresseVille + "}\n";

            return variables;
        }
    }
}
