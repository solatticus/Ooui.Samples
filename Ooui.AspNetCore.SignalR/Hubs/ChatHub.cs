using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Ooui.AspNetCore.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            // send the message to all connected clients
            await Clients.All.SendAsync("Send", Context.User.Identity.Name, message);
        }
    }
}
