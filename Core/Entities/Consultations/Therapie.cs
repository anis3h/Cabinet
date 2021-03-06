﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations
{
    public class Therapie : EntityBase
    {
        //Allergie medicamenteuse: oui/non(si oui phrase)
        public bool? AllergieMedicamenteuse { get; set; }
        public string AllergieMedicamenteuseDescr { get; set; }
        //Ordonnance(sera imprimée)
        public string Ordonnance { get; set; }
        public Consultation Consultation { get; set; }
    }
}
