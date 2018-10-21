using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    public class Inspection : EntityBase
    {
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
        public Examination Examination { get; set; }
    }
}

public enum EtatDeConscience
{
    consient,
    omnibulé,
    inconscient
}


public enum EtatGeneral
{
    bon,
    mauvais,
    [Display(Name = "trés mauvais")]
    trés_mauvais
}

public enum EtatHydratation
{
    bon,
    déshydratation
}

public enum StadeDéshydratation
{
    [Display(Name = "stade 1")]
    stade_1,
    [Display(Name = "stade 2")]
    stade_2,
    [Display(Name = "stade 3")]
    stade_3
}

public enum Respiratoire
{
    Eupnéique,
    dyspnéique
}