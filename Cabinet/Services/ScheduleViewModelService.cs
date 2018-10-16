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
            catch (Exception ex) {

                Console.WriteLine(ex);
                throw (ex);
            }
        }

        public Task<AppointmentViewModel> Get(int appointmentId) {
            throw new NotImplementedException();
        }


        public async Task Add(AppointmentViewModel appointmentViewModel) {

            try {
                var appointment = _mapper.Map<AppointmentViewModel, Appointment>(appointmentViewModel);
                await _scheduleRepository.AddAsync(appointment);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public Task Delete(AppointmentViewModel appointmentViewModel) {
            throw new NotImplementedException();
        }

        public Task Update(AppointmentViewModel appointmentViewModel) {
            throw new NotImplementedException();
        }
    }
}
