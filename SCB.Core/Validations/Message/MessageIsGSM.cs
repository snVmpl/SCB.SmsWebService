using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;

namespace SCB.Core.Validations.Message
{
    public class MessageIsGSM : ISpecification<Data.Entities.Message>
    {
        public bool IsSatisfiedBy(Data.Entities.Message entity)
        {
            var gsmRule = new Regex(GlobalConstants.RegexRules.IsGSMAndCyrillicFormat);
            return gsmRule.IsMatch(entity.Text);
        }
    }
}
