using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? InsertDate { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? UpdateDate { get; set; }
    }
}
