using AutoMapper;
using Cabinet.Interfaces;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
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

        public async Task<PatientIndexViewModel> GetPatientItems(int pageIndex, int itemsPage)
        {
            //_logger.LogInformation("GetCatalogItems called.");

          //  var filterSpecification = new CatalogFilterSpecification(brandId, typeId);
            var root = await _itemRepository.ListAllAsync();
           // IEnumerable<Patient> patients = await _itemRepository.ListAllAsync();
            var totalItems = root.Count();

            var itemsOnPage = root
                .Skip(itemsPage * pageIndex)
                .Take(itemsPage)
                .ToList();

            var itemsOnPageViewModel = _mapper.Map<List<Patient>, List<PatientViewModel>>(itemsOnPage);
        
            var paginationInfo = new PaginationInfoViewModel()
            {
                ActualPage = pageIndex,
                ItemsPerPage = itemsOnPage.Count,
                TotalItems = totalItems,
                TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
            };

            PatientIndexViewModel vm = new PatientIndexViewModel();
            vm.PatientItems = itemsOnPageViewModel;
            vm.PaginationInfo = paginationInfo;

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return vm;
        }
    }
}
