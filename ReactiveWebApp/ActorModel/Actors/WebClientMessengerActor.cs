using Akka.Actor;
using Reactive.ActorModel.Messages;

namespace Reactive.ActorModel.Actors
{
    public class WebClientMessengerActor : ReceiveActor
    {
        public WebClientMessengerActor(IWebClientMessenger webClientMessenger)
        {
            Receive<SendMessage>(message =>
            {
                webClientMessenger.SendMessageToAllWebClients(message);
            });
        }
    }
}