using CommunCabinet.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunCabinet.MapperServices.Interfaces
{
    public interface IPatientMapperService
    {
        Task<PatientDto> GetPatient(int id);
        Task<List<PatientDto>> GetPatientItems();
        Task Add(PatientDto patientViewModel);
        Task Update(PatientDto patientViewModel);
        Task Delete(PatientDto patientViewModel);
        Task Delete(int key);
        Task<FamilyPatientDto> GetPatientWithFamily(int patientId);
        Task<FamilyPatientDto> UpdatePatientWithFamily(FamilyPatientDto patient);
        Task<PatientInformationDto> GetPatientWithInformation(int patientId);
        Task UpdatePatientWithInformation(PatientInformationDto patient);
    }
}
