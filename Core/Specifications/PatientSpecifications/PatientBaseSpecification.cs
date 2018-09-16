using Core.Entities;
using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications.PatientSpecifications
{
    public abstract class PatientBaseSpecification: BaseSpecification<Patient>
    {
        protected PatientBaseSpecification() : base(row => true)
        {

        }

        protected PatientBaseSpecification(Expression<Func<Patient, bool>> criteria) : base(criteria)
        {
        }

        public abstract void AddIncludePatient();
    }
}
