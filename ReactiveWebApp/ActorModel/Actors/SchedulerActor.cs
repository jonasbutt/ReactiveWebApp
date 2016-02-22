using System;
using Akka.Actor;
using Reactive.ActorModel.Messages;

namespace Reactive.ActorModel.Actors
{
    public class SchedulerActor : ReceiveActor
    {
        IActorRef scheduledTask;

        public SchedulerActor()
        {
            Receive<StartScheduler>(message =>
            {
                scheduledTask = Context.ActorOf(Props.Create(typeof(ScheduledTaskActor)), "scheduledTask");
                Context.System.Scheduler.ScheduleTellRepeatedly(
                    TimeSpan.FromSeconds(15),
                    TimeSpan.FromSeconds(15),
                    scheduledTask,
                    new RunTask(),
                    Self);
            });

            Receive<RequestStatusUpdate>(message =>
            {
                scheduledTask.Tell(new UpdateStatus());
            });
        }
    }
}