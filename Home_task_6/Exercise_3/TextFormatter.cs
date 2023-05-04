using System.Collections;

namespace Exercise_3
{
    internal class TextFormatter : IEnumerable
    {
        private static readonly char[] Separators = { ' ', '.', ',', ';', ':', '!', '?', '+', '-', '(', ')', '[', ']', '{', '}', '<', '>', '/', '\\', '*' };
        private string _text;

        public TextFormatter()
        {
            _text = "";
        }
        public TextFormatter(string text)
        {
            if (text is null || text is "")
            {
                throw new ArgumentNullException(nameof(text), "Input text is null or empty.");
            }
            _text = text;
        }

        public IEnumerator GetEnumerator()
        {
            HashSet<string> uniqueWords = new HashSet<string>();
            HashSet<string> repeatedWords = new HashSet<string>();

            string[] words = _text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (uniqueWords.Contains(word))
                {
                    repeatedWords.Add(word);
                }
                else
                {
                    uniqueWords.Add(word);
                   //І тут же треба  yield return word;
                }
            }

            foreach (string word in uniqueWords)
            {
                if (!repeatedWords.Contains(word))
                {
                    yield return word;
                }
            }
        }
    }
}
