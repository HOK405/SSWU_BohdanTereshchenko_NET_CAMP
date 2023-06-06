namespace Exercise_1
{
    public static class CardConsoleViewer
    {
        private const ushort TOTAL_WIDTH = 19;
        public static void Print(string paymentSystem, string cardNumber)
        {
            string centeredPaymentSystem = paymentSystem.PadLeft(((TOTAL_WIDTH - paymentSystem.Length) / 2) + paymentSystem.Length).PadRight(TOTAL_WIDTH);
            Console.WriteLine($"# {centeredPaymentSystem} # card_number = \"{cardNumber}\"");
        }

        public static void Print((string paymentSystem, string cardNumber) tuple)
        {
            string centeredPaymentSystem = tuple.paymentSystem.PadLeft(((TOTAL_WIDTH - tuple.paymentSystem.Length) / 2) + tuple.paymentSystem.Length).PadRight(TOTAL_WIDTH);
            Console.WriteLine($"# {centeredPaymentSystem} # card_number = \"{tuple.cardNumber}\"");
        }
    }
}
