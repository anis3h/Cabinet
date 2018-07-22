using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Consultation : EntityBase
    {
      
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Information { get; set; }
        public string Krankheit { get; set; }

        public Consultation()  : base() { }
    }
}
