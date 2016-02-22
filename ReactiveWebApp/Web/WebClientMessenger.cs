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
            messagingHubContext = GlobalHost.ConnectionManager.GetHubContext<MessagingHub>();
        }

        public void SendMessageToAllWebClients<TMessage>(TMessage message)
        {
            SendMessage(message, messagingHubContext.Clients.All);
        }

        public void SendMessageToOtherWebClients<TMessage>(TMessage message, string currentWebClientId)
        {
             SendMessage(message, messagingHubContext.Clients.AllExcept(currentWebClientId));
        }

        private static void SendMessage<TMessage>(TMessage message, IClientProxy messageHub)
        {
            var messageType = typeof(TMessage);
            var methodName = messageType.Name;
            var methodNameLowercased = methodName.First().ToString().ToLowerInvariant() + methodName.Substring(1);
            messageHub.Invoke(methodNameLowercased, message);
        }
    }
}
