using System;
using System.Web;
using ActorModel;
using Akka.Actor;
using Microsoft.AspNet.SignalR;

namespace Web
{
    public class MessageHub : Hub
    {
        public void SendMessage(string message)
        {
            var actorSystem = GetActorSystem();
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