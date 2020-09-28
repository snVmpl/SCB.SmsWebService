using DomainValidation.Interfaces.Specification;
using SCB.Data.Entities;
using System.Collections.Generic;

namespace SCB.Core.Validations.Invites
{
    public class PhoneNumbers16Limit : ISpecification<List<Invite>>
    {
        public bool IsSatisfiedBy(List<Invite> entity)
        {
            return entity.Count <= 16;
        }
    }
}
