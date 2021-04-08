namespace ru.mofrison.GlobalSignals
{
    class Sender
    {
        public void SendMessage() {
            try { Message.Send("Hello, world!"); }
            catch (Message.Exception e) { System.Console.WriteLine("Error: " + e.Message); }
        }

        public void SendError() {
            try { Error.Send("Alarm!"); }
            catch (Error.Exception e) { System.Console.WriteLine("Error: " + e.Message); }
        }

        public void SendWarning() {
            try { Warning.Send("Attention!"); }
            catch (Warning.Exception e) { System.Console.WriteLine("Error: " + e.Message); }
        }
    }
}
