using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunCabinet.Dtos;
using Core.Entities.Patients;

namespace InformationsApi.AutoMapper
{
    public class InformationsMappingProfile : Profile
    {
        public InformationsMappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();
                //.ForMember(row => row.PatientParents, opt => opt.Ignore())
                //.ForMember(row => row.Siblings, opt => opt.Ignore());
        }
    }
}
