using Core.Entities.Schedule;
using Core.Interfaces;



namespace Infrastructure.Repositories {

    public class ScheduleRepository : EfRepository<Appointment>, IScheduleRepository {

        private readonly CabinetContext _dbContext;

        public ScheduleRepository(CabinetContext dbContext) : base(dbContext) {

            _dbContext = dbContext;
        }
    }
}
