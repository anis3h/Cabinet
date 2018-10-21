using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    public class Articulation : EntityBase
    {
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
        public Examination Examination { get; set; }
    }
}
public enum Ortolani
{
    [Display(Name = "+")]
    positif,
    [Display(Name = "-")]
    negatif
}