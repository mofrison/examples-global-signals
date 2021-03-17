namespace Global_signals
{
    /// <summary>
    /// A base class that is used to implement the mechanism for subscribing to signals.
    /// Supports adding multiple subscribers as delegates at once. 
    /// A delegate can be added multiple times. This will result in multiple calls to the same delegate.
    /// </summary>
    /// <typeparam name="T">Extended from Signal<T></typeparam>
    public abstract class Signal<T> where T : Signal<T>
    {
        public delegate void Hendler(T signal);
        protected static Hendler hendlers;

        /// <summary>
        /// Adds delegates
        /// </summary>
        /// <param name="hendlers">Reference to a method or delegates</param>
        public static void Subscribe(Hendler hendlers)
        {
            Signal<T>.hendlers += hendlers;
        }

        /// <summary>
        /// Removes delegates
        /// </summary>
        /// <param name="hendlers">Reference to a method or delegates</param>
        public static void Unsubscribe(Hendler hendlers)
        {
            Signal<T>.hendlers -= hendlers;
        }

        /// <summary>
        /// Exception generated if no one is subscribed to it at the time of sending the signal.
        /// </summary>
        public class Exception : System.Exception
        {
            public Exception(string message) : base(message)
            { }
        }
    }
}
