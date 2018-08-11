using Cabinet.Models.CabinetViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetVIewModel
{
    public class ConsultationViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Information { get; set; }
        // List de maladie
       // public List<Illness> IllnessList { get; set; }
        public int Temperature { get; set; }
        // Mesure de tete
        public int Pc { get; set; }
        // Poid
        public int Weight { get; set; }
        // Taille
        public int Cut { get; set; }
        public string Grossesse { get; set; } 
        public PatientViewModel Patient { get; set; }
    }
}


