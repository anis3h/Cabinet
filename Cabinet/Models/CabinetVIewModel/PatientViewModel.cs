using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public int Tel { get; set; }
        public FatherViewModel Father { get; set; }
        public MotherViewModel Mother { get; set; }
        public int Fraternity { get; set; }
        public Age Age { get; set; }
        
       // public List<Consultation> Consultations { get; set; }
    }
}
