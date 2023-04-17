namespace Exercise_1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            List<string> textInEnglish = new List<string>()
            {
                "This is a sentence!",
                "This is the second sentence ",
                "with parentheses inside (It is the text inside parentheses), ",
                "so it is the sample for my program.This ",
                "is the third sentence ",
                "with parentheses in the end (we are here).",
                "This is the fourth sentence without parentheses.",
                "(Also you can start your sentence with parentheses) And it is an ",
                "example of it."
            };

            List<string> textInUkrainian = new List<string>()
            {
                "Це речення!",
                "Це друге речення ",
                "з дужками всередині (це текст всередині дужок), ",
                "тому це приклад для моєї програми.Це ",
                "третє речення ",
                "з дужками всередині у кінці (ми тут).",
                "Це четверте речення без дужок.",
                "(Також ви можете починати ваше речення з дужками) І це цьому ",
                "приклад."
            };


            List<string> englishParanthesis = SentenceSeparator.GetSentencesWithParentheses(textInEnglish);
            List<string> ukrainianParanthesis = SentenceSeparator.GetSentencesWithParentheses(textInUkrainian);
            
            foreach (string sentance in englishParanthesis)
                Console.WriteLine(sentance);

            Console.WriteLine();

            foreach (string sentance in ukrainianParanthesis)
                Console.WriteLine(sentance);
        }
    }
}