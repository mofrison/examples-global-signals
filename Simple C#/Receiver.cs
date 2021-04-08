namespace ru.mofrison.GlobalSignals
{
    /// <summary>
    /// Example of a simple signal receiver
    /// </summary>
    class Receiver
    {
        public Receiver()
        {
            Message.Subscribe(StaticMetod);
            Message.Subscribe(OrdinaryMetod);
            Error.Subscribe(StaticMetod);
            Error.Subscribe(OrdinaryMetod);
        }

        private static void StaticMetod(Message message)
        {
            System.Console.WriteLine("Test static metod: " + message.Text);
        }

        private void OrdinaryMetod(Message message)
        {
            System.Console.WriteLine("Test ordinary metod: " + message.Text);
            Message.Unsubscribe(OrdinaryMetod);
        }

        private static void StaticMetod(Error error)
        {
            System.Console.WriteLine("Test static metod: " + error.Text);
        }

        private void OrdinaryMetod(Error error)
        {
            System.Console.WriteLine("Test ordinary metod: " + error.Text);
            Error.Unsubscribe(OrdinaryMetod);
        }
    }
}
