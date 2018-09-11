using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Family
{
    public class SisterViewModel : SiblingViewModel
    {
        public SisterViewModel()
        {

        }
        public SisterViewModel(SiblingViewModel sibling) : base (sibling)
        {
           
        }

        public override string Type => GetType().ToString();
        public override string SiblingType => "Sister";
    }
}
