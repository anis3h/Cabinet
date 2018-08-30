using Cabinet.Models.CabinetViewModel.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Interfaces
{
    public interface IConsultationViewModelService
    {
        Task<ConsultationViewModel> GetConsultation(int consultationId);
        Task Add(ConsultationViewModel consultationViewModel);
        Task Update(ConsultationViewModel consultationViewModel);
        Task Delete(ConsultationViewModel consultationViewModel);
    }
}
