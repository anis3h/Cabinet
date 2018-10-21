using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    // Tete
    public class HeadViewModel
    {
        public int Id { get; set; }
        //Examen oculaire: phrase
        public string Oculaire { get; set; }
        //Examen ORL: phrase
        public string Orl { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}
