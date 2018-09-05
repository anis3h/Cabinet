﻿using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Family
{
    public class FamilyPatientViewModel : PatientBaseViewModel
    {
        //[DisplayName("FamilyGeburtsdatum")]
        //public override DateTime DateOfBirth { get; set; }
        public FatherViewModel Father { get; set; }
        public MotherViewModel Mother { get; set; }
        public int? Fraternity { get; set; }
        public List<SiblingViewModel> Siblings { get; set; }
    }
}
