using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications.PatientSpecifications
{
    public class PatientWithInformationsSpecification : PatientBaseSpecification
    {
        public PatientWithInformationsSpecification(Expression<Func<Patient, bool>> criteria) : base(criteria)
        {

        }
        public override void AddIncludePatient()
        {
            AddInclude(patient => patient.Born);
            AddInclude(patient => patient.Pregnancy);
        }
    }
}
