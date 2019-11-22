using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunCabinet.Dtos
{
    public class PregnancyDto
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TypPregnancy? TypPregnancy { get; set; }
        // Mois
        public int Month { get; set; }
        // Semaine
        public int? Week { get; set; }
        // Jour
        public int? Day { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TypPosition? TypPosition { get; set; }
    }
}
