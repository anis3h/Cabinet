﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Patient
{
    public abstract class PatientBaseViewModel
    {
        public int? Id { get; set; }
        public int FileNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public Age Age { get; set; }       
    }
}
