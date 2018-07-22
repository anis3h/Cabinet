using Cabinet.Interfaces;
using Cabinet.Models;
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
     //   private readonly IAsyncRepository<CatalogBrand> _brandRepository;
      //  private readonly IAsyncRepository<CatalogType> _typeRepository;
      // private readonly IUriComposer _uriComposer;


        public PatientService(IAsyncRepository<Patient> itemRepository)
        {
            _itemRepository = itemRepository;
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

            //itemsOnPage.ForEach(x =>
            //{
            //    x.PictureUri = _uriComposer.ComposePicUri(x.PictureUri);
            //});

            var vm = new PatientIndexViewModel()
            {
                PatientItems = itemsOnPage.Select(i => new PatientViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                }),
            
              
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return vm;
        }
    }
}
