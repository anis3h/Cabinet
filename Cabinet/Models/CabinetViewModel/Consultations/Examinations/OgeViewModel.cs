using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    public class OgeViewModel
    {
        public int Id { get; set; }
        //Sex: masculin/feminin
        public Sex? Sex { get; set; }
        //Testicules en place: oui/non(si non phrase)
        public bool? TesticulePlace { get; set; }
        public string TesticulePlaceDescr { get; set; }
        //Ambiguité sexuelle: oui/non(si oui phrase)
        public bool? AmbiguitéSexuelle { get; set; }
        public string AmbiguitéSexuelleDescr { get; set; }
        //Hernie: oui/non(si oui phrase)
        public bool? Hernie { get; set; }
        public string HernieDescr { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}
