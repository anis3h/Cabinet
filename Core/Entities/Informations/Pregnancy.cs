using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Entities.Informations
{
    // Grossesse
    // Schwangerschaft
    public class Pregnancy : EntityBase
    {
        public TypPregnancy TypPregnancy { get; set; }
        // Semaine
        public int? Week { get; set; }
        // Jour
        public int? Day { get; set; }
        // Position de naissance
        // Babispositionierung
        public TypPosition? TypPosition {get; set;}
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

// Schwangerschafttyp
public enum TypPosition
{
   Sommet,
   Siège
}