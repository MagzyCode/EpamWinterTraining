using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace EpamWinterTraining.ServerPart
{
    public class Server
    {
        /// <summary>
        /// Represents a client working with the server in real time.
        /// </summary>
        private TcpClient _client;

        /// <summary>
        /// Event for transmitting a message to all subscribers.
        /// </summary>
        private event Action<string> NotifyEvent;

        /// <summary>
        /// Initializes a TcpListener object using the local ip and connection port.
        /// </summary>
        /// <param name="hostname">Initializes a TcpListener object using the local ip and connection port.</param>
        /// <param name="port">The port on which you are waiting for incoming connection attempts.</param>
        public Server(string hostname = "127.0.0.1", int port = 1)
        {
            ServerIp = IPAddress.Parse(hostname);
            TcpListener = new TcpListener(ServerIp, port);
        }

        /// <summary>
        /// The port on which you are waiting for incoming connection attempts.
        /// </summary>
        public MessageStore ServerMessages { get; private set; } = new MessageStore();

        /// <summary>
        /// Listens for connections from TCP clients on the network.
        /// </summary>
        public TcpListener TcpListener { get; private set; }

        /// <summary>
        /// Local IP of the server.
        /// </summary>
        public IPAddress ServerIp { get; private set; }

        /// <summary>
        /// Server startup.
        /// </summary>
        public void Start() => TcpListener.Start();

        /// <summary>
        /// The shutdown of the server.
        /// </summary>
        public void Stop() => TcpListener.Stop();

        /// <summary>
        /// Confirmation of an incoming message from the client.
        /// </summary>
        public void ApproveСonnection()
        {
            _client = TcpListener.AcceptTcpClient();
        }

        /// <summary>
        /// Server processing of client messages.
        /// </summary>
        public void Processing()
        {
            var bytes = new byte[256];
            var stream = _client.GetStream();
            var count = stream.Read(bytes, 0, bytes.Length);

            if (count != 0)
            {
                var clientMessage = Encoding.UTF8.GetString(bytes);
                // Removes empty cells.
                clientMessage = Regex.Replace(clientMessage, @"\0", "");
                ServerMessages.Add(clientMessage);
                NotifyEvent?.Invoke(clientMessage);
                var response = Encoding.UTF8.GetBytes(clientMessage);
                stream.Write(response, 0, response.Length);
            }

        }

        /// <summary>
        /// Adding a new subscriber to a server event.
        /// </summary>
        /// <param name="subscriber">The subscriber to the event.</param>
        public void AddSubscriber(Action<string> subscriber) => NotifyEvent += subscriber;

        /// <summary>
        /// Deleting a subscriber from a server event.
        /// </summary>
        /// <param name="subscriber">The subscriber to the event.</param>
        public void DeleteSubscriber(Action<string> subscriber) => NotifyEvent -= subscriber;


    }
}
