using Core.Entities.Patients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPatientRepository : IAsyncRepository<Patient>
    {
        Task<Patient> GetPatientsTest();
        Task<List<PatientBirthStatistik>> GetGeburtsDatumCountByYears();
    }
}
