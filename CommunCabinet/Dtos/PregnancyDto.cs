using System;
using System.Collections.Generic;
using System.Text;

namespace CommunCabinet.Dtos
{
    public class PregnancyDto
    {
        public TypPregnancy TypPregnancy { get; set; }
        // Mois
        public int Month { get; set; }
        // Semaine
        public int? Week { get; set; }
        // Jour
        public int? Day { get; set; }
        // Position de naissance
        public TypPosition? Position { get; set; }
    }
}
