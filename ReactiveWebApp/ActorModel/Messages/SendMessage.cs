namespace ActorModel.Messages
{
    public class SendMessage
    {
        public SendMessage(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}