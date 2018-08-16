using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entities
{
    public class Patient : Person
    {
        public DateTime DateOfBirth { get; set; }
        public Father Father { get; set; }
        public Mother Mother { get; set; }
        public Born Born { get; set; }
        // Schwangerschaft
        // Grossesse
        public Pregnancy Pregnancy { get; set; }
        public List<Sibling> Siblings { get; set; }
        public int? BrothersCount
        {
            get
            {
                if (Siblings != null)
                {
                    return Siblings.Count(row => row is Brother);
                }
                else return null;
            }
        }
        public int? SistersCount
        {
            get
            {
                if (Siblings != null)
                {
                    return Siblings.Count(row => row is Sister);
                }
                else return null;
            }
        }
        public int? Fraternity
        {
            get {
                if (BrothersCount == null && SistersCount == null)
                    return null;
                else if (BrothersCount == null)
                {
                    return SistersCount;
                }
                else if (SistersCount == null)
                {
                    return BrothersCount;
                }
                else
                {
                    return BrothersCount + SistersCount;
                }
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
