using AutoMapper;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Schedule;
using Core.Entities.Schedule;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cabinet.Services {

    public class ScheduleViewModelService : IScheduleViewModelService {


        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;


        public ScheduleViewModelService(IScheduleRepository scheduleRepository, IMapper mapper) {

            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<ScheduleViewModel> GetAll() {

            try {

                var appointments = await _scheduleRepository.ListAllAsync();
                var appointmentViewModelList = _mapper.Map<List<Appointment>, List<AppointmentViewModel>>(appointments);
                var scheduleViewModel = new ScheduleViewModel();
                scheduleViewModel.AppointmentViewModelList = appointmentViewModelList;

                return scheduleViewModel;
            }
            catch (Exception exp) {

                Console.WriteLine(exp);
                throw (exp);
            }
        }

        public Task<AppointmentViewModel> Get(int appointmentId) {
            throw new NotImplementedException();
        }


        public Task Add(AppointmentViewModel appointmentViewModel) {
            throw new NotImplementedException();
        }

        public Task Delete(AppointmentViewModel appointmentViewModel) {
            throw new NotImplementedException();
        }

        public Task Update(AppointmentViewModel appointmentViewModel) {
            throw new NotImplementedException();
        }
    }
}
