namespace Global_signals
{
    class Sender
    {
        public void SendMessage() {
            Message.Send("Hello, world!");
        }

        public void SendError() {
            Error.Send("Alarm!");
        }
        public void SendWarning() {
            Warning.Send("Attention!");
        }

    }
}
