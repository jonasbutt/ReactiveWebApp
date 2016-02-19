using System;
using Akka.Actor;

namespace ActorModel
{
    public class ActorSystemService : IActorSystemService
    {
        private ActorSystem actorSystem;

        public void StartActorSystem(Action<ActorSystem> configure)
        {
            actorSystem = ActorSystem.Create("reactive");
            configure(actorSystem);
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