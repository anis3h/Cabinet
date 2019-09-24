using AutoMapper;
using CommunCabinet.Dtos;
using CommunCabinet.MapperServices.Interfaces;
using Core.Entities.Patients;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunCabinet.MapperServices
{
    public class PatientMapperService : IPatientMapperService
    {
        public IMapper _mapper;
        IPatientService _patientService;
        public PatientMapperService(IMapper mapper, IPatientService patientService)
        {
            _mapper = mapper;
            _patientService = patientService;
        }

        public async Task<List<PatientDto>> GetPatientItems()
        {
            var patient = await _patientService.GetPatientItems();
            return _mapper.Map<List<Patient>, List<PatientDto>>(patient);
        }
    }
}
