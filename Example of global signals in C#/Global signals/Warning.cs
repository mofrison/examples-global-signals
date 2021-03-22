namespace Global_signals
{
    /// <summary>
    /// Example of inheritance of a ready-made signal. It can only send signals from the parent class.
    /// </summary>
    class Warning : Error
    {
        private Warning(string text) : base("Warning: " + text) { }

        /// <summary>
        /// The method required to send the signal
        /// </summary>
        /// <param name="text">Sent data</param>
        public new static void Send(string text)
        {
            try
            {
                hendlers.Invoke(new Warning(text));
            }
            catch (System.NullReferenceException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
