using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Reactive.ActorModel;

namespace Reactive.Web
{
    public class WebClientMessenger : IWebClientMessenger
    {
        private readonly IHubContext messagingHubContext;

        public WebClientMessenger()
        {
            messagingHubContext = GlobalHost.ConnectionManager.GetHubContext<WebClientMessagingHub>();
        }

        public void SendMessageToAllWebClients<TMessage>(TMessage message)
        {
            SendMessage<TMessage>(message, messagingHubContext.Clients.All);
        }

        private void SendMessage<TMessage>(TMessage message, IClientProxy messageHub)
        {
            var messageType = typeof(TMessage);
            var methodName = messageType.Name;
            var methodNameLowercased = methodName.First().ToString().ToLowerInvariant() + methodName.Substring(1);
            messageHub.Invoke(methodNameLowercased, message);
        }
    }
}