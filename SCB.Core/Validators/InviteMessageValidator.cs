using DomainValidation.Validation;
using SCB.Core.Validations.Message;
using SCB.Data.Entities;
using MessageExMessages = SCB.Core.GlobalConstants.ExceptionMessages.Message;

namespace SCB.Core.Validators
{
    public sealed class InviteMessageValidator : Validator<Message>
    {
        public InviteMessageValidator()
        {
            Add(nameof(MessageIsEmpty), new Rule<Message>(new MessageIsEmpty(), MessageExMessages.MessageIsEmpty));
            Add(nameof(MessageIsGSM), new Rule<Message>(new MessageIsGSM(), MessageExMessages.IncorrectGSMFormat));
            Add(nameof(MessageIsTooLong), new Rule<Message>(new MessageIsTooLong(), MessageExMessages.TooLong));
        }
    }
}
