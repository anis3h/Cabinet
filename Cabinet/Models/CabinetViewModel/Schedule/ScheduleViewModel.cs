using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Schedule {

    public class ScheduleViewModel {

        public IEnumerable<AppointmentViewModel> AppointmentViewModelList { get; set; }

        public DateTime Today { get; set; }

        public ScheduleViewModel() {

            Today = DateTime.Today;
        }

    }
}
