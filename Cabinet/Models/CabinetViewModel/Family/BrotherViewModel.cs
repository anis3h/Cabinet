using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Family
{
    public class BrotherViewModel : SiblingViewModel
    {
        public override string FraternityType => "Brother";
    }
}
