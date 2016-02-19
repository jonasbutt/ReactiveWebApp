using System;
using Akka.Actor;

namespace Reactive.ActorModel
{
    public interface IActorSystemService
    {
        void StartActorSystem(Action<ActorSystem> configure);

        ActorSystem GetActorSystem();

        void StopActorSystem();
    }
}