using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    // Peau
    public class Skin : EntityBase
    {
        //Couleur: Bien colorée, paleur cutanée
        public SkinColor? SkinColor { get; set; }
        //Cyanose: oui/non
        public bool? Cyanose { get; set; }
        //TR : inf/sup à 3 secondes
        public Tr? Tr { get; set; }
        //Ictère d´intensité: faible, moyenne, intense
        public IctereIntensité? IctereIntensité { get; set; }
        //Eruptions: oui/non(si oui phrase)
        public bool? Eruption { get; set; }
        //Eruptions: oui/non(si oui phrase)
        public string EruptionDescr { get; set; }
        public Examination Examination { get; set; }
    }
}

public enum SkinColor
{
    [Display(Name = "bien colorée")]
    bien_colorée,
    [Display(Name = "paleur cutanée")]
    paleur_cutanée
}
public enum Tr
{
    [Display(Name = "inf à 3 secondes")] 
    inférieur,
    [Display(Name = "sup à 3 secondes")]
    supérieur
}

public enum IctereIntensité
{
    faible,
    moyenne,
    intense
}