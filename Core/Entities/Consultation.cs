﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    // Untersuchung
    public class Consultation : EntityBase
    {
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Information { get; set; }
        // List de maladie
        public List<Illness> IllnessList { get; set; }
        public int Temperature { get; set; }
        // Mesure de tete
        public int Pc { get; set; }
        // Poid
        public int Weight { get; set; }
        // Taille
        // Grösse
        public int Cut { get; set; }
        public Patient Patient { get; set; }
        // Schwangerschaft
       // public Pregnancy Preganancy { get; set; }
        public Consultation() : base() { }
    }
}
