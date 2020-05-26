using AutoMapper;
using CommunCabinet.Dtos;
using CommunCabinet.MapperServices.Interfaces;
using Core.Entities.Patients;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CommunCabinet.MapperServices
{
    public class PatientMapperService : IPatientMapperService
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public PatientMapperService(IMapper mapper, IPatientService patientService)
        {
            _mapper = mapper;
            _patientService = patientService;
        }

        public async Task Add(PatientDto patientDto)
        {
            try
            {
                if (patientDto.FirstName == "Test")
                    throw new Exception("Name can not be Test");
                // local time zone offset as TimeSpan object                
                // add the offsetTime to the datetime recieved as UTC
                var patient = _mapper.Map<PatientDto, Patient>(patientDto);
                await _patientService.Add(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw;
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

        public async Task<PatientDto> GetPatient(int id)
        {
            var patient = await _patientService.GetPatient(id);
            return _mapper.Map<Patient, PatientDto>(patient);
        }

        public async Task<List<PatientDto>> GetPatientItems()
        {
            var patient = await _patientService.GetPatientItems();
            return _mapper.Map<List<Patient>, List<PatientDto>>(patient);
        }

        public async Task<FamilyPatientDto> GetPatientWithFamily(int patientId)
        {
            try
            {
                var patient = await _patientService.GetPatientWithFamily(patientId);
                var test = _mapper.Map<Patient, FamilyPatientDto>(patient);
                return test;
            }
            catch (Exception)
            {
                throw;
            }

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

        public async Task<FamilyPatientDto> UpdatePatientWithFamily(FamilyPatientDto familyPatient)
        {
            try
            {
                var patient = _mapper.Map<FamilyPatientDto, Patient>(familyPatient);
                var updatedPatient = await _patientService.UpdatePatientWithFamily(patient);
                return _mapper.Map<Patient, FamilyPatientDto>(updatedPatient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw;
            }
        }

        public async Task<PatientInformationDto> GetPatientWithInformation(int patientId)
        {
            var patient = await _patientService.GetPatientWithInformation(patientId);
            return _mapper.Map<Patient, PatientInformationDto>(patient);
        }

        public async Task UpdatePatientWithInformation(PatientInformationDto patientInformationDto)
        {
            try
            {
                var patient = _mapper.Map<PatientInformationDto, Patient>(patientInformationDto);
                await _patientService.UpdatePatientWithInformation(patient);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
}
