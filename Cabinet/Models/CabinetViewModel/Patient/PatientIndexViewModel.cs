using Cabinet.Models.CabinetViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Patient
{
    public class PatientIndexViewModel
    {
        public IEnumerable<PatientViewModel> PatientItems { get; set; }
    }
}
