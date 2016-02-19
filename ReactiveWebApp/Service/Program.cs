using ActorModel;
using Topshelf;

namespace Service
{
    class Program
    {
        static void Main()
        {
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<IActorSystemService>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(service => new ActorSystemService());
                    serviceConfigurator.WhenStarted(service => service.StartActorSystem());
                    serviceConfigurator.WhenStopped(service => service.StopActorSystem());
                });

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.StartAutomatically();

                hostConfigurator.SetDescription("Reactive Service");
                hostConfigurator.SetDisplayName("Reactive Service");
                hostConfigurator.SetServiceName("ReactiveService");
            });
        }
    }
}