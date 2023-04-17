namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            
            List<string> correctEmails = new List<string>();

            correctEmails.Add("hello(aa)world@gmail.com");
            correctEmails.Add("example@example.com");
            correctEmails.Add("correct*address{one}@address.com(comment)");
            correctEmails.Add("$correct!address@(comment)post.com");

            List<string> nonCorectEmails = new List<string>();
            nonCorectEmails.Add("example@.com");
            nonCorectEmails.Add("hello((World@gmail.com");
            nonCorectEmails.Add(".noncorrect@gmail.com");

            List<string> result = correctEmails.Concat(nonCorectEmails).ToList();

            string text = $"Правильні та неправильні ел. адреси: {string.Join(" ", result)} в одному тексті";
            Console.WriteLine(text);
            Console.WriteLine();

            EmailsFinder emailsFinder = new EmailsFinder(text);
            emailsFinder.DivideEmails();

            Console.WriteLine("Правильні електронні адреси:");
            foreach (string email in emailsFinder.GetEmails())
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("\nЛексеми з символом @, але не є правильними електронними адресами:");
            foreach (string nonEmail in emailsFinder.GetNonEmails())
            {
                Console.WriteLine(nonEmail);
            }
        }           
    }
}