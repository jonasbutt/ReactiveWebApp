using System;
using Akka.Actor;

namespace ActorModel
{
    public interface IActorSystemService
    {
        void StartActorSystem(Action<ActorSystem> configure);

        ActorSystem GetActorSystem();

        void StopActorSystem();
    }
}