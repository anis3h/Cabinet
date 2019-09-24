using CommunCabinet.Dtos;
using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunCabinet.MapperServices.Interfaces
{
    public interface IPatientMapperService
    {
        Task<List<PatientDto>> GetPatientItems();
    }
}
