using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel;

namespace Cabinet.Interfaces
{
    public interface IPatientViewModelService
    {
        Task<PatientIndexViewModel> GetPatientItems();

        Task<PatientViewModel> GetPatient(int patientId);
     }
}
