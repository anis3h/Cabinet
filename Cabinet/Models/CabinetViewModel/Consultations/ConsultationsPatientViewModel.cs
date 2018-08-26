using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Consultations
{
    public class ConsultationsPatientViewModel : PatientBaseViewModel
    {
        public List<ConsultationViewModel> Consultations { get; set; }
    }
}
