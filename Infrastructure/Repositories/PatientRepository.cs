using Core.Entities;
using Core.Entities.Patients;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PatientRepository : EfRepository<Patient>, IPatientRepository
    {
        private CabinetContext _dbContext;
        public PatientRepository(CabinetContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PatientBirthStatistik>> GetGeburtsDatumCountByYears()
        {
            try
            {
                var grouped = _dbContext.Patients
                                         .Where(p => p.DateOfBirth != null && p.DateOfBirth.Year > 2005)
                                        .GroupBy(p => new { p.DateOfBirth.Year })
                                        .Select(g => new PatientBirthStatistik
                                        {
                                            X = g.Key.Year,
                                            Y = g.Count()
                                        })
                                       
                                         ;
                return grouped.ToList();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }
    }
}
