using Core.Entities.Schedule;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure.Repositories {

    public class ScheduleRepository : EfRepository<Appointment>, IScheduleRepository {

        private readonly CabinetContext _dbContext;

        public ScheduleRepository(CabinetContext dbContext) : base(dbContext) {

            _dbContext = dbContext;
        }
    }
}
