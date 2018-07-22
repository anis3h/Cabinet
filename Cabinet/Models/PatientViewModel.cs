using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public int tel { get; set; }
        //public Father Father { get; set; }
        //public Mother Mother { get; set; }
        public int Fraternity { get; set; }
       // public List<Consultation> Consultations { get; set; }
    }
}
