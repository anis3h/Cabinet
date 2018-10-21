using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    //Auscultation cardio-pulmonaire
    public class AuscultationCardioPulmonaireViewModel
    {
        public int Id { get; set; }
        //RR/mn:  (4 - 80)
        public double? Rr { get; set; }
        //Râles: oui/non(si oui phrase)
        public bool? Rales { get; set; }
        public string RalesDescr { get; set; }
        //Matité: oui/non(si oui phrase)
        public bool? Matité { get; set; }
        public string MatitéDescr { get; set; }
        //B.D.C fréquence: en nbre/mn(40- 300)
        public int? BdcFrequence { get; set; }
        //Rythme cardiaque: régulier/ non régulier
        public RythmeCardiaque? RythmeCardiaque { get; set;}
        //Bruits surajoutés: oui/non(si oui phrase)
        public bool? BruitsSurajoutés { get; set; }
        public string BruitsSurajoutésDescr { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}
