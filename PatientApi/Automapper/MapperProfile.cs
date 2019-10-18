using AutoMapper;
using CommunCabinet.Dtos;
using Core.Entities.Patients;

namespace PatientApi.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientDto, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore())
                                            .ForMember(row => row.Siblings, opt => opt.Ignore());
            CreateMap<Patient, PatientDto>();
        }
    }
}
