namespace Exercise_2
{
    internal class Program
    {// До діаграми. Початок добрий. Але як комунікує користувач з вежею і чи комунікує. Чому у нього не має методу взяти воду.Хто створює користувачів у системі. загалом методи класу не продумані. Де валідуються дані.
        
        static void Main(string[] args)
        {
            string inputText = "The quick brown fox jjumps over the lazy dog. The lazy dog jumps over the quick brown fox. Dog";
            string subString = "the";
            string replacementText = "jumped";

            MyString myString = new MyString(inputText);

            // a) Find the index of the second occurrence of the substring
            int? secondIndex = myString.FindSecondEntry(subString);
            Console.WriteLine($"Index of the second occurrence of the substring: {secondIndex}");


            // b) Count the number of words that start with an uppercase letter
            int count = myString.CountWordsStartingWithUppercase(inputText);
            Console.WriteLine($"Number of words starting with uppercase letter: {count}");


            // c) Replace all words containing a double letter with the replacement text        
            Console.WriteLine($"Text with replaced words:\n{myString.ReplaceDoubleLetterWords(replacementText)}");
        }
    }
}
