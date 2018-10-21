using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations
{
    public class TherapieViewModel
    {
        //Allergie medicamenteuse: oui/non(si oui phrase)
        public bool? AllergieMedicamenteuse { get; set; }
        public string AllergieMedicamenteuseDescr { get; set; }
        //Ordonnance(sera imprimée)
        public string Ordonnance { get; set; }
        public ConsultationViewModel Consultation { get; set; }
    }
}
