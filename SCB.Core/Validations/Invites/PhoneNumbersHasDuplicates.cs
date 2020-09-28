using DomainValidation.Interfaces.Specification;
using SCB.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SCB.Core.Validations.Invites
{
    public class PhoneNumbersHasDuplicates : ISpecification<List<Invite>>
    {
        public bool IsSatisfiedBy(List<Invite> entity)
        {
            return entity.Count == entity.Distinct().Count();
        }
    }
}
