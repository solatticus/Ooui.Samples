using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Ooui.AspNetCore.SignalR.Hubs
{
    public class ChatHub : Hub
    {
		public override async Task OnConnectedAsync()
		{
            Console.WriteLine($@"Server| OnConnectedAsync From:{Context.ConnectionId}");

            // let other connections know someone joined
            await Clients.All.SendAsync("UserJoined", this.Context.ConnectionId);
		}

		public async Task Send(string message)
        {
            Console.WriteLine($@"Server| Send From:{Context.ConnectionId} Message:{message}  ");

            // send the message to all connected clients
            await Clients.All.SendAsync("Send", Context.ConnectionId, message);

            //TODO: Implement users/identity
        }
    }
}
