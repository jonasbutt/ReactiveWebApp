namespace Reactive.ActorModel
{
    public interface IWebClientMessenger
    {
        void SendMessageToAllWebClients<TMessage>(TMessage message);
    }
}