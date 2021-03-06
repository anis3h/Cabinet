﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Informations
{
    public class PregnancyViewModel
    {

        [Required]
        public TypPregnancy TypPregnancy { get;
            set; }

        // Mois
        public int Month { get; set; }
        // Semaine
        public int? Week { get;
            set; }
        // Jour
        public int? Day { get; set; }
        // Position de naissance
        // Babispositionierung
  
        public TypPosition? Position { get; set; }

    }
}
