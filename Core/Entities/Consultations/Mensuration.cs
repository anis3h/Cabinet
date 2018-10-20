using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations
{
    public class Mensuration : EntityBase
    {
        //Poids(en kg.) :
        public double? Poids { get; set; }
        //Percentil: entre % 3-97, >, <
        public string PercentilPoids { get; set; }
        //Taille(cm) :
        public double? Taille { get; set; }
        //Percentil:  entre % 3-97, >, <
        public string PercentilTaille { get; set; }
        //PC(cm) :
        public double? Pc { get; set; }
        //Percentil en DS: (integer -4, + 3)
        public double? PercentilPc { get; set; }
        //Température: (double degrés Célsius)
        public double? Temperature { get; set; }
        //IMC: (double 10,5- 50)
        public double? Imc { get; set; }
        public Consultation Consultation { get; set; }
    }
}
