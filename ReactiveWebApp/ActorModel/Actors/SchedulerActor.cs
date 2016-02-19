using System;
using ActorModel.Messages;
using Akka.Actor;

namespace ActorModel.Actors
{
    public class SchedulerActor : ReceiveActor
    {
        public SchedulerActor()
        {
            IActorRef scheduledTask;

            Receive<StartScheduler>(message =>
            {
                scheduledTask = Context.ActorOf(Props.Create(typeof(ScheduledTaskActor)), "scheduledTask");
                Context.System.Scheduler.ScheduleTellRepeatedly(
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(5),
                    scheduledTask,
                    new RunTask(),
                    Self);
            });

            Receive<RequestStatusUpdate>(message =>
            {
            });

            Receive<UpdateStatus>(message =>
            {
            });
        }
    }
}