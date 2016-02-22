using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Reactive.ActorModel;
using Reactive.ActorModel.Messages;

namespace Reactive.Web
{
    [HubName("messagingHub")]
    public class WebClientMessagingHub : Hub
    {
        private readonly IWebClientMessenger webClientMessenger;

        public WebClientMessagingHub()
        {
            this.webClientMessenger = new WebClientMessenger();
        }

        public void SendMessage(SendMessage message)
        {
            this.webClientMessenger.SendMessageToOtherWebClients(message, this.Context.ConnectionId);
        }
    }
}