using System;
using System.Web;
using Akka.Actor;
using Reactive.ActorModel;
using Reactive.ActorModel.Messages;

namespace Reactive.Web
{
    public class ActorMessenger : IActorMessenger
    {
        private const string SchedulerActorPath = "akka.tcp://reactive@localhost:33999/user/scheduler";

        public void RequestStatusUpdate()
        {
            var actorSystem = GetActorSystem();
            var scheduler = actorSystem.ActorSelection(SchedulerActorPath);
            scheduler.Tell(new RequestStatusUpdate());
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