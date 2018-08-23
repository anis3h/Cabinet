using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public class SiblingViewModel
    {
        public int Id { get; set; }
        public Age Age;
        // En bonne santé
        public bool? Health { get; set; }
        // Maladie 
        public string Information { get; set; }

        public DateTime? DateOfBirth { get; set; }
      //  public PatientViewModel Patient { get; set; }
    }
}
