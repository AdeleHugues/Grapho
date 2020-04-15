using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;

namespace LaTeXExporter.Classes_d_exportation
{
    public class AmenagementExporter
    {
        public static string ExporterAmenagement(Amenagement A, int i)
        {
            string variables = "";

            variables += "\newcommand{\\graphoAmenagementType" + i + "}{" + A.AmenagementType + "}\n";

            return variables;
        }
    }
}
