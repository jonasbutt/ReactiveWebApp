using System.Web;
using ActorModel;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebAppConfigurator.Configure();

            var actorSystemService = new ActorSystemService();
            actorSystemService.StartActorSystem();
            Application["ActorSystemService"] = actorSystemService;
        }

        protected void Application_End()
        {
            var actorSystemServiceObject = Application["ActorSystemService"];
            if (actorSystemServiceObject is IActorSystemService)
            {
                var actorSystemService = actorSystemServiceObject as IActorSystemService;
                actorSystemService.StopActorSystem();
            }
        }
    }
}