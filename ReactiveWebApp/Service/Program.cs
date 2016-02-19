using ActorModel;
using ActorModel.Actors;
using ActorModel.Messages;
using Akka.Actor;
using Topshelf;

namespace Service
{
    class Program
    {
        static void Main()
        {
            //var service = new ActorSystemService();
            //service.StartActorSystem(ConfigureActorSystem);
            //service.GetActorSystem().WhenTerminated.Wait();

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
        }

        private static void ConfigureActorSystem(ActorSystem actorSystem)
        {
            var scheduler = actorSystem.ActorOf(Props.Create<SchedulerActor>(), "scheduler");
            scheduler.Tell(new StartScheduler());
        }
    }
}