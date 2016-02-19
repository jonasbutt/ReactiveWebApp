using ActorModel.Messages;
using Akka.Actor;

namespace ActorModel.Actors
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