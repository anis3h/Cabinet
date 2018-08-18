using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.Specifications.PatientSpecifications
{
    public class PatientWithAllDataSpecification : PatientBaseSpecification
    {
        public PatientWithAllDataSpecification(Expression<Func<Patient, bool>> criteria) : base(criteria)
        {

        }
        public override void AddIncludePatient()
        {
            AddInclude(patient => patient.PatientParents);
            AddInclude(patient => patient.Consultations);
            AddInclude(patient => patient.Pregnancy);
            AddInclude(patient => patient.Born);
        }

    }
}
