using Cabinet.Models.CabinetVIewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public abstract class PatientBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public int? Tel { get; set; }     
        public Age Age { get; set; }       
        public List<ConsultationViewModel> Consultations { get; set; }
    }
}
