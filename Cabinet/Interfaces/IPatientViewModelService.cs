using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Models;

namespace Cabinet.Interfaces
{
    public interface IPatientViewModelService
    {
        Task<PatientIndexViewModel> GetPatientItems(int pageIndex, int itemsPage);
    }
}
