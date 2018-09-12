using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Family
{
    public class SiblingViewModel
    {
        public int Id { get; set; }
        public Age Age;

        public SiblingViewModel()
        {
            
        }

        public SiblingViewModel(SiblingViewModel sibling)
        {
            Age = sibling.Age;
            DateOfBirth = sibling.DateOfBirth;
            Id = sibling.Id;
            Information = sibling.Information;
            Health = sibling.Health;
        }

        // En bonne santé
        public bool? Health { get; set; }
        // Maladie 
        public string Information { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual string SiblingType { get; set; }
        public virtual string Type { get; set; }
        public string Fraternity { get; set; }
        //public PatientViewModel Patient { get; set; }
    }
}
