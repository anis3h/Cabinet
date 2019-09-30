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

        public async Task Add(PatientDto patientDto)
        {
            try
            {
                // local time zone offset as TimeSpan object                
                // add the offsetTime to the datetime recieved as UTC
                var patient = _mapper.Map<PatientDto, Patient>(patientDto);
                await _patientService.Add(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task Delete(int key)
        {
            // I get the patient beacause Value.Value = null. This a Syncfusion Bug!
            await _patientService.Delete(key);
        }

        public async Task Delete(PatientDto patientDto)
        {
            try
            {
                var patient = _mapper.Map<PatientDto, Patient>(patientDto);
                await _patientService.Delete(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public async Task<List<PatientDto>> GetPatientItems()
        {
            var patient = await _patientService.GetPatientItems();
            return _mapper.Map<List<Patient>, List<PatientDto>>(patient);
        }

        public async Task Update(PatientDto patientDto)
        {
            try
            {
                var patient = _mapper.Map<PatientDto, Patient>(patientDto);
                await _patientService.Update(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
}
