namespace Global_signals
{
    /// <summary>
    /// Example of a simple signal receiver
    /// </summary>
    class Receiver
    {
        public static void StaticMetod(Message message)
        {
            System.Console.WriteLine("Test static metod: " + message.Text);
        }

        public void OrdinaryMetod(Message message)
        {
            System.Console.WriteLine("Test ordinary metod: " + message.Text);
        }

        public static void ShowError(Error error)
        {
            System.Console.WriteLine(error.Text);
        }
    }
}
