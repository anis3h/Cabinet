using System;
using System.Collections.Generic;
using System.Text;

namespace CommunCabinet.Dtos
{
    public class PatientIndex 
    {
        public int? Id { get; set; }
        public int FileNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public Age Age { get; set; }
    }
}
