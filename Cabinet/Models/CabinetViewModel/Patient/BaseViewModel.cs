using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Patient
{
    public abstract class BaseViewModel
    {
        public virtual PatientBaseViewModel Patient { get;
            set; }
    }
}
