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
        //IAsyncRepository<Patient> _patientRepository;
        public PatientService()
        {
            //_patientRepository = patientRepository;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
             //await _patientRepository.AddAsync(patient);
        }

        public async Task<List<Patient>> GetPatientItems()
        {
            try
            {
                //_logger.LogInformation("GetCatalogItems called.");
                //var patients = await _patientRepository.ListAllAsync();
                var patient = new Patient()
                {
                    Name = "Herpich",
                    FirstName = "Walter",
                    Tel = "123456789",
                    Adresse = "Pharmatechnik"
                };

                var patients = new List<Patient>();
                patients.Add(patient);

                return patients;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw (exp);
            }
        }
    }
}
