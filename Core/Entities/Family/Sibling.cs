using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Family
{
    // Geschwister
    // Frere et soeur
    public class Sibling : EntityBase
    {
        public Age Age { get; }
        // En bonne santé
        public bool? Health { get; set; }
        // Maladie 
        public string Information { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Patient Patient { get; set; }
        public string SiblingType { get; set; }
        
    }
}
