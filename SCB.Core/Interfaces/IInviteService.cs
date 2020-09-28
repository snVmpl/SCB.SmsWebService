using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCB.Core.Interfaces
{
    public interface IInviteService
    {
        Task<string> SendInvitesAsync(List<string> phoneNumbers, string message);
    }
}
