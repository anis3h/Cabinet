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
        public List<PatientParent> PatientParents { get; internal set; }
        public Born Born { get; set; }
        // Schwangerschaft
        // Grossesse
        public Pregnancy Pregnancy { get; set; }
        public List<Sibling> Siblings { get; set; }
        [NotMapped]
        public List<Brother> Brothers { get; set; }
        [NotMapped]
        public List<Sister> Sisters { get; set; }

        private List<Parent> _parents = new List<Parent>();

        [NotMapped]
        public List<Parent> Parents 
        {
            get
            {
                if (Father != null) _parents.Add(Father);
                if (Mother != null) _parents.Add(Mother);
                return _parents;
            }
        }

        private Father _father;
        [NotMapped]
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
                else return _father;
            }
            set {
                _father = value;
            }
        }

        private Mother _mother;
        [NotMapped]
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
                else return _mother;
            }
            set
            {
                _mother = value;
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

        // Call if the Father and Mother are modified
        public void UpdatePatientParents()
        {            
            if (PatientParents == null)
                PatientParents = new List<PatientParent>();
          
            foreach (Parent parent in Parents)
            {
                if (!PatientParents.Any(row => row.Parent.Id == parent.Id && row.Parent.Id != 0))
                {
                    PatientParents.Add(new PatientParent() { Parent = parent, Patient = this });
                }
                else
                {
                    Parent parentOld = PatientParents.FirstOrDefault(row => row.Parent.Id == parent.Id).Parent;
                    parentOld.FirstName = parent.FirstName;
                    parentOld.Name = parent.Name;
                    parentOld.Tel = parent.Tel;
                    parent.Adresse = parent.Adresse;
                    parent.Profession = parent.Profession;
                    if(parentOld is Mother)
                    {
                        (parentOld as Mother).MaidenName = (parent as Mother).MaidenName;
                    }
                }
            }
        }
        public Patient() { }
    }
}
