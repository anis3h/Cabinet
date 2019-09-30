using AutoMapper;
using CommunCabinet.Dtos;
using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientApi.Automapper
{
    public class MapperProfile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<PatientDto, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore())
                                                .ForMember(row => row.Siblings, opt => opt.Ignore());
            }
        }
    }
}
