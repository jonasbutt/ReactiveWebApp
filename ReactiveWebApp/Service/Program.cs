using Akka.Actor;
using Reactive.ActorModel;
using Reactive.ActorModel.Actors;
using Reactive.ActorModel.Messages;
using Topshelf;

namespace Reactive.Service
{
    class Program
    {
        static void Main()
        {
            #if DEBUG
            var service = new ActorSystemService();
            service.StartActorSystem(ConfigureActorSystem);
            service.GetActorSystem().WhenTerminated.Wait();
            #endif

            #if !DEBUG
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<IActorSystemService>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(service => new ActorSystemService());
                    serviceConfigurator.WhenStarted(service => service.StartActorSystem(ConfigureActorSystem));
                    serviceConfigurator.WhenStopped(service => service.StopActorSystem());
                });

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.StartAutomatically();

                hostConfigurator.SetDescription("Reactive Service");
                hostConfigurator.SetDisplayName("Reactive Service");
                hostConfigurator.SetServiceName("ReactiveService");
            });
            #endif
        }

        private static void ConfigureActorSystem(ActorSystem actorSystem)
        {
            var scheduler = actorSystem.ActorOf(Props.Create<SchedulerActor>(), "scheduler");
            scheduler.Tell(new StartScheduler());
        }
    }
}