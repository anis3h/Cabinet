using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel.Consultations;
using Cabinet.Models.CabinetViewModel.Family;
using Cabinet.Models.CabinetViewModel.Informations;
using Cabinet.Models.CabinetViewModel.Patient;

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
        Task<FamilyPatientViewModel> GetPatientWithFamily(int patientId);
        Task UpdatePatientWithFamily(FamilyPatientViewModel patientViewModel);

        // Patient With Information
        Task<InformationPatientViewModel> GetPatientWithInformation(int patientId);
        Task<ConsultationsPatientViewModel> GetPatientWithConsultations(int id);

        // TO DO Gerry
        Task UpdatePatientWithInformation(InformationPatientViewModel informationPatientViewModel);


    }
}
