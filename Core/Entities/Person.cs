using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class Person : EntityBase
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
    }
}
