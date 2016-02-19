using Microsoft.AspNet.SignalR;
using Owin;

namespace Reactive.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/s", new HubConfiguration());
        }
    }
}