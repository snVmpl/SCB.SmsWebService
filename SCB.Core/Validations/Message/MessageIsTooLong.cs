using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;

namespace SCB.Core.Validations.Message
{
    public class MessageIsTooLong : ISpecification<Data.Entities.Message>
    {
        public bool IsSatisfiedBy(Data.Entities.Message entity)
        {
            var latinRule = new Regex(GlobalConstants.RegexRules.IsOnlyLatin);
            return latinRule.IsMatch(entity.Text) && entity.Text.Length <= 160 || !latinRule.IsMatch(entity.Text) && entity.Text.Length <= 128;
        }
    }
}
