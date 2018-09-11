using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Family
{
    public class FamilyPatientViewModel : PatientBaseViewModel
    {
        //[DisplayName("FamilyGeburtsdatum")]
        //public override DateTime DateOfBirth { get; set; }
        public FatherViewModel Father { get; set; }
        public MotherViewModel Mother { get; set; }
        public int? Fraternity { get; set; }
        public List<SiblingViewModel> Siblings { get; set; }
        public List<SisterViewModel> Sisters
        {
            get
            {
                if (Siblings != null)
                    return Siblings.OfType<SisterViewModel>().ToList();
                else return null;
            }
        }
        public List<BrotherViewModel> Brothers
        {
            get
            {
                if (Siblings != null)
                    return Siblings.OfType<BrotherViewModel>().ToList();
                else return null;
            }
        }
    }
}
