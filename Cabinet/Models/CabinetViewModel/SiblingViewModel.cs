using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public class SiblingViewModel
    {
        public TypPregnancy TypPregnancy { get; set; }
        // Semaine
        public int Week { get; set; }
        // Jour
        public int Day { get; set; }
        // Position de naissance
        // Babispositionierung
        public TypPosition Position { get; set; }
    }
}
