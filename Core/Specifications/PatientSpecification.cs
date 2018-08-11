using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Specifications
{
    public class PatientSpecification: BaseSpecification<Patient>
    {
        public PatientSpecification() : base(row => true)
        {
            AddInclude(patient => patient.Father);
            AddInclude(patient => patient.Mother);
            AddInclude(patient => patient.Consultations);
        }
    }
}
