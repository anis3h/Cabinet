using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications.PatientSpecifications
{
    public class PatientWithFamilySpecification : PatientBaseSpecification
    {
        public PatientWithFamilySpecification(Expression<Func<Patient, bool>> criteria) : base(criteria)
        {

        }
        public override void AddIncludePatient()
        {
            AddInclude(patient => patient.Father);
            AddInclude(patient => patient.Mother);
        }
    }
}
