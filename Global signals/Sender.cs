namespace Global_signals
{
    class Sender
    {
        static void Main(string[] args)
        {
            // Creating a set of delegates
            var hendlers = new Signal<Message>.Hendler(Receiver.StaticMetod);
            hendlers += new Signal<Message>.Hendler(new Receiver().OrdinaryMetod);

            // Subscribing delegates to a messages
            Message.Subscribe(new Receiver().OrdinaryMetod);
            Message.Subscribe(Receiver.StaticMetod);
            Message.Subscribe(hendlers);

            // Sending a message
            Message.Send("Hello, world!");

            // Unsubscribing delegates from messages
            Message.Unsubscribe(hendlers);
            Message.Unsubscribe(Receiver.StaticMetod);
            Message.Unsubscribe(new Receiver().OrdinaryMetod);

            // Example with inheritance from another signal and with unique delegates.
            Error.Subscribe(Receiver.ShowError);
            Warning.Subscribe(Receiver.ShowError);
            Error.Send("Error!");
            Warning.Send("Error!");
            Error.Unsubscribe(Receiver.ShowError);
            Warning.Unsubscribe(Receiver.ShowError);
        }
    }
}
