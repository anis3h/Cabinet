using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    // Récapitulation
    public class Review
    {
        public string Remarque { get; set; } 
        public List<string> Syntheses { get; set; }
        public List<string> Diagnostics { get; set; }
        public List<string> Traitements { get; set; }
    }
}
