using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    public class AbdomenViewModel
    {
        public int Id { get; set; }
        //Ballonné: oui/non
        public bool? Ballonné { get; set; }
        //Souple : oui/non
        public bool? Souple { get; set; }
        //Défense: oui/non
        public bool? Défense { get; set; }
        //Fosse iliaque libre: oui/non
        public bool? FosseIliaqueLibre { get; set; }
        public string FosseIliaqueLibreDescr { get; set; }
        //Masse palpable: oui/non(si oui phrase)
        public bool? MassePalpable { get; set; }
        public string MassePalpableDescr { get; set; }
        //HM: 0 - 5 TD
        public int? Hm { get; set; }
        //SM: 0 - 5 TD
        public int? Sm { get; set; }
        //douleur lombaire spontanée: non/oui
        public bool? DouleurLombaireSpontanée { get; set; }
        //douleur lombaire à l’ébranlement: oui /non
        public bool? DouleurLombaireÈbranlement { get; set; }
        //Vessie: pleine/vide
        public Vessie Vessie { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}
