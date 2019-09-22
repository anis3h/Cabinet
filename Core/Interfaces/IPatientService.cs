using Core.Entities;
using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPatientService
    {
        Task<Patient> GetPatient(int patientId);
        Task<List<Patient>> GetPatientItems();
        Task<Patient> GetPatientWithAllData(int patientId);
        Task Add(Patient patient);
        Task Update(Patient patient);
        Task Delete(Patient  patient );
        Task Delete(int key);

        // Patient With Family
        Task<Patient > GetPatientWithFamily(int patientId);
        Task UpdatePatientWithFamily(Patient newPatient);

        // Patient With Information
        Task<Patient > GetPatientWithInformation(int patientId);
        Task<Patient > GetPatientWithConsultations(int id);

        Task UpdatePatientWithInformation(Patient newPatient);
        Task<List<Patient>> GetPatientTests();
    }
}
