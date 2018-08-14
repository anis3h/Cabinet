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
        public int Fraternity { get; set; }
        public Born Born { get; set; }
        // Schwangerschaft
        // Grossesse
        public Pregnancy Preganancy { get; set; }
        public List<Sibling> Siblings { get; set; }
        public int BrothersCount
        {
            get
            {
                return Siblings.Count(row => row is Brother);
            }
        }
        public int SistersCount
        {
            get
            {
                return Siblings.Count(row => row is Sister);
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
