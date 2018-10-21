using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    public class NeurologiqueViewModel
    {
        public int Id { get; set; }
        //Nuque souple: oui/non
        public bool? NuqueSouple { get; set; }
        //Signes méningés postifs: oui/non
        public bool? SignesMénigrésPositifs { get; set; }
        //A) ROT- s: 
        public RotsViewModel Rots { get; set; }
        //B) Troubles sensoriels: oui/non(si oui phrase)
        public bool? TroublesSensoriels { get; set; }
        public string TroublesSensorielsDesc { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}
