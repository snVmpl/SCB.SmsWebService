using Microsoft.AspNetCore.Mvc;
using SCB.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCB.SmsWebService.Controllers
{
    [ApiController]
    [Route("api/invite")]
    public class InviteController : ControllerBase
    {
        private readonly IInviteService _inviteService;
        public InviteController(IInviteService inviteService)
        {
            _inviteService = inviteService;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendInvites(List<string> phoneNumbers, string message)
        {
            var sendResult = await _inviteService.SendInvitesAsync(phoneNumbers, message);

            return Ok(sendResult);
        }
    }
}
