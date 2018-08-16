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
        Task<PatientViewModel> GetPatientWithFamily(int patientId);
        Task<PatientViewModel> GetPatientWithInformation(int patientId);
        Task Add(PatientViewModel patientViewModel);
        Task Update(PatientViewModel patientViewModel);
        Task Delete(PatientViewModel patientViewModel);
        Task Delete(int key);
    }
}
