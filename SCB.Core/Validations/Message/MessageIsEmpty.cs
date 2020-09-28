using DomainValidation.Interfaces.Specification;

namespace SCB.Core.Validations.Message
{
    public class MessageIsEmpty : ISpecification<Data.Entities.Message>
    {
        public bool IsSatisfiedBy(Data.Entities.Message entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Text);
        }
    }
}
