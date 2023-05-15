namespace Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ChildClass child = new ChildClass();

            // Підписка на подію
            child.OnEventHappened += (message) =>
            {
                Console.WriteLine($"Подія відбулась з повідомленням: {message}");
            };

            // Генерувати подію
            child.GenerateEvent("Привіт, світ!");
        }
    }
}