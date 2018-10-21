using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    public class Palpation : EntityBase
    {
        //Adénopathies: oui/non(si oui phrase)
        public bool? Adénophaties { get; set; }
        public string AdénophatiesDescription { get; set; }
        //Autres: phrase
        public string Autre { get; set; }
        public Examination Examination { get; set; }
    }
}
