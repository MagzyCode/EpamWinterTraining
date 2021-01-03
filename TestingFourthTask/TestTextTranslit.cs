using EpamWinterTraining.ClientPart.LanguageTranslator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingFourthTask
{
    [TestFixture]   
    public class TestTextTranslit
    {
        [TestCase("миша", Language.Russian, ExpectedResult = "misha")]
        [TestCase("Natalia", Language.English, ExpectedResult = "наталиа")]
        [TestCase("Давай что-то посложнее", Language.Russian, ExpectedResult = "davai chto-to poslojnee")]
        public string ConvertToTranslit_RussianString_TranslitEnglishString(string testString, Language language)
        {
            var result = TranslitTranslater.ConvertToTranslit(testString, language);
            return result;
        }
    }
}
