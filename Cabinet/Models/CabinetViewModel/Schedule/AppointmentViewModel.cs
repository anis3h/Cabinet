using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cabinet.Models.CabinetViewModel.Schedule {

    public class AppointmentViewModel {

        public AppointmentViewModel() {

        }

        public int? Id { get; set; }

        public string Subject { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsAllDay { get; set; }

        public int RecurrenceID { get; set; }

        public string RecurrenceRule { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        //public string StartTimezone { get; set; }

        //public string EndTimezone { get; set; }
    }
}
