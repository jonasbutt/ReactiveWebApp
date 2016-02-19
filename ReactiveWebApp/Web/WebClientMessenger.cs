using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Reactive.ActorModel;

namespace Reactive.Web
{
    public class WebClientMessenger : IWebClientMessenger
    {
        private readonly IHubContext messageHubContext;

        public WebClientMessenger()
        {
            messageHubContext = GlobalHost.ConnectionManager.GetHubContext<WebClientMessagingHub>();
        }

        public void SendMessageToAllWebClients<TMessage>(TMessage message)
        {
            SendMessage<TMessage>(message, messageHubContext.Clients.All);
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
