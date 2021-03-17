using System.Collections.Generic;

namespace Global_signals
{
    /// <summary>
    /// A more complex example of signal implementation. Adds only unique methods as delegates.
    /// </summary>
    public class Error : Signal<Error>
    {
        private string text;
        private static HashSet<int> hashs = new HashSet<int>();
        public string Text { get => text; }

        public Error(string text)
        {
            this.text = text;
        }

        /// <summary>
        /// Overrides a similar method of the base class.
        /// Checks whether the delegate being added is present in the list of already added delegates.
        /// </summary>
        /// <param name="hendlers">Reference to a method or delegates</param>
        public new static void Subscribe(Hendler hendlers)
        {
            foreach (Hendler hendler in hendlers.GetInvocationList())
            {
                var hash = System.String.GetHashCode(hendler.Method.DeclaringType + "" + hendler.Method.GetBaseDefinition());
                if (!hashs.Contains(hash))
                {
                    Signal<Error>.hendlers += hendler;
                    hashs.Add(hash);
                }
            }
        }

        /// <summary>
        /// Overrides a similar method of the base class.
        /// Checks whether the delegate being added is present in the list of already added delegates.
        /// </summary>
        /// <param name="hendlers">Reference to a method or delegates</param>
        public new static void Unsubscribe(Hendler hendlers)
        {
            foreach (Hendler hendler in hendlers.GetInvocationList())
            {
                var hash = System.String.GetHashCode(hendler.Method.DeclaringType + "" + hendler.Method.GetBaseDefinition());
                if (hashs.Contains(hash))
                {
                    Signal<Error>.hendlers -= hendler;
                    hashs.Remove(hash);
                }
            }
        }

        /// <summary>
        /// The method required to send the signal
        /// </summary>
        /// <param name="text">Sent data</param>
        public static void Send(string text)
        {
            try
            {
                hendlers.Invoke(new Error(text));
            }
            catch (System.NullReferenceException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
