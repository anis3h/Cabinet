using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Informations
{

    public class InformationViewModel : BaseViewModel
    {
        public InformationViewModel() {

            GetEnumTypesToString();
        }

        public InformationPatientViewModel _patient;

        public new InformationPatientViewModel Patient {

            get {
                return _patient;
            }
            set {
                base.Patient = value as PatientBaseViewModel;
                _patient = value;

            }
        }

        public List<string> TypPregnancyList { get; set; }

        public List<string> TypPositionList { get; set; }

        public List<string> AllaitementList { get; set; }


        public void GetEnumTypesToString() {
            TypPregnancyList = Enum.GetNames(typeof(TypPregnancy)).ToList();
            TypPositionList = Enum.GetNames(typeof(TypPosition)).ToList();
            AllaitementList = Enum.GetNames(typeof(Allaitement)).ToList();
        }
    }
}
