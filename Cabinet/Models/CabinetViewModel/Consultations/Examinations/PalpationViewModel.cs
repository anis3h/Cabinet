using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    public class PalpationViewModel
    {
        public int Id { get; set; }
        //Adénopathies: oui/non(si oui phrase)
        public bool? Adénophaties { get; set; }
        public string AdénophatiesDescription { get; set; }
        //Autres: phrase
        public string Autre { get; set; }
        public ExaminationViewModel Examination { get; set; }
    }
}
