namespace Exercise.Cooks
{
    public class DessertCook : CookHandler
    {
        public DessertCook(string lastName) : base(lastName) { }

        public override void HandleOrder(Order order)
        {
            if (order.Category != FoodCategory.Dessert || IsBusy)
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

                OnOrderPrepared($"Десерт {order.Name} приготовлений кухарем {LastName}");
            }
        }
    }
}