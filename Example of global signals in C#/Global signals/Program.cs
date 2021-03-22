namespace Global_signals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create objects
            Receiver receiver = new Receiver();
            Sender sender = new Sender();
            Message.Subscribe((e) => { System.Console.WriteLine("Test lambda metod: " + e.Text); });


            // Sending a messages
            sender.SendMessage();
            sender.SendError();
            sender.SendWarning();
        }
    }
}
