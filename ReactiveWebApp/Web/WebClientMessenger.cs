using System;
using System.Linq;
using ActorModel;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Web
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
            //var type = messageHub.GetType();
            //var method = type.GetMethod(methodNameLowercased);
            //method.Invoke(messageHub, new object[] { message });
        }
    }
}