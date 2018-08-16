using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations
{
    // Untersuchung
    public class Consultation : EntityBase
    {
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Information { get; set; }
        // List de maladie
        // Krankheitsliste
        public List<Illness> IllnessList { get; set; }
        public int Temperature { get; set; }
        // Mesure de tete
        // Kopfmaße
        public int Pc { get; set; }
        // Poid
        // Gewicht
        public int Weight { get; set; }
        // Taille
        // Grösse
        public int Cut { get; set; }
        public Patient Patient { get; set; }
        public Consultation() : base() { }
    }
}
