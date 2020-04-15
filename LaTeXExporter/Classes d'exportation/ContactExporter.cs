using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Classes_métier;

namespace LaTeXExporter.Classes_d_exportation
{
    public class ContactExporter
    {
        public static string ExporterContact(Contact C, int i)
        {
            string variables = "";

            variables += "\newcommand{\\graphoContactDesignation" + i + "}{" + C.ContactDesignation + "}\n";
            variables += "\newcommand{\\graphoContactTelephone" + i + "}{" + C.ContactTelephone + "}\n";
            variables += "\newcommand{\\graphoContactMail" + i + "}{" + C.ContactMail + "}\n";

            return variables;
        }
    }
}
