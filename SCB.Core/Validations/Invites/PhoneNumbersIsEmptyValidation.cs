using DomainValidation.Interfaces.Specification;
using SCB.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SCB.Core.Validations.Invites
{
    public class PhoneNumbersIsEmptyValidation : ISpecification<List<Invite>>
    {
        public bool IsSatisfiedBy(List<Invite> entity)
        {
            return entity.Any();
        }
    }
}
