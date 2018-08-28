using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Patient
{
    public class PatientViewModel : PatientBaseViewModel
    {
        public int FileNumber { get; set; }
        public string Adresse { get; set; }
    }
}
