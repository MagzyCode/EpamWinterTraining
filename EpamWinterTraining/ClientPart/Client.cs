using EpamWinterTraining.ClientPart.LanguageTranslator;
using System;
using System.Net.Sockets;
using System.Text;

namespace EpamWinterTraining.ClientPart
{
    /// <summary>
    /// Represents the client interacting with the server.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Event for transmitting a message to all subscribers.
        /// </summary>
        private event Action<string> NotifyEvent;

        /// <summary>
        /// Initializes a Client type object using the DNS name and port of the remote host.
        /// </summary>
        /// <param name="ip">DNS name of the remote host that you plan to connect to.</param>
        /// <param name="port">Port name of the remote host to connect to.</param>
        public Client(string ip = "127.0.0.1", int port = 1)
        {
            TcpClient.Connect(ip, port);
        }

        /// <summary>
        /// The message flow between the client and the server.
        /// </summary>
        public NetworkStream ClientConnectionStream { get; private set; }

        /// <summary>
        /// Provides client connections for TCP network service.
        /// </summary>
        public TcpClient TcpClient { get; private set; } = new TcpClient();

        /// <summary>
        /// Specifies the language of the message sent to the server.
        /// </summary>
        public Language MessagesLanguage { get; set; } = Language.English;

        /// <summary>
        /// Method for getting a response from the server.
        /// </summary>
        /// <returns>A message received from the server and translated into transliteration.</returns>
        public string GetResponse()
        {
            var data = new byte[256];
            int bytes = ClientConnectionStream.Read(data, 0, data.Length);
            string message = Encoding.UTF8.GetString(data, 0, bytes);
            string translitMessage = TranslitTranslater.ConvertToTranslit(message, MessagesLanguage);
            NotifyEvent?.Invoke(translitMessage);
            return translitMessage;
        }

        /// <summary>
        /// Sends a request to the server.
        /// </summary>
        /// <param name="request">Request string to the server.</param>
        public void SentRequest(string request)
        {
            var data = Encoding.UTF8.GetBytes(request);
            ClientConnectionStream = TcpClient.GetStream();
            ClientConnectionStream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Closes all threads involved by the object.
        /// </summary>
        public void Close()
        {
            TcpClient.Close();
            ClientConnectionStream.Close();
        }

        /// <summary>
        /// Adding a new subscriber to a client event.
        /// </summary>
        /// <param name="subscriber">The subscriber to the event.</param>
        public void AddSubscriber(Action<string> subscriber) => NotifyEvent += subscriber;

        /// <summary>
        /// Deleting a subscriber from a client event.
        /// </summary>
        /// <param name="subscriber">The subscriber to the event.</param>
        public void DeleteSubscriber(Action<string> subscriber) => NotifyEvent -= subscriber;
    }
}
