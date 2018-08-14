using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    // Geschwister
    // Frere et soeur
    public class Sibling : EntityBase
    {
        public Age Age;
        // En bonne santé
        public bool Health { get; set; }
        // Maladie 
        public bool Information { get; set; }

        public DateTime DateOfBirth { get; set; }
}
}
