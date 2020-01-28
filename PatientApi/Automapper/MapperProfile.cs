using AutoMapper;
using CommunCabinet.Dtos;
using Core.Entities.Family;
using Core.Entities.Informations;
using Core.Entities.Patients;

namespace PatientApi.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Patient, Patient>().
                ForMember(row => row.PatientParents, opt => opt.Ignore());

            CreateMap<Father, Father>().
                 ForMember(row => row.PatientParents, opt => opt.Ignore());

            CreateMap<Mother, Mother>().
                ForMember(row => row.PatientParents, opt => opt.Ignore());

            CreateMap<Patient, PatientDto>();

            CreateMap<Patient, FamilyPatientDto>()
                .ForMember(row => row.Patient, opt => opt.MapFrom(src => src))
                .ForMember(row => row.Siblings, opt => opt.MapFrom(src => src.Siblings))
                .ForMember(row => row.Father, opt => opt.MapFrom(src => src.Father != null ? src.Father : new Father()))
                .ForMember(row => row.Mother, opt => opt.MapFrom(src => src.Mother != null ? src.Mother : new Mother()));

            CreateMap<Sibling, SiblingDto>();

            CreateMap<Patient, PatientInformationDto>()
                .ForMember(row => row.Patient, opt => opt.MapFrom(src => src));

            //CreateMap<Father, FatherDto>()
            //    .ForMember(row => row.PatientParentId, opt => opt.MapFrom(src => src.PatientParents);

            CreateMap<Born, BornDto>();

            CreateMap<Pregnancy, PregnancyDto>();

            CreateMap<Father, FatherDto>();
            CreateMap<Mother, MotherDto>();
            // DTO to Entity

            CreateMap<PatientDto, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore())
                                          .ForMember(row => row.Siblings, opt => opt.Ignore());

            CreateMap<FamilyPatientDto, Patient>()
                .ForMember(row => row.Id, opt => opt.MapFrom(src => src.Patient.Id))
                .ForMember(row => row.FileNumber, opt => opt.MapFrom(src => src.Patient.FileNumber))
                .ForMember(row => row.FirstName, opt => opt.MapFrom(src => src.Patient.FirstName))
                .ForMember(row => row.Name, opt => opt.MapFrom(src => src.Patient.Name))
                .ForMember(row => row.DateOfBirth, opt => opt.MapFrom(src => src.Patient.DateOfBirth))
                .ForMember(row => row.Adresse, opt => opt.MapFrom(src => src.Patient.Adresse))
                .ForMember(row => row.Tel, opt => opt.MapFrom(src => src.Patient.Tel))
                .ForMember(row => row.Father, opt => opt.MapFrom(src => src.Father))
                .ForMember(row => row.Mother, opt => opt.MapFrom(src => src.Mother))
                .ForMember(row => row.Siblings, opt => opt.MapFrom(src => src.Siblings));

            CreateMap<FatherDto, Father>();
            CreateMap<MotherDto, Mother>();
            CreateMap<SiblingDto, Sibling>();

            CreateMap<PatientInformationDto, Patient>()
              .ForMember(row => row.Id, opt => opt.MapFrom(src => src.Patient.Id))
              .ForMember(row => row.FileNumber, opt => opt.MapFrom(src => src.Patient.FileNumber))
              .ForMember(row => row.FirstName, opt => opt.MapFrom(src => src.Patient.FirstName))
              .ForMember(row => row.Name, opt => opt.MapFrom(src => src.Patient.Name))
              .ForMember(row => row.DateOfBirth, opt => opt.MapFrom(src => src.Patient.DateOfBirth))
              .ForMember(row => row.Adresse, opt => opt.MapFrom(src => src.Patient.Adresse))
              .ForMember(row => row.Tel, opt => opt.MapFrom(src => src.Patient.Tel))
              .ForMember(row => row.Born, opt => opt.MapFrom(src => src.Born))
              .ForMember(row => row.Pregnancy, opt => opt.MapFrom(src => src.Pregnancy));

            CreateMap<BornDto, Born>();

            CreateMap<BornDto, Born>();
            CreateMap<PregnancyDto, Pregnancy>();
        }
    }
}
