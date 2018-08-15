using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public class PregnancyViewModel
    {
        public Age Age;
        // En bonne santé
        public bool Health { get; set; }
        // Maladie 
        public bool Information { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
