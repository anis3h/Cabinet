using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    // Peau
    public class SkinViewModel
    {
        public int Id { get; set; }
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
        public ExaminationViewModel Examination { get; set; }
    }
}