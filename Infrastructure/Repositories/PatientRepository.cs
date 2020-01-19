using Core.Entities.Patients;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PatientRepository : EfRepository<Patient>, IPatientRepository
    {
        private readonly CabinetContext _dbContext;
        public PatientRepository(CabinetContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PatientBirthStatistik>> GetGeburtsDatumCountByYears()
        {
            try
            {
                var grouped = await (_dbContext.Patients
                    .Where(p => p.DateOfBirth != null && p.DateOfBirth.Year > 2005)
                    .GroupBy(p => new { p.DateOfBirth.Year })
                    .Select(g => new PatientBirthStatistik
                    {
                        X = g.Key.Year,
                        Y = g.Count()
                    })).ToListAsync();

                ;
                return grouped;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }
    }
}
