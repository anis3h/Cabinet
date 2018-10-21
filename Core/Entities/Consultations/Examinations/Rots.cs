using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    // Rot - s
    public class Rots : EntityBase
    {
        //présents: oui/non(si non phrase)
        public bool? Présents { get; set; }
        public bool? PrésentsDescr { get; set; }
        //symétriques[claire]: oui/non(si non phrase)
        public bool? SymétriquesClaire { get; set; }
        public string SymétriquesClaireDescr { get; set; }
        //Babinski: oui/non
        public bool? Babinski { get; set; }
        public Neurologique Neurologique { get; set; }
    }
}
