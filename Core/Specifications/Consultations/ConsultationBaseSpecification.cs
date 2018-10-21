using Core.Entities.Consultations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications.Consultations
{
    public abstract class ConsultationBaseSpecification : BaseSpecification<Consultation>
    {
        protected ConsultationBaseSpecification() : base(row => true)
        {
            AddIncludeConsultation();
        }

        protected ConsultationBaseSpecification(Expression<Func<Consultation, bool>> criteria) : base(criteria)
        {
            AddIncludeConsultation();
        }

        public abstract void AddIncludeConsultation();
    }
}
