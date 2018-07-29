﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Patient: Person
    {
        public DateTime DateOfBirth { get; set; }      
        public Father Father { get; set; }
        public Mother Mother { get; set; }
        public int Fraternity { get; set; }
        public List<Consultation> Consultations{ get; set; }

        public Patient() { }
    }
}
