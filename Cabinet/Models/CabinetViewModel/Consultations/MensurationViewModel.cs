using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations
{
    public class MensurationViewModel
    {
        public int Id { get; set; }
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
        public ConsultationViewModel Consultation { get; set; }
    }
}
