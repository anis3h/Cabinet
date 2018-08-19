using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Family
{
    public class PatientParent : EntityBase
    {
        // EF
        public PatientParent() { }

        public Patient Patient { get; set; }
        public Parent Parent { get; set; }
    }
}
