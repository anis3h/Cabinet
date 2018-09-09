using Core.Entities.Suppport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class EntityBase : DbSupport
    {
        public int Id { get; set; }
        
    }
}
