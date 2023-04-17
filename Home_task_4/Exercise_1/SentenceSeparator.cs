using System.Text;

namespace Exercise_1
{
    internal static class SentenceSeparator
    {
        public static List<string> GetSentencesWithParentheses(List<string> text)
        {
            List<string> _separatedSentences = new List<string>();
            StringBuilder _sentence = new StringBuilder();

            foreach (string line in text)
            {
                foreach (char c in line)
                {
                    if (c == '.' || c == '!' || c == '?')
                    {
                        _sentence.Append(c);
                        _separatedSentences.Add(_sentence.ToString());
                        _sentence.Clear();
                    }
                    else
                    {
                        _sentence.Append(c);
                    }
                }
            }

            List<string> _sentencesWithBrackets = new List<string>();

            foreach (string s in _separatedSentences)
            {
                if (s.Contains("(") && s.Contains(")"))
                {
                    _sentencesWithBrackets.Add(s.ToString());
                }
            }

            return _sentencesWithBrackets;
        }
    }
}
