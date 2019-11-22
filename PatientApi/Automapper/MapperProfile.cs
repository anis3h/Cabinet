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
            CreateMap<Patient, Patient>();
            CreateMap<PatientDto, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore())
                                            .ForMember(row => row.Siblings, opt => opt.Ignore());
            CreateMap<Patient, PatientDto>();

            CreateMap<Patient, FamilyPatientDto>().ForMember(row => row.Patient, opt => opt.MapFrom(src => src))
                                                  .ForMember(row => row.Siblings, opt => opt.Ignore());

            CreateMap<Patient, PatientInformationDto>()
                .ForMember(row => row.Patient, opt => opt.MapFrom(src => src));

            CreateMap<PatientInformationDto, Patient>()
                .ForMember(row => row.Id, opt => opt.MapFrom(src => src.Patient.Id))
                .ForMember(row => row.FirstName, opt => opt.MapFrom(src => src.Patient.FirstName))
                .ForMember(row => row.Name, opt => opt.MapFrom(src => src.Patient.Name))
                .ForMember(row => row.DateOfBirth, opt => opt.MapFrom(src => src.Patient.DateOfBirth))
                .ForMember(row => row.Adresse, opt => opt.MapFrom(src => src.Patient.Adresse))
                .ForMember(row => row.Tel, opt => opt.MapFrom(src => src.Patient.Tel))
                .ForMember(row => row.Born, opt => opt.MapFrom(src => src.Born))
                .ForMember(row => row.Pregnancy, opt => opt.MapFrom(src => src.Pregnancy));
            CreateMap<Born, BornDto>();
            CreateMap<BornDto, Born>();
            CreateMap<Pregnancy, PregnancyDto>();
            CreateMap<PregnancyDto, Pregnancy>();
        }
    }
}
