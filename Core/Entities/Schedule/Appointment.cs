using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Entities.Schedule {


    public class Appointment : EntityBase {

        public Appointment() {

        }


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
