namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello\\. Hello. It <  <is a good-looking text... for testing?-testing my program.";
            Console.WriteLine(text);

            TextFormatter formatter = new();

            try
            {
                formatter = new TextFormatter(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (string word in formatter)
            {
                Console.WriteLine(word);
            }
        }
    }
}