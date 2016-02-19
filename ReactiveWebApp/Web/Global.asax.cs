using System.Web;
using ActorModel;
using ActorModel.Actors;
using Akka.Actor;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebAppConfigurator.Configure();

            var actorSystemService = new ActorSystemService();
            actorSystemService.StartActorSystem(ConfigureActorSystem);
            Application["ActorSystemService"] = actorSystemService;
        }

        private static void ConfigureActorSystem(ActorSystem actorSystem)
        {
            actorSystem.ActorOf(Props.Create<WebClientMessengerActor>(new WebClientMessenger()), "webClientMessenger");
        }

        protected void Application_End()
        {
            var actorSystemServiceObject = Application["ActorSystemService"];
            if (actorSystemServiceObject is IActorSystemService)
            {
                var actorSystemService = actorSystemServiceObject as IActorSystemService;
                actorSystemService.StopActorSystem();
            }
            Application["ActorSystemService"] = null;
        }
    }
}