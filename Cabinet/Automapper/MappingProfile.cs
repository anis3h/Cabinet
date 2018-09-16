using AutoMapper;
using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetViewModel.Consultations;
using Cabinet.Models.CabinetViewModel.Family;
using Cabinet.Models.CabinetViewModel.Informations;
using Cabinet.Models.CabinetViewModel.Patient;
using Core.Entities;
using Core.Entities.Consultations;
using Core.Entities.Family;
using Core.Entities.Informations;
using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Family
            CreateMap<Father, FatherViewModel>();
            CreateMap<Mother, MotherViewModel>();
            CreateMap<FatherViewModel, Father>();
            CreateMap<MotherViewModel, Mother>();
            CreateMap<Mother, MotherViewModel>();

            CreateMap<Sibling, SiblingViewModel>()
                .Include<Brother, BrotherViewModel>()
                .Include<Sister, SisterViewModel>();
            CreateMap<Brother, BrotherViewModel>();
            CreateMap<Sister, SisterViewModel>();

            //CreateMap<SiblingViewModel, Sibling>()
            //    .Include<BrotherViewModel, Brother>()
            //    .Include<SisterViewModel,Sister>();
            CreateMap<BrotherViewModel, Brother>();
            CreateMap<SisterViewModel, Sister>();

            CreateMap<Born, BornViewModel>();
            CreateMap<BornViewModel, Born>();
            CreateMap<Pregnancy, PregnancyViewModel>();
            CreateMap<PregnancyViewModel, Pregnancy>();
         
            // CreateMap<(MotherViewModel, PatientVIewModel), List < PatientParent(Patient, Parent) > ();

            CreateMap<Patient, InformationPatientViewModel>();
            CreateMap<Patient, FamilyPatientViewModel>();
            CreateMap<Patient, PatientViewModel>();

            CreateMap<PatientViewModel, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore())
                                                  .ForMember(row => row.Siblings, opt => opt.Ignore());
            CreateMap<FamilyPatientViewModel, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore())
                                                        .ForMember(row => row.Siblings, opt => opt.Ignore());
            CreateMap<InformationPatientViewModel, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore());

            // Consultations
            CreateMap<Consultation, ConsultationViewModel>();
            CreateMap<ConsultationViewModel, Consultation>();
        }
    }
}
