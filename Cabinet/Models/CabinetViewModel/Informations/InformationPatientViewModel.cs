
using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Informations
{
    public class InformationPatientViewModel : PatientViewModel
    {
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DisplayName("Geburtsdatum")]
        //public override DateTime DateOfBirth { get; set; }


        public string Tel { get; set; }

        private PregnancyViewModel _pregnancy;

        public PregnancyViewModel Pregnancy
        {
            get
            {
                if (_pregnancy == null) {
                    _pregnancy = new PregnancyViewModel();
                }
                return _pregnancy;
            }
            set { _pregnancy = value; }
        }

        private BornViewModel _born;

        public BornViewModel Born {

            get {
                if (_born == null) {
                    _born = new BornViewModel();
                }
                    return _born;

            }
            set { _born = value; }
        }
    }
}
