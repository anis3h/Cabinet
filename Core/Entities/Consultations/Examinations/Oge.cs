using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    public class Oge : EntityBase
    {
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
        public Examination Examination { get; set; }
    }
}
public enum Sex
{
    masculin,
    feminin
}