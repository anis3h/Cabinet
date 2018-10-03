using Core.Entities.Schedule;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Interfaces {

    public interface IScheduleRepository : IAsyncRepository<Appointment>  {

    }
}
