using DomainValidation.Interfaces.Specification;
using SCB.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SCB.Core.Validations.Invites
{
    public class PhoneNumbersFormatValidation : ISpecification<List<Invite>>
    {
        public bool IsSatisfiedBy(List<Invite> entity)
        {
            return entity.All(c => Regex.IsMatch(c.PhoneNumber, GlobalConstants.RegexRules.IsInternationalPhoneNumber));
        }
    }
}
