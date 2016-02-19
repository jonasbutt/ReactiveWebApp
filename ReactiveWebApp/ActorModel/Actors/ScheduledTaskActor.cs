using ActorModel.Messages;
using Akka.Actor;

namespace ActorModel.Actors
{
    public class ScheduledTaskActor : ReceiveActor
    {
        public ScheduledTaskActor()
        {
            Receive<RunTask>(message =>
            {
                var webClientMessenger = Context.ActorSelection("akka.tcp://reactive@localhost:33888/user/webClientMessenger");
                webClientMessenger.Tell(new SendMessage("Hello"));
            });
        }
    }
}