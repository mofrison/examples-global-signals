using UnityEngine;

namespace ru.mofrison.GlobalSignals
{
    public class Receiver : MonoBehaviour
    {
        /// <summary>
        /// Subscribe to the Message signal type
        /// </summary>
        private void Awake()
        {
            Message.Subscribe(MessageHandling);
        }

        /// <summary>
        /// Processes the Error signal
        /// </summary>
        /// <param name="error">Reference to an object of the Message type</param>
        private void MessageHandling(Message message)
        {
            Debug.Log(message.Text);
            try
            {
                Error.Send("It's okay, the message has been received");
            }
            catch (Signal<Error>.Exception e)
            {
                Debug.LogError(string.Format(
                    "Messages of the {0} object are not signed by anyone, so you can delete it.", name));
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Unsubscribes from the Message signal when the object is destroyed
        /// </summary>
        private void OnDestroy()
        {
            Message.Unsubscribe(MessageHandling);
            Debug.Log("Destroy " + name);
        }
    }
}