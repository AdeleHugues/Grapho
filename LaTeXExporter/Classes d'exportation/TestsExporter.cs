using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;

namespace LaTeXExporter.Classes_d_exportation
{
    public class TestsExporter
    {
        public static string ExporterTests(Tests T)
        {
            string variables = "";

            variables += "\newcommand{\\graphoAcuite}{" + T.Acuite + "}\n";
            variables += "\newcommand{\\graphoOrthoptie}{" + T.Orthoptie + "}\n";
            variables += "\newcommand{\\graphoReflexe}{" + T.Reflexe + "}\n";
            variables += "\newcommand{\\graphoLateralite}{" + T.Lateralite + "}\n";
            variables += "\newcommand{\\graphoPattes}{" + T.Pattes + "}\n";
            variables += "\newcommand{\\graphoReflexeAsymetriqueCou}{" + T.ReflexeAsymetriqueCou + "}\n";
            variables += "\newcommand{\\graphoReflexeSymetriqueCou}{" + T.ReflexeSymetriqueCou + "}\n";
            variables += "\newcommand{\\graphoReflexePrehension}{" + T.ReflexePrehension + "}\n";
            variables += "\newcommand{\\graphoReflexeSuccion}{" + T.ReflexeSuccion + "}\n";
            variables += "\newcommand{\\graphoMoro}{" + T.ReflexeMoro + "}\n";
            variables += "\newcommand{\\graphoReflexeRedressement}{" + T.ReflexeRedressement + "}\n";
            variables += "\newcommand{\\graphoReflexeFouissement}{" + T.ReflexeFouissement + "}\n";
            variables += "\newcommand{\\graphoReflexePoints}{" + T.ReflexePoints + "}\n";
            variables += "\newcommand{\\graphoReflexeSurvie}{" + T.ReflexeSurvie + "}\n";
            variables += "\newcommand{\\graphoReflexeNage}{" + T.ReflexeNage + "}\n";
            variables += "\newcommand{\\graphoReflexeGlabellaire}{" + T.ReflexeGlabellaire + "}\n";

            return variables;
        }
    }
}
