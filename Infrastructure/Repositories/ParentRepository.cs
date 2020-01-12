using Core.Entities.Family;
using Core.Interfaces;

namespace Infrastructure.Repositories
{
    public class ParentRepository : EfRepository<Parent>, IParentRepository
    {
        private readonly CabinetContext _dbContext;
        public ParentRepository(CabinetContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
