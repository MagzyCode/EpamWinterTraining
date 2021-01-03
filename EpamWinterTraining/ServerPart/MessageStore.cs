using System;
using System.Collections.Generic;
using System.Text;

namespace EpamWinterTraining.ServerPart
{
    public class MessageStore
    {
        /// <summary>
        /// List of client messages.
        /// </summary>
        public List<string> ServerMassages { get; private set; } = new List<string>();

        /// <summary>
        /// Returns the number of messages received by the server during operation.
        /// </summary>
        public int CountOfMessages
        {
            get
            {
                return ServerMassages.Count;
            }
        }

        /// <summary>
        /// Adds a message to the general list of client requests.
        /// </summary>
        /// <param name="message">The client message.</param>
        public void Add(string message)
        {
            var massageTimeMark = DateTime.Now;
            var newServerMassage = $"{massageTimeMark}:{message}";
            ServerMassages.Add(newServerMassage);
        }

        public override string ToString()
        {
            var result = string.Join('\n', ServerMassages);
            return result;
        }
    }
}
