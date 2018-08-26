using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Family
{
    public class FamilyViewModel : BaseViewModel
    {
        FamilyPatientViewModel _patient;

        public new FamilyPatientViewModel Patient {
            get
            {
              
                return _patient;
            }
            set
            {

                //if(base.Patient as FamilyPatientViewModel != _patient)
                //    _patient = base.Patient as FamilyPatientViewModel;
                base.Patient = value as PatientBaseViewModel;
                _patient = value;
                
            }
        }

    }
}
