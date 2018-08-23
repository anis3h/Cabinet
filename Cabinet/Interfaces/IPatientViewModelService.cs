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
        // Patient
        Task<PatientIndexViewModel> GetPatientItems();
        Task<PatientViewModel> GetPatient(int patientId);
        Task Add(PatientViewModel patientViewModel);
        Task Update(PatientViewModel patientViewModel);
        Task Delete(PatientViewModel patientViewModel);
        Task Delete(int key);

        // Patient With Family
        Task<PatientViewModel> GetPatientWithFamily(int patientId);
        Task UpdatePatientWithFamily(PatientViewModel patientViewModel);

        // PatientWith Information
        Task<PatientViewModel> GetPatientWithInformation(int patientId);
        // TO DO Gerry
        //Task UpdatePatientWithInformation(PatientViewModel patientViewModel);


    }
}
