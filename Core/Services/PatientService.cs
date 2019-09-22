using Core.Entities;
using Core.Entities.Family;
using Core.Entities.Patients;
using Core.Interfaces;
using Core.Specifications.PatientSpecifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;

namespace Core.Services
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IAsyncRepository<PatientParent> _patientParentRepository;
        private readonly IMapper _mapper;
        // ToDO IUnitRepository
        public PatientService(IPatientRepository patientRepository, IAsyncRepository<PatientParent> patientParentRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _patientParentRepository = patientParentRepository;
            _mapper = mapper;
        }

        public async Task<Patient> GetPatient(int patientId)
        {
            var patient = await _patientRepository.GetByIdAsync(patientId);
            return patient;
        }

        public async Task<List<Patient>> GetPatientItems()
        {
            try
            {
                //_logger.LogInformation("GetCatalogItems called.");
                return await _patientRepository.ListAllAsync();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw (exp);
            }
        }

        public async Task<Patient> GetPatientWithAllData(int patientId)
        {
            var patientSpecification = new PatientWithAllDataSpecification(row => row.Id == patientId);
            return await GetPatientWithPatientSpecification(patientSpecification);
        }

        public async Task<Patient> GetPatientWithFamily(int patientId)
        {
            var patientSpecification = new PatientWithFamilySpecification(row => row.Id == patientId);
            return await GetPatientWithPatientSpecification(patientSpecification);
        }

        public async Task<Patient> GetPatientWithInformation(int patientId)
        {
            var patientSpecification = new PatientWithInformationsSpecification(row => row.Id == patientId);
            return await GetPatientWithPatientSpecification(patientSpecification);
        }

        public async Task UpdatePatientWithInformation(Patient patientNew)
        {
            try
            {
                //var patient = _mapper.Map<InformationPatientViewModel, Patient>(informationPatientViewModel);
                var patientSpecification = new PatientWithInformationsSpecification(row => row.Id == patientNew.Id);
                var patientOld = await GetPatientWithPatientSpecification(patientSpecification);
                _mapper.Map(patientNew, patientOld);

                await _patientRepository.UpdateAsync(patientOld);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task Add(Patient newPatient)
        {
            try
            {
                // local time zone offset as TimeSpan object                
                // add the offsetTime to the datetime recieved as UTC
                newPatient.DateOfBirth = ChangeUtcDate(newPatient.DateOfBirth);
                var entity = await _patientRepository.AddAsync(newPatient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task UpdatePatientWithFamily(Patient newPatient)
        {
            try
            {
                var patientSpecification = new PatientWithFamilySpecification(row => row.Id == newPatient.Id);
                var oldPatient = await GetPatientWithPatientSpecification(patientSpecification);
                _mapper.Map(newPatient, oldPatient);
                // Add new Parents
                if (oldPatient.PatientParents == null || oldPatient.PatientParents.Count == 0)
                {
                    oldPatient.AddPatientParents();
                }
                oldPatient.UpdatePatientSiblings();
                await _patientRepository.UpdateAsync(oldPatient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task Delete(Patient patient)
        {
            try
            {
                await _patientRepository.DeleteAsync(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task Delete(int key)
        {
            try
            {
                // I get the patient beacause Value.Value = null. This a Syncfusion Bug!
                var patient = await _patientRepository.GetByIdAsync(key);
                await _patientRepository.DeleteAsync(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task Update(Patient patient)
        {
            try
            {
                patient.DateOfBirth = ChangeUtcDate(patient.DateOfBirth);          
                await _patientRepository.UpdateAsync(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task<Patient> GetPatientWithConsultations(int patientId)
        {
            var patientSpecification = new PatientWithConsultationsSpecification(row => row.Id == patientId);
            return await GetPatientWithPatientSpecification(patientSpecification);
        }

        //private async Task<TViewModel> MapPatient<TViewModel>(PatientBaseSpecification patientSpecification)
        //{
        //    var patient = await GetPatientWithPatientSpecification(patientSpecification);
        //    var patientViewModel = _mapper.Map<Patient, TViewModel>(patient);
        //    return patientViewModel;
        //}

        private async Task<Patient> GetPatientWithPatientSpecification(PatientBaseSpecification patientSpecification)
        {
            patientSpecification.AddIncludePatient();
            return (await _patientRepository.ListAsync(patientSpecification)).FirstOrDefault();
        }

        private DateTime ChangeUtcDate(DateTime dateTime)
        {
            var offsetTime = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Ticks;

            // convert time zone offset to minutes
            var localtime_minutes = TimeSpan.FromTicks(offsetTime).TotalMinutes;
            return dateTime.AddMinutes(localtime_minutes);
        }

        public async Task<List<Patient>> GetPatientTests()
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
