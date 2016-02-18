using Microsoft.AspNet.SignalR;

namespace Web
{
    public class MessageHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.Others.sendMessage(message);
        }
    }
}