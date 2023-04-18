using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal class MyString
    {
        private string _text;

        public MyString(string text)
        {
            _text = text;
        }

        public string Data
        {
            get { return _text; }
            set 
            { 
                if (value != null)
                {
                    _text = value;
                }
            }
        }

        public string? ReplaceDoubleLetterWords(string replacementText)
        {
            if (replacementText != null)
            {
                string[] words = _text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (HasDoubleLetter(words[i]))
                    {
                        words[i] = replacementText;
                    }
                }
                // загублено початковий розподіл пробільних символів.
                return string.Join(' ', words);
            }
            else
                // Якщо слів не знайдено текст має залишитись незмінним.
                return null;
        }

        static bool HasDoubleLetter(string word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        public int? FindSecondEntry(string subString) // a) Find the index of the second occurrence of the substring
        {
            int firstIndex = _text.IndexOf(subString);

            if (firstIndex == -1)
            {
                return null;
            }
            else
            {
                int secondIndex = _text.IndexOf(subString, firstIndex + 1);
                if (secondIndex == -1)
                {
                    return null;
                }
                else
                {
                    return secondIndex;
                }
            }

        }

        public int CountWordsStartingWithUppercase(string text)
        {
            int count = 0;
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
               if (!string.IsNullOrEmpty(words[i]) && char.IsUpper(words[i][0]))
               {
                   count++;
               }
            }
            return count;
        }
    }
}
