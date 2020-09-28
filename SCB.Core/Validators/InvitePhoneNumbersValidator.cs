using DomainValidation.Validation;
using SCB.Core.Validations.Invites;
using SCB.Data.Entities;
using System.Collections.Generic;
using PhoneNumbersExMessages = SCB.Core.GlobalConstants.ExceptionMessages.PhoneNumbers;

namespace SCB.Core.Validators
{
    public sealed class InvitePhoneNumbersValidator : Validator<List<Invite>>
    {
        public InvitePhoneNumbersValidator()
        {
            Add(nameof(PhoneNumbersIsEmptyValidation), new Rule<List<Invite>>(new PhoneNumbersIsEmptyValidation(), PhoneNumbersExMessages.PhoneNumbersIsEmpty));
            Add(nameof(PhoneNumbers16Limit), new Rule<List<Invite>>(new PhoneNumbers16Limit(), PhoneNumbersExMessages.PhoneNumbers16Limit));
            Add(nameof(PhoneNumbersFormatValidation), new Rule<List<Invite>>(new PhoneNumbersFormatValidation(), PhoneNumbersExMessages.NotInternationalFormat));
            Add(nameof(PhoneNumbersHasDuplicates), new Rule<List<Invite>>(new PhoneNumbersHasDuplicates(), PhoneNumbersExMessages.DuplicateNumbers));
        }
    }
}
