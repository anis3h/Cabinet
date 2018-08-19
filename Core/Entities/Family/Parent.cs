using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Family
{
    public abstract class Parent : Person
    {
        protected Parent () { } 
        public string Profession { get; set; }
        public List<PatientParent> PatientParents { get; set; }
    }
}
