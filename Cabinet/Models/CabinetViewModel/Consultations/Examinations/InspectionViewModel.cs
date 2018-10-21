using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    public class InspectionViewModel
    {
        public int Id { get; set; }
        //Etat de conscience: conscient, omnibulé, inconscient
        public EtatDeConscience? EtatDeConscience { get; set; }
        //Etat géneral: bon, mauvais, trés mauvais
        public EtatGeneral? EtatGeneral { get; set; }
        //Etat d’hydratation: bon,déshydratation
        public EtatHydratation? EtatHydratation { get; set; }
        //si déshydratation: stade: 1, 2, 3
        public StadeDéshydratation? StadeDéshydratation { get; set; }
        //État respiratoire: Eupnéique, dyspnéique
        public Respiratoire? Respiratoire { get; set; }
        //Malformations: phrase
        public string MalFormation { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}


