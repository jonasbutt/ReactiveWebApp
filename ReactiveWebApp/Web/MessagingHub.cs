using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Reactive.ActorModel;
using Reactive.ActorModel.Messages;

namespace Reactive.Web
{
    [HubName("messagingHub")]
    public class MessagingHub : Hub
    {
        private readonly IWebClientMessenger webClientMessenger;
        private readonly IActorMessenger actorMessenger;

        public MessagingHub()
        {
            this.webClientMessenger = new WebClientMessenger();
            this.actorMessenger = new ActorMessenger();
        }

        public void SendMessage(SendMessage message)
        {
            this.webClientMessenger.SendMessageToOtherWebClients(message, this.Context.ConnectionId);
        }

        public void RequestStatusUpdate()
        {
            this.actorMessenger.RequestStatusUpdate();
        }
    }
}