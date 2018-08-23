using Cabinet.Models.CabinetVIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public abstract class PatientBaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public int? Tel { get; set; }
      
        public Age Age { get; set; }
       

        public List<ConsultationViewModel> Consultations { get; set; }
      
        //private PregnancyViewModel _pregnancy;
        //public PregnancyViewModel Pregnancy
        //{

        //    get
        //    {
        //        if (_pregnancy == null)
        //        {
        //            _pregnancy = new PregnancyViewModel();
        //            return _pregnancy;
        //        }
        //        else
        //        {
        //            return _pregnancy;
        //        }
        //    }
        //    set { _pregnancy = value; }
        //}

    }
}
