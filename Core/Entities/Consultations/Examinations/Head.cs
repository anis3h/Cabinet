using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    // Tete
    public class Head : EntityBase
    {
        //Examen oculaire: phrase
        public string Oculaire { get; set; }
        //Examen ORL: phrase
        public string Orl { get; set; }
        public Examination Examination { get; set; }
    }
}
