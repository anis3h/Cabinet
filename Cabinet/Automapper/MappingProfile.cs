using AutoMapper;
using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetVIewModel;
using Core.Entities;
using Core.Entities.Consultations;
using Core.Entities.Family;
using Core.Entities.Informations;
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
            // Add as many of these lines as you need to map your objects
            CreateMap<Father, FatherViewModel>();
            CreateMap<Mother, MotherViewModel>();
            CreateMap<FatherViewModel, Father>();
            CreateMap<MotherViewModel, Mother>();
            CreateMap<Mother, MotherViewModel>();
        
          
            CreateMap<Consultation, ConsultationViewModel>();
            CreateMap<Born, BornViewModel>();
            CreateMap<Pregnancy, PregnancyViewModel>();
            CreateMap<PregnancyViewModel, Pregnancy>();
            CreateMap<Sibling, SiblingViewModel>();
            CreateMap<Brother, BrotherViewModel > ();
            CreateMap<Sister, SisterViewModel>();
            // CreateMap<(MotherViewModel, PatientVIewModel), List < PatientParent(Patient, Parent) > ();

            CreateMap<Patient, InformationPatientViewModel>();
            CreateMap<Patient, FamilyPatientViewModel>();
            CreateMap<Patient, PatientViewModel>();

            CreateMap<PatientViewModel, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore());
            CreateMap<FamilyPatientViewModel, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore());
            CreateMap<InformationPatientViewModel, Patient>().ForMember(row => row.PatientParents, opt => opt.Ignore());
        }
    }
}
