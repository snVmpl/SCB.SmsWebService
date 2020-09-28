using SCB.Data.Entities;
using System.Text.RegularExpressions;
using UnidecodeSharpFork;

namespace SCB.Core.Factories
{
    public static class InviteFactory
    {
        public static Invite CreateInvite(string phoneNumber, Message message)
        {
            var invite = new Invite
            {
                PhoneNumber = phoneNumber,
                Message = message,
                ApiId = 4
            };

            return invite;
        }

        public static Message CreateMessage(string message)
        {
            if (Regex.IsMatch(message, GlobalConstants.RegexRules.HasCyrillic))
                message = NormalizeMessage(message);

            var inviteMessage = new Message
            {
                Text = message
            };

            return inviteMessage;
        }

        private static string NormalizeMessage(string message)
        {
            return message.Unidecode();
        }
    }
}
