using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    // Rot - s
    public class RotsViewModel
    {
        public int Id { get; set; }
        //présents: oui/non(si non phrase)
        public bool? Présents { get; set; }
        public bool? PrésentsDescr { get; set; }
        //symétriques[claire]: oui/non(si non phrase)
        public bool? SymétriquesClaire { get; set; }
        public string SymétriquesClaireDescr { get; set; }
        //Babinski: oui/non
        public bool? Babinski { get; set; }
        public NeurologiqueViewModel Neurologique { get; set; }
    }
}
