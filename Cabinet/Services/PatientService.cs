using AutoMapper;
using Cabinet.Interfaces;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel;
using Core.Entities;
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
        private readonly IAsyncRepository<Patient> _itemRepository;
        private readonly IMapper _mapper;

        public PatientService(IAsyncRepository<Patient> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<PatientViewModel> GetPatient(int patientId)
        {
            var patient = await _itemRepository.GetByIdAsync(patientId);
            var patientViewModel = _mapper.Map<Patient, PatientViewModel>(patient);
            return patientViewModel;
        }

        public async Task<PatientIndexViewModel> GetPatientItems()
        {
            try
            {
                //_logger.LogInformation("GetCatalogItems called.");
                var patients = await _itemRepository.ListAllAsync();
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
            return await MapPatient(patientSpecification);
        }

        public async Task<PatientViewModel> GetPatientWithFamily(int patientId)
        {
            var patientSpecification = new PatientWithFamilySpecification(row => row.Id == patientId);
            return await MapPatient(patientSpecification);
        }

        public async Task<PatientViewModel> GetPatientWithInformation(int patientId)
        {
            var patientSpecification = new PatientWithInformationsSpecification(row => row.Id == patientId);
            return await MapPatient(patientSpecification);
        }

        private async Task<PatientViewModel> MapPatient(PatientBaseSpecification patientSpecification)
        {
            patientSpecification.AddIncludePatient();
            var patient = (await _itemRepository.ListAsync(patientSpecification)).FirstOrDefault();
            var patientViewModel = _mapper.Map<Patient, PatientViewModel>(patient);
            return patientViewModel;
        }

        public async Task Add(PatientViewModel patientViewModel)
        {
            try
            {
                var patient = _mapper.Map<PatientViewModel, Patient>(patientViewModel);
                var entity = await _itemRepository.AddAsync(patient);
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
                await _itemRepository.UpdateAsync(patient);
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
                await _itemRepository.DeleteAsync(patient);
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
                var patient = await _itemRepository.GetByIdAsync(key);
                await _itemRepository.DeleteAsync(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
      
    }
}
