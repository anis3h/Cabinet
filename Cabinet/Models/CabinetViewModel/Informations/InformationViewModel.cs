using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Informations
{

    public class InformationViewModel 
    {
        public InformationPatientViewModel Patient { get; set; }
        //public InformationPatientViewModel _patient;
        //public override PatientBaseViewModel Patient
        //{
        //    get
        //    {
        //        return _patient as InformationPatientViewModel;
        //    }
        //    set
        //    {
        //        _patient = value as InformationPatientViewModel;
        //    }
        //}


        public List<string> TypPregnancyList { get; set; }

        public List<string> TypPositionList { get; set; }

        public InformationViewModel() {
             
            GetEnumTypesToString();
        }

        public void GetEnumTypesToString() {
            TypPregnancyList = Enum.GetNames(typeof(TypPregnancy)).ToList();
            TypPositionList = Enum.GetNames(typeof(TypPosition)).ToList();          
        }
    }
}
