using Cabinet.Models.CabinetViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Family
{
    public class BrotherViewModel : SiblingViewModel
    {
        public BrotherViewModel()
        {
        }
        public BrotherViewModel(SiblingViewModel sibling) : base(sibling)
        {

        }
        public override string SiblingType => "Brother";
        public override string Type => GetType().ToString();
    }
}
