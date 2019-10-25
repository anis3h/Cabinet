using AutoMapper;
using CommunCabinet.Dtos;
using Core.Entities.Informations;
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

            CreateMap<Patient, FamilyPatientDto>().ForMember(row => row.Patient, opt => opt.MapFrom(src => src))
                                                  .ForMember(row => row.Siblings, opt => opt.Ignore());

            CreateMap<Patient, PatientInformationDto>().ForMember(row => row.Patient, opt => opt.MapFrom(src => src));
            CreateMap<Born, BornDto>();
            CreateMap<BornDto, Born>();
            CreateMap<Pregnancy, PregnancyDto>();
            CreateMap<PregnancyDto, Pregnancy>();
        }
    }
}
