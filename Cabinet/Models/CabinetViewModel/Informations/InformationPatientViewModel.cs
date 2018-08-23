using Cabinet.Models.CabinetVIewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public class InformationPatientViewModel : PatientBaseViewModel
    {
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DisplayName("Geburtsdatum")]
        //public override DateTime DateOfBirth { get; set; }

        public BornViewModel Born { get; set; }

        private PregnancyViewModel _pregnancy;
        public PregnancyViewModel Pregnancy
        {

            get
            {
                if (_pregnancy == null)
                {
                    _pregnancy = new PregnancyViewModel();
                    return _pregnancy;
                }
                else
                {
                    return _pregnancy;
                }
            }
            set { _pregnancy = value; }
        }

    }
}
