namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IProduct> products = new List<IProduct>() 
            {
                new Food { Name = "Apple", Weight = 0.5, Size = 0.3, IsPerishable = true },
                new Electronics { Name = "TV Samsung P42-CD", Weight = 10, Size = 10, Price = 500, IsOversize = true },
                new Electronics { Name = "Huawei P50 Pro", Weight = 1, Size = 1, Price = 600, IsOversize = false },
                new Clothing { Name = "Blue shirt", Weight = 1, Size = 0.5 }
            };

            IShippingCostVisitor visitor = new ShippingCostVisitor();

            foreach (IProduct product in products)
            {
                Console.WriteLine($"Delivery value for {product.Name}: {product.Accept(visitor)}$");
            }
        }
    }
}