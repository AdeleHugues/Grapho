using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes_métier
{
    public class Amenagement
    {
        public int AmenagementId { get; set; }
        public string AmenagementType { get; set; }
        public int PatientId { get; set; }

    }
}
