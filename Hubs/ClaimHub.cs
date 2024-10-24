using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ContractMonthlyClaimSystem.Hubs
{
    public class ClaimHub : Hub
    {
        // Method to notify clients when the claim status changes
        public async Task NotifyStatusChange(string message)
        {
            await Clients.All.SendAsync("ReceiveStatusUpdate", message);
        }
    }
}
