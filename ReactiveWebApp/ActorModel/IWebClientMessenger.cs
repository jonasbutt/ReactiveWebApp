namespace Reactive.ActorModel
{
    public interface IWebClientMessenger
    {
        void SendMessageToAllWebClients<TMessage>(TMessage message);

        void SendMessageToOtherWebClients<TMessage>(TMessage message, string currentWebClientId);
    }
}