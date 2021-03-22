using UnityEngine;

namespace ru.mofrison.global_signals
{
    public class Sender : MonoBehaviour
    {   
        /// <summary>
        /// Subscribe to the Error signal type
        /// </summary>
        private void Awake()
        {
            Error.Subscribe(ErrorHandling);
        }

        /// <summary>
        /// We send a message that the object is starting
        /// </summary>
        private void Start() 
        {
            Message.Send("Start " + name);
        }

        /// <summary>
        /// Processes the Error signal
        /// </summary>
        /// <param name="error">Reference to an object of the Error type</param>
        private void ErrorHandling(Error error)
        {
            Debug.Log(error.Text);
            Debug.LogWarning(string.Format("The {0} object will be deleted.", name));
            Destroy(gameObject);
        }

        /// <summary>
        /// Unsubscribes from the error signal when the object is destroyed
        /// </summary>
        private void OnDestroy()
        {
            Error.Unsubscribe(ErrorHandling);
            Message.Send("Destroy " + name);
        }
    }
}