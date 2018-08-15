using AutoMapper;
using Cabinet.Interfaces;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Core.Specifications;
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
                var patientSpecification = new PatientSpecification();
                var patients = await _itemRepository.ListAsync(patientSpecification);
                var patientViewModelList = _mapper.Map<List<Patient>, List<PatientViewModel>>(patients);
                PatientIndexViewModel patientIndexViewModel = new PatientIndexViewModel();
                patientIndexViewModel.PatientItems = patientViewModelList;
                return patientIndexViewModel;
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
                return null;
            }
        }
    }
}
