using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Suppport
{
    public abstract class DbSupport
    {
        [Column(TypeName = "DateTime")]
        public DateTime InsertDate { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime UpdateDate { get; set; }
    }
}
