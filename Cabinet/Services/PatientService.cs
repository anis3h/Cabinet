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

        public async Task<PatientIndexViewModel> GetPatientItems()
        {
            //_logger.LogInformation("GetCatalogItems called.");
            var patientSpecification = new PatientSpecification();
            var root = await _itemRepository.ListAsync(patientSpecification);
            var itemsOnPageViewModel = _mapper.Map<List<Patient>, List<PatientViewModel>>(root);
            PatientIndexViewModel vm = new PatientIndexViewModel();
            vm.PatientItems = itemsOnPageViewModel;
            return vm;
        }
    }
}
