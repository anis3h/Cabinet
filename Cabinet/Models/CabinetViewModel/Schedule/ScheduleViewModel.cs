using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Schedule {

    public class ScheduleViewModel {

        public IEnumerable<AppointmentViewModel> AppointmentViewModelList { get; set; }

        public DateTime Today { get; set; }

        public ScheduleViewModel() {

            AppointmentViewModelList = GetScheduleData();
            Today = DateTime.Today;
        }

        public List<AppointmentViewModel> GetScheduleData() {

            List<AppointmentViewModel> appData = new List<AppointmentViewModel>();

            appData.Add(new AppointmentViewModel { Id = 1, Subject = "Explosion of Betelgeuse Star", StartTime = new DateTime(2018, 9, 1, 9, 30, 0), EndTime = new DateTime(2018, 9, 1, 12, 30, 0) });
            appData.Add(new AppointmentViewModel { Id = 2, Subject = "Thule Air Crash Report", StartTime = new DateTime(2018, 9, 12, 5, 0, 0), EndTime = new DateTime(2018, 9, 12, 10, 0, 0) });
            appData.Add(new AppointmentViewModel { Id = 3, Subject = "Blue Moon Eclipse", StartTime = new DateTime(2018, 9, 13, 9, 30, 0), EndTime = new DateTime(2018, 9, 13, 12, 0, 0) });
            appData.Add(new AppointmentViewModel { Id = 4, Subject = "Meteor Showers in 2018", StartTime = new DateTime(2018, 9, 14, 0, 0, 0), EndTime = new DateTime(2018, 9, 14, 0, 0, 0) });
            appData.Add(new AppointmentViewModel { Id = 5, Subject = "Milky Way as Melting pot", StartTime = new DateTime(2018, 9, 28, 12, 0, 0), EndTime = new DateTime(2018, 9, 28, 14, 0, 0) });

            return appData;
        }
    }
}
