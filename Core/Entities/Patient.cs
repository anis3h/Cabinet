using Core.Entities;
using Core.Entities.Consultations;
using Core.Entities.Family;
using Core.Entities.Informations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Core.Entities
{
    public class Patient : Person
    {
        public DateTime DateOfBirth { get; set; }
        public List<PatientParent> PatientParents { get; set; }
        public Born Born { get; set; }
        // Schwangerschaft
        // Grossesse
        public Pregnancy Pregnancy { get; set; }
        public List<Sibling> Siblings { get; set; }
        [NotMapped]
        public List<Brother> Brothers { get; set; }
        [NotMapped]
        public List<Sister> Sisters { get; set; }

        private Father _father;
        public Father Father
        {
            get
            {
                if (PatientParents != null && _father == null)
                {
                    _father = PatientParents.Where(row => row.Parent is Father && row.Patient == this)
                                         .Select(row => row.Parent)
                                         .SingleOrDefault() as Father;
                    return _father;
                }
                else return null;
            }
        }

        private Mother _mother;
        public Mother Mother
        {
            get
            {
                if (PatientParents != null && _mother == null)
                {
                    _mother = PatientParents.Where(row => row.Parent is Mother && row.Patient == this)
                                         .Select(row => row.Parent)
                                         .SingleOrDefault() as Mother;
                    return _mother;
                }
                else return null;
            }
        }

        public int BrothersCount
        {
            get
            {
                if (Brothers != null)
                {
                    return Brothers.Count();
                }
                else return 0;
            }
        }
        public int SistersCount
        {
            get
            {
                if (Sisters != null)
                {
                    return Sisters.Count();
                }
                else return 0;
            }
        }
        public int? Fraternity
        {
            get {
                return BrothersCount + SistersCount; 
            }
        }
        
        // Untersuchungen
        public List<Consultation> Consultations{ get; set; }

        public Age Age
        {
            get
            {
                if (DateOfBirth != null)
                    return new Age(DateOfBirth);
                else return null;
            }
        }

        public Patient() { }
    }
}
