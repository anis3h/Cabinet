using AutoMapper;
using Cabinet.Interfaces;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel.Consultations;
using Cabinet.Models.CabinetViewModel.Family;
using Cabinet.Models.CabinetViewModel.Informations;
using Cabinet.Models.CabinetViewModel.Patient;
using Core.Entities;
using Core.Entities.Family;
using Core.Entities.Patients;
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
    public class PatientViewModelService : IPatientViewModelService
    {
       // private readonly ILogger<CatalogService> _logger;
        //private readonly IPatientRepository _patientRepository;
        //private readonly IAsyncRepository<PatientParent> _patientParentRepository;
        private readonly IMapper _mapper;
        IPatientService _patientService;

        // ToDO IUnitRepository
        public PatientViewModelService(IPatientService patientService, IMapper mapper, IPatientService patientService2)
        {
            _mapper = mapper;
            _patientService = patientService2;
        }

        public async Task<PatientViewModel> GetPatient(int patientId)
        {
            var patient = await _patientService.GetPatient(patientId);
            var patientViewModel = _mapper.Map<Patient, PatientViewModel>(patient);
            return patientViewModel;
        }

        public async Task<PatientIndexViewModel> GetPatientItems()
        {
            try
            {
                //_logger.LogInformation("GetCatalogItems called.");
                var patients = await _patientService.GetPatientItems();
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
            var patient = await _patientService.GetPatientWithAllData(patientId);
            return _mapper.Map<Patient, PatientViewModel>(patient);
        }

        public async Task<FamilyPatientViewModel> GetPatientWithFamily(int patientId)
        {
            var patient = await _patientService.GetPatientWithFamily(patientId);
            return _mapper.Map<Patient, FamilyPatientViewModel>(patient);
        }
      
        public async Task<InformationPatientViewModel> GetPatientWithInformation(int patientId)
        {
            var patient = await _patientService.GetPatientWithInformation(patientId);
            return _mapper.Map<Patient, InformationPatientViewModel>(patient);
        }

        public async Task UpdatePatientWithInformation(InformationPatientViewModel informationPatientViewModel) {

            try {
                var patient = new Patient();
                _mapper.Map(informationPatientViewModel, patient);
                await _patientService.UpdatePatientWithInformation(patient);
            }
            catch (Exception exp) {
                Console.WriteLine(exp);
            }
        }

        public async Task Add(PatientViewModel patientViewModel)
        {
            try
            {
                // local time zone offset as TimeSpan object                
                // add the offsetTime to the datetime recieved as UTC
                var patient = _mapper.Map<PatientViewModel, Patient>(patientViewModel);
                await _patientService.Add(patient);
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
                var patient = new Patient();
                _mapper.Map(patientViewModel, patient);
                await _patientService.UpdatePatientWithFamily(patient);
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
                await _patientService.Delete(patient);
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
                 await _patientService.Delete(key);
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
                await _patientService.Update(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task<ConsultationsPatientViewModel> GetPatientWithConsultations(int patientId)
        {
            var patient = await _patientService.GetPatientWithConsultations(patientId);
            return _mapper.Map<Patient, ConsultationsPatientViewModel>(patient);
        }
    }
}
