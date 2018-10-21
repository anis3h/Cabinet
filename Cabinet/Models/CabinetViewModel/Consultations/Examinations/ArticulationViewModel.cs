using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    public class ArticulationViewModel
    {
        public int Id { get; set; }
        //Ortolani: -/+
        public Ortolani? Ortolani { get; set; }
        //Malformations : Phrase
        public string Malformations { get; set; }
        //libres: oui/non 
        public bool? Libres { get; set; }
        //douleurs: oui/non
        public bool? Douleur { get; set; }
        //rougeur: oui/non  
        public bool? Rougeur { get; set; }
        //enflement: oui/non
        public bool? Enflement { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}