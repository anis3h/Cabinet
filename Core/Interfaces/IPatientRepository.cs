using Core.Entities;
using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPatientRepository : IAsyncRepository<Patient>
    {
        Task<List<PatientBirthStatistik>> GetGeburtsDatumCountByYears();
    }
}
