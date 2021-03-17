namespace Global_signals
{
    /// <summary>
    /// A simple example of signal implementation
    /// </summary>
    public class Message : Signal<Message>
    {
        private string text;
        public string Text { get => text; }

        private Message(string text)
        {
            this.text = text;
        }

        /// <summary>
        /// The method required to send the signal
        /// </summary>
        /// <param name="text">Sent data</param>
        public static void Send(string text)
        {
            try
            {   // Calls delegates that accept this type as a parameter
                hendlers.Invoke(new Message(text));
            }
            catch (System.NullReferenceException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
