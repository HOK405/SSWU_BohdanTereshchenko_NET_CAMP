namespace Exercise
{
    public class Order
    {
        public FoodCategory Category { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public TimeSpan PreparationTime { get; set; }

        public Order(FoodCategory category, string name, int quantity, TimeSpan preparationTime)
        {
            Category = category;
            Name = name;
            Quantity = quantity;
            PreparationTime = preparationTime;
        }
    }

}