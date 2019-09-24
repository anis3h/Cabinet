using System;
using System.Collections.Generic;
using System.Text;

namespace CommunCabinet.Dtos
{
    public class PatientDto 
    {
        public int? Id { get; set; }
        public int FileNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public Age Age { get; set; }
    }
}
