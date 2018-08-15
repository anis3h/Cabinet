using Cabinet.Models.CabinetVIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public int? Tel { get; set; }
        public FatherViewModel Father { get; set; }
        public MotherViewModel Mother { get; set; }
        public int? Fraternity { get; set; }
        public Age Age { get; set; }
        public BornViewModel Born {get; set;}
        public PregnancyViewModel Pregnancy { get; set; }
        public List<SiblingViewModel> Siblings { get; set; }
        public List<ConsultationViewModel> Consultations { get; set; }


        //public List<TypPregnancy> TypPregnancy { get; set; }

        //public PatientViewModel() {

        //    TypPregnancy = GetDataSourceTypes();
        //    //TypPregnancyList = GetDataSourceTypes();
        //}

        //public List<TypPregnancy> GetDataSourceTypes() {
        //    return EnumUtil.GetValues<TypPregnancy>().ToList();
        //    //return Enum.GetValues(typeof(TypPregnancy));

        //}

        //public static class EnumUtil {
        //    public static IEnumerable<T> GetValues<T>() {
        //        return Enum.GetValues(typeof(T)).Cast<T>();
        //    }
        //}

    }
}
