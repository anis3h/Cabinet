using AutoMapper;
using Cabinet.Interfaces;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel.Family;
using Cabinet.Models.CabinetViewModel.Informations;
using Cabinet.Models.CabinetViewModel.Patient;
using Core.Entities;
using Core.Entities.Family;
using Core.Interfaces;
using Core.Services;
using Core.Specifications;
using Core.Specifications.PatientSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Services
{
    public class PatientService : IPatientViewModelService
    {
       // private readonly ILogger<CatalogService> _logger;
        private readonly IAsyncRepository<Patient> _patientRepository;
        private readonly IAsyncRepository<PatientParent> _patientParentRepository;
        private readonly IMapper _mapper;

        // ToDO IUnitRepository
        public PatientService(IAsyncRepository<Patient> patientRepository, IAsyncRepository<PatientParent> patientParentRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _patientParentRepository = patientParentRepository;
            _mapper = mapper;
        }

        public async Task<PatientViewModel> GetPatient(int patientId)
        {
            var patient = await _patientRepository.GetByIdAsync(patientId);
            var patientViewModel = _mapper.Map<Patient, PatientViewModel>(patient);
            return patientViewModel;
        }

        public async Task<PatientIndexViewModel> GetPatientItems()
        {
            try
            {
                //_logger.LogInformation("GetCatalogItems called.");
                var patients = await _patientRepository.ListAllAsync();
                var patientViewModelList = _mapper.Map<List<Patient>, List<PatientViewModel>>(patients);
                PatientIndexViewModel patientIndexViewModel = new PatientIndexViewModel();
                patientIndexViewModel.PatientItems = patientViewModelList;
                return patientIndexViewModel;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw (exp);
            }
        }

        public async Task<PatientViewModel> GetPatientWithAllData(int patientId)
        {
            var patientSpecification = new PatientWithAllDataSpecification(row => row.Id == patientId);
            return await MapPatient<PatientViewModel>(patientSpecification);
        }

        public async Task<FamilyPatientViewModel> GetPatientWithFamily(int patientId)
        {
            var patientSpecification = new PatientWithFamilySpecification(row => row.Id == patientId);
            return (await MapPatient<FamilyPatientViewModel>(patientSpecification)) ;
        }
      
        public async Task<InformationPatientViewModel> GetPatientWithInformation(int patientId)
        {
            var patientSpecification = new PatientWithInformationsSpecification(row => row.Id == patientId);
            return await MapPatient<InformationPatientViewModel>(patientSpecification);
        }

        public async Task UpdatePatientWithInformation(InformationPatientViewModel informationPatientViewModel) {

            try {

                //var patient = _mapper.Map<InformationPatientViewModel, Patient>(informationPatientViewModel);
                var patientSpecification = new PatientWithInformationsSpecification(row => row.Id == informationPatientViewModel.Id);
                var patient = await GetPatientWithPatientSpecification(patientSpecification);
                _mapper.Map(informationPatientViewModel, patient);


                await _patientRepository.UpdateAsync(patient);
            }
            catch (Exception exp) {
                Console.WriteLine(exp);
            }
        }

        public async Task Add(PatientViewModel patientViewModel)
        {
            try
            {
                var patient = _mapper.Map<PatientViewModel, Patient>(patientViewModel);
                var entity = await _patientRepository.AddAsync(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task UpdatePatientWithFamily(FamilyPatientViewModel patientViewModel)
        {
            try
            {
                var patientSpecification = new PatientWithFamilySpecification(row => row.Id == patientViewModel.Id);
                var patient = await GetPatientWithPatientSpecification(patientSpecification);
                _mapper.Map(patientViewModel, patient);
                // Add new Parents
                if (patient.PatientParents == null || patient.PatientParents.Count == 0)
                {
                    patient.AddPatientParents();
                }
                await _patientRepository.UpdateAsync(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task Delete(PatientViewModel patientViewModel)
        {
            try
            {
                var patient = _mapper.Map<PatientViewModel, Patient>(patientViewModel);
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

        public async Task Update(PatientViewModel patientViewModel)
        {
            try
            {
                var patient = _mapper.Map<PatientViewModel, Patient>(patientViewModel);
                await _patientRepository.UpdateAsync(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        private async Task<TViewModel> MapPatient<TViewModel>(PatientBaseSpecification patientSpecification)
        {
            var patient = await GetPatientWithPatientSpecification(patientSpecification);
            var patientViewModel = _mapper.Map<Patient, TViewModel>(patient);
            return patientViewModel;
        }

        private async Task<Patient> GetPatientWithPatientSpecification(PatientBaseSpecification patientSpecification)
        {
            patientSpecification.AddIncludePatient();
            return (await _patientRepository.ListAsync(patientSpecification)).FirstOrDefault();
        }

 
    }
}
