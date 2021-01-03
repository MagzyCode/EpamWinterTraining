using EpamWinterTraining.ClientPart;
using EpamWinterTraining.ServerPart;
using NUnit.Framework;
using System;

namespace TestingFourthTask
{
    [TestFixture]
    public class TestMessageStore
    {
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(10, ExpectedResult = 10)]
        [TestCase(25, ExpectedResult = 25)]
        public int TestAdditionMessagesInMessagesStore(int numberOfMessages)
        {
            var messages = new string[numberOfMessages];
            for (int counter = 0; counter < numberOfMessages; counter++)
            {
                messages[counter] = Guid.NewGuid().ToString();
            }
            var server = new Server();
            server.Start();
            var client = new Client();
            server.ApproveСonnection();
            for (int counter = 0; counter < numberOfMessages; counter++)
            {
                client.SentRequest(messages[counter]);
                server.Processing();
            }
            client.Close();
            server.Stop();
            return server.ServerMessages.CountOfMessages;
        }
    }
}
