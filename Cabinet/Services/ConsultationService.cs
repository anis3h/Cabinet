using AutoMapper;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Consultations;
using Core.Entities.Consultations;
using Core.Interfaces;
using Core.Specifications.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Services
{
    public class ConsultationViewModelService : IConsultationViewModelService
    {
        // private readonly ILogger<CatalogService> _logger;
        private readonly IAsyncRepository<Consultation> _consultationRepository;
        private readonly IMapper _mapper;

        // ToDO IUnitRepository
        public ConsultationViewModelService(IAsyncRepository<Consultation> consultationRepository, IMapper mapper)
        {
            _consultationRepository = consultationRepository;
            _mapper = mapper;
        }

        public Task Add(ConsultationViewModel consultationViewModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ConsultationViewModel consultationViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultationViewModel> GetConsultation(int consultationId)
        {
            var consultation = await _consultationRepository.GetByIdAsync(consultationId);
            var consultationWithAllDataSpecification = new ConsultationWithAllDataSpecification(row => row.Id == consultationId);
            var consultationTest = await _consultationRepository.ListAsync(consultationWithAllDataSpecification);
            var consultationViewModel = _mapper.Map<Consultation, ConsultationViewModel>(consultation);
            return consultationViewModel;
        }

        public Task Update(ConsultationViewModel consultationViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
