using Cabinet.Models.CabinetViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetVIewModel {

    public class InformationViewModel {

        public PatientViewModel Patient { get; set; }


        public List<string> TypPregnancyList { get; set; }

        public InformationViewModel() {

            TypPregnancyList = GetDataSourceTypes();
        }

        public List<string> GetDataSourceTypes() {
            return Enum.GetNames(typeof(TypPregnancy)).ToList();
        }
    }
}
