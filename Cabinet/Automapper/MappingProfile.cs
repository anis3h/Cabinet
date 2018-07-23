using AutoMapper;
using Cabinet.Models.CabinetViewModel;
using Core.Entities;
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
            CreateMap<Patient, PatientViewModel>();
        }
    }
}
