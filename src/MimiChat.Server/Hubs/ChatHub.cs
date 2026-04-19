using Microsoft.AspNetCore.SignalR;

namespace MimiChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string user, string message)
        {
            Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
