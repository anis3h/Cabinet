using Core.Entities;
using Core.Entities.Family;
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

            AddInclude(row => row.PatientParents);
            AddInclude($"{nameof(Patient.PatientParents)}.{nameof(PatientParent.Parent)}");
          //  AddInclude(patient => patient.Mother);
          //  AddInclude(patient => patient.Brothers);
           // AddInclude(patient => patient.Sisters);
        }
    }
}
