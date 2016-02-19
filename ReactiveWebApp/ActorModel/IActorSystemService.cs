using Akka.Actor;

namespace ActorModel
{
    public interface IActorSystemService
    {
        void StartActorSystem();

        ActorSystem GetActorSystem();

        void StopActorSystem();
    }
}