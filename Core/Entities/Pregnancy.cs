using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    // Grossesse
    public class Pregnancy : EntityBase
    {
        public TypPregnancy TypPregnancy { get; set; }
        // Semaine
        public int Week { get; set; }
        // Jour
        public int Day { get; set; }
        // Poids de naissance
        public int BirthWeight { get; set; }
        //public Patient Patient {get; set; }
       
    }
}

// Schwangerschafttyp
public enum TypPregnancy
{
    Aterm,
    // Noch nicht reif
    Prématuré,
    // Zwilling
    Gemulaire,
    // Drilling
    Triplé
}