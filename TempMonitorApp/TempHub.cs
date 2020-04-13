using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TempMonitorApp
{
    public class TempHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}