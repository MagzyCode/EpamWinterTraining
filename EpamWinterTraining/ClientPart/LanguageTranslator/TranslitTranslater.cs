using System;
using System.Collections.Generic;
using System.Text;

namespace EpamWinterTraining.ClientPart.LanguageTranslator
{
    public static class TranslitTranslater
    {
        /// <summary>
        /// Translates letters into English transliteration.
        /// </summary>
        /// <param name="letter">Letter for transliteration.</param>
        /// <returns>
        /// Returns the English transliteration. If the 
        /// corresponding letter is not found, a string 
        /// representation of the same letter is returned.
        /// </returns>
        public static string ToEnglishTranslit(char letter) => letter switch
        {
            'а' => "a",
            'б' => "b",
            'в' => "v",
            'г' => "g",
            'д' => "d",
            'е' => "e",
            'ё' => "e",
            'ж' => "j",
            'з' => "z",
            'и' => "i",
            'й' => "i",
            'к' => "k",
            'л' => "l",
            'м' => "m",
            'н' => "n",
            'о' => "o",
            'п' => "p",
            'р' => "r",
            'с' => "s",
            'т' => "t",
            'у' => "u",
            'ф' => "f",
            'х' => "h",
            'ц' => "c",
            'ч' => "ch",
            'ш' => "sh",
            'щ' => "sc",
            'ы' => "y",
            'э' => "e",
            'ю' => "iu",
            'я' => "ia",
            _ => letter.ToString()
        };

        /// <summary>
        /// Translates letters into Russian transliteration.
        /// </summary>
        /// <param name="letter">Letter for transliteration.</param>
        /// <returns>
        /// Returns the Russian... transliteration. If the 
        /// corresponding letter is not found, a string 
        /// representation of the same letter is returned.
        /// </returns>
        public static string ToRussianTranslit(char letter) => letter switch
        {
            'a' => "а",
            'b' => "б",
            'c' => "к",
            'd' => "д",
            'e' => "и",
            'f' => "ф",
            'g' => "дж",
            'h' => "х",
            'i' => "и",
            'j' => "дж",
            'k' => "к",
            'l' => "л",
            'm' => "м",
            'n' => "н",
            'o' => "о",
            'p' => "п",
            'q' => "кью",
            'r' => "р",
            's' => "с",
            't' => "т",
            'u' => "ю",
            'v' => "в",
            'w' => "уи",
            'x' => "х",
            'y' => "уай",
            'z' => "з",
            _ => letter.ToString()
        };

        /// <summary>
        /// Converts the message according to the selected language.
        /// </summary>
        /// <param name="message">The client message.</param>
        /// <param name="language">It's the language of the client message.</param>
        /// <returns></returns>
        public static string ConvertToTranslit(string message, Language language)
        {
            var lowerMessage = message.ToLower();
            var translitMessage = new StringBuilder();
            for (int counter = 0; counter < lowerMessage.Length; counter++)
            {
                var letter = GetTranslitLetter(lowerMessage[counter], language);
                translitMessage.Append(letter);
            }

            var result = translitMessage.ToString();
            return result.ToString();
        }

        /// <summary>
        /// Converts a letter to a transliterated string.
        /// </summary>
        /// <param name="letter">Translates letters into transliteration.</param>
        /// <param name="language">It's the language of the letter</param>
        /// <returns></returns>
        private static string GetTranslitLetter(char letter, Language language) => language switch
        {
            Language.English => ToRussianTranslit(letter),
            Language.Russian => ToEnglishTranslit(letter),
            _ => throw new Exception()
        };
    }
}
