using Core.Entities.Family;
using System;
using System.Linq.Expressions;

namespace Core.Specifications.Parents
{
    public class ParentBaseSpec : BaseSpecification<Parent>
    {
        protected ParentBaseSpec() : base(row => true)
        {
            AddIncludeParent();
        }

        protected ParentBaseSpec(Expression<Func<Parent, bool>> criteria) : base(criteria)
        {
            AddIncludeParent();
        }

        public virtual void AddIncludeParent()
        {

        }
    }
}
