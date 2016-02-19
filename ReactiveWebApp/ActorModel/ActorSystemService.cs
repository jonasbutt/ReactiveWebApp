using System;
using Akka.Actor;

namespace ActorModel
{
    public class ActorSystemService : IActorSystemService
    {
        private ActorSystem actorSystem;

        public void StartActorSystem()
        {
            actorSystem = ActorSystem.Create("reactive");
        }

        public ActorSystem GetActorSystem()
        {
            return actorSystem;
        }

        public void StopActorSystem()
        {
            actorSystem.Terminate();
            actorSystem.WhenTerminated.Wait(TimeSpan.FromSeconds(2));
        }
    }
}