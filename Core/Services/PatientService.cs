using Core.Entities;
using Core.Entities.Patients;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PatientService : IPatientService
    {
        IAsyncRepository<Patient> _patientRepository;
        public PatientService(IAsyncRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
             await _patientRepository.AddAsync(patient);
        }
    }
}
