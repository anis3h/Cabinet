using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    // Grossesse
    public class Pregnancy
    {
        public TypPregnancy TypPregnancy { get; set; }
        // Semaine
        public int Week { get; set; }
        // Jour
        public int Day { get; set; }
        // Poids de naissance
        public int BirthWeight { get; set; }
       
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