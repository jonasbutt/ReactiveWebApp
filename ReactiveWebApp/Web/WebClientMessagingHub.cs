using System;
using System.Web;
using Akka.Actor;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Reactive.ActorModel;
using Reactive.ActorModel.Messages;

namespace Reactive.Web
{
    [HubName("messagingHub")]
    public class WebClientMessagingHub : Hub
    {
        public void SendMessage(SendMessage message)
        {
            Clients.Others.sendMessage(message);
        }

        private static ActorSystem GetActorSystem()
        {
            var actorSystemServiceObject = HttpContext.Current.Application["ActorSystemService"];
            if (actorSystemServiceObject is IActorSystemService)
            {
                var actorSystemService = actorSystemServiceObject as IActorSystemService;
                return actorSystemService.GetActorSystem();
            }
            else
            {
                throw new InvalidOperationException("ActorSystemService not found.");
            }
        }
    }
}