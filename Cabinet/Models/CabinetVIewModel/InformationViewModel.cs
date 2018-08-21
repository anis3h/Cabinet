using Cabinet.Models.CabinetViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetVIewModel {

    public class InformationViewModel {

        public PatientViewModel Patient { get; set; }

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
