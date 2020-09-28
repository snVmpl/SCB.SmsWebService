using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SCB.Core;
using SCB.Core.Interfaces;
using SCB.Core.Services;
using SCB.Core.Validators;
using SCB.Data.Entities;
using SCB.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCB.Tests.Services
{
    [TestClass]
    public class InviteServiceTests
    {
        private readonly Mock<IRepository<Invite>> _inviteRepoMock;
        private readonly IInviteService _inviteService;
        private List<Invite> _invites;

        public InviteServiceTests()
        {
            _inviteRepoMock = new Mock<IRepository<Invite>>();
            var invitePhoneNumbersValidator = new InvitePhoneNumbersValidator();
            var inviteMessageValidator = new InviteMessageValidator();
            _inviteService = new InviteService(_inviteRepoMock.Object, invitePhoneNumbersValidator, inviteMessageValidator);

            Init();
        }

        [TestMethod]
        public async Task SendInviteTest()
        {
            var phoneNumbers = new List<string> { "79001112233" };
            var message = "Correct message. Has only latin";

            var result = await _inviteService.SendInvitesAsync(phoneNumbers, message);

            Assert.AreEqual(result, GlobalConstants.SuccessMessage.MessagesSent);
        }

        private void Init()
        {
            _invites = new List<Invite>
            {
                new Invite
                {
                    CreatedDate = DateTime.UtcNow,
                    ApiId = 4
                }
            };

            _inviteRepoMock.SetupGet(c => c.Entities).Returns(_invites.AsQueryable());
            _inviteRepoMock.Setup(c => c.InsertCollectionAsync(It.IsAny<List<Invite>>())).Callback<List<Invite>>(c => _invites.AddRange(c)).ReturnsAsync((List<Invite> c) => c);
        }
    }
}
