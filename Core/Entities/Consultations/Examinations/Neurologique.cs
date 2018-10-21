using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    public class Neurologique : EntityBase
    {
        //Nuque souple: oui/non
        public bool? NuqueSouple { get; set; }
        //Signes méningés postifs: oui/non
        public bool? SignesMénigrésPositifs { get; set; }
        //A) ROT- s: 
        public Rots Rots { get; set; }
        //B) Troubles sensoriels: oui/non(si oui phrase)
        public bool? TroublesSensoriels { get; set; }
        public string TroublesSensorielsDesc { get; set; }
        public Examination Examination { get; set; }
    }
}
