namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PaymentSystem> paymentSystems = new List<PaymentSystem>
            {
                new PaymentSystem("Visa", new List<string> { "4" }, new List<ushort> { 16, 13 }),

                new PaymentSystem("Mastercard", new List<string> { "51", "55" }, new List<ushort> { 16 }),

                new PaymentSystem("American Express", new List<string> {"34", "37"}, new List<ushort> { 15 }),

                new PaymentSystem("Discover", new List<string> {"6011", "644649, 65"}, new List<ushort> { 16 }),

                new PaymentSystem("Troy", new List<string> {"9"}, new List<ushort> { 16 }),

                new PaymentSystem("China Union Pay", new List<string> {"60", "62"}, new List<ushort> { 16, 17, 18, 19 }),

                new PaymentSystem("Solo ", new List<string> {"6334", "6767"}, new List<ushort> { 16, 18, 19 })
            };

            CardNumberValidator cardValidator = new CardNumberValidator(paymentSystems);


            CardConsoleViewer.Print(cardValidator.Check("3782 8224631 0005"));      // American Express 15
                                                                                    
            CardConsoleViewer.Print(cardValidator.Check("5555 5555 5555 4444"));    // MASTERCARD correct
            CardConsoleViewer.Print(cardValidator.Check("5168 7574 0405 0140"));    // MASTERCARD NOT correct
                                                                                    
            CardConsoleViewer.Print(cardValidator.Check("4441 1144 5357 5514"));    // VISA 16
            CardConsoleViewer.Print(cardValidator.Check("4000 00133 4560"));        // VISA 13 correct
                                                                                    
            CardConsoleViewer.Print(cardValidator.Check("6011 1111 1111 1117"));    // Discover 16 correct
                                                                                    
            CardConsoleViewer.Print(cardValidator.Check("9876 5432 1012 3452"));    // Troy 16 correct
            CardConsoleViewer.Print(cardValidator.Check("9876 5432 1012 3453"));    // Troy 16 NOT correct
                                                                                    
            CardConsoleViewer.Print(cardValidator.Check("6000 0000 0000 0700"));    // CUP 16 correct
            CardConsoleViewer.Print(cardValidator.Check("6200 00000 0 00000 0505"));// CUP 19 correct
            CardConsoleViewer.Print(cardValidator.Check("6200 00000 0 00000 0504"));// CUP 19 NOT correct
        }
    }
}