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

        public async Task<Patient> GetPatientsTest()
        {
            //_dbContext.Pregnanicies.AddAsync(new Pregnancy { TypPosition = TypPosition.Siège, Month = 1 })  ;

            var preg = await _dbContext.Pregnanicies.Where(row => row.Id == 2).AsNoTracking().SingleOrDefaultAsync();
            preg.Month = 5;
            var test = _dbContext.Entry(preg).State;

            var patient = await _dbContext.Patients.Include(row => row.Pregnancy).Where(row => row.Id == 6).SingleOrDefaultAsync();
            patient.Pregnancy = preg;
            var test2 = _dbContext.Entry(preg).State;
            await _dbContext.SaveChangesAsync();
            return patient;
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
