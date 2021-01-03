using EpamWinterTraining.ClientPart;
using EpamWinterTraining.ClientPart.LanguageTranslator;
using EpamWinterTraining.ServerPart;
using NUnit.Framework;

namespace TestingFourthTask
{
    [TestFixture]
    public class TestServer
    {
        [TestCase("let's check connection", Language.Russian, ExpectedResult = "let's check connection")]
        [TestCase("if you have some problem...", Language.Russian, ExpectedResult = "if you have some problem...")]
        [TestCase("я люблю с#", Language.English, ExpectedResult = "я люблю с#")]
        [TestCase("я живу в ./*+, в городе", Language.English, ExpectedResult = "я живу в ./*+, в городе")]
        public string ClientSendServerRequestAndGetResponce(string message, Language language)
        {
            var server = new Server();
            server.Start();
            var client = new Client() { MessagesLanguage = language };
            server.ApproveСonnection();
            client.SentRequest(message);
            server.Processing();
            string response = client.GetResponse();
            client.Close();
            server.Stop();
            return response;
        }
    }
}
