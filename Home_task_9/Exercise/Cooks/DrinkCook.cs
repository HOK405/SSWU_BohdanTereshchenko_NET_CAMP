namespace Exercise.Cooks
{
    public class DrinkCook : CookHandler
    {
        public DrinkCook(string lastName) : base(lastName) { }

        public override void HandleOrder(Order order)
        {
            if (order.Category != FoodCategory.Drink || IsBusy)
            {
                base.HandleOrder(order);
            }
            else
            {
                PrepareOrder(order);
            }
        }

        private void PrepareOrder(Order order)
        {
            for (int i = 0; i < order.Quantity; i++)
            {
                Thread.Sleep(order.PreparationTime);

                OnOrderPrepared($"Напій {order.Name} приготовлений кухарем {LastName}");
            }
        }
    }
}