using Cabinet.Models.CabinetViewModel.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Interfaces {


    public interface IScheduleViewModelService {

        Task<ScheduleViewModel> GetAll();

        Task<AppointmentViewModel> Get(int appointmentId);

        Task Add(AppointmentViewModel appointmentViewModel);

        Task Update(AppointmentViewModel appointmentViewModel);

        Task Delete(int id);
    }
}
