using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public class PregnancyViewModel
    {

        [Required]
        public TypPregnancy TypPregnancy { get; set; }

        // Semaine
        public int? Week { get; set; }
        // Jour
        public int? Day { get; set; }
        // Position de naissance
        // Babispositionierung
        [Required]
        public TypPosition? Position { get; set; }



    }
}
