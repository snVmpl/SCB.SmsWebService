using Microsoft.EntityFrameworkCore;
using SCB.Core.Factories;
using SCB.Core.Interfaces;
using SCB.Core.Validators;
using SCB.Data.Entities;
using SCB.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCB.Core.Services
{
    public class InviteService : IInviteService
    {
        private readonly IRepository<Invite> _inviteRepository;
        private readonly InvitePhoneNumbersValidator _inviteValidator;
        private readonly InviteMessageValidator _inviteMessageValidator;

        public InviteService(IRepository<Invite> inviteRepository, InvitePhoneNumbersValidator inviteValidator,
            InviteMessageValidator inviteMessageValidator)
        {
            _inviteRepository = inviteRepository;
            _inviteValidator = inviteValidator;
            _inviteMessageValidator = inviteMessageValidator;
        }

        public async Task<string> SendInvitesAsync(List<string> phoneNumbers, string message)
        {
            try
            {
                var todayInvites = await GetCountInvitationsAsync(4);

                if (todayInvites + phoneNumbers.Count > 128)
                    return GlobalConstants.ExceptionMessages.PhoneNumbers.PhoneNumbers128PerDayLimit;


                var inviteMessage = InviteFactory.CreateMessage(message);
                var validResult = _inviteMessageValidator.Validate(inviteMessage);

                if (!validResult.IsValid)
                    return validResult.Message;

                var invites = phoneNumbers.Select(c => InviteFactory.CreateInvite(c, inviteMessage)).ToList();

                validResult = _inviteValidator.Validate(invites);
                if (!validResult.IsValid)
                    return validResult.Message;

                var sendResult = await SendSmsInvitesAsync(invites);

                if (sendResult)
                    await _inviteRepository.InsertCollectionAsync(invites);

                return GlobalConstants.SuccessMessage.MessagesSent;
            }
            catch (Exception e)
            {
                return $"{GlobalConstants.ExceptionMessages.Common.InternalError} {e.Message}.";
            }
        }

        private async Task<int> GetCountInvitationsAsync(int apiId)
        {
            return await _inviteRepository.Entities.Where(c => c.ApiId == apiId && (DateTime.UtcNow - c.CreatedDate).Days == 0).CountAsync();
        }

        private async Task<bool> SendSmsInvitesAsync(List<Invite> invites)
        {
            // TODO here have to be sms send implementation
            return true;
        }
    }
}
