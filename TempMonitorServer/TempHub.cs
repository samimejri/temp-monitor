using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TempMonitorServer
{
    public class TempHub : Hub
    {
        public async Task SendMessage(object message)
        {
            await Clients.All.SendAsync("TempMessage", message);
        }
    }
}