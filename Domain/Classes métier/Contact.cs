using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactDesignation { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactMail { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public Contact() { }

        public Contact(string designation, string telephone, string mail, Patient patient)
        {
            ContactDesignation = designation;
            ContactTelephone = telephone;
            ContactMail = mail;
            Patient = patient;
        }
    }
}
