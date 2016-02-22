using System;
using Akka.Actor;
using Reactive.ActorModel.Messages;

namespace Reactive.ActorModel.Actors
{
    public class ScheduledTaskActor : ReceiveActor
    {
        private const string WebClientMessengerActorPath = "akka.tcp://reactive@localhost:33888/user/webClientMessenger";

        private Guid? taskId;
        private DateTime? started;

        public ScheduledTaskActor()
        {
            Receive<RunTask>(message =>
            {
                var webClientMessenger = Context.ActorSelection(WebClientMessengerActorPath);
                taskId = Guid.NewGuid();
                started = DateTime.UtcNow;
                webClientMessenger.Tell(new SendMessage("Started running task with ID " + taskId + " at " + started.Value.ToLongTimeString()));
            });

            Receive<UpdateStatus>(message =>
            {
                var webClientMessenger = Context.ActorSelection(WebClientMessengerActorPath);
                webClientMessenger.Tell(new SendMessage("Current task is ID " + taskId + " which started at " + started.Value.ToLongTimeString()));
            });
        }
    }
}