using System;

namespace Exercise.Cooks
{
    public class PizzaCook : CookHandler
    {
        public PizzaCook(string lastName) : base(lastName) { }

        public override void HandleOrder(Order order)
        {
            if (order.Category != FoodCategory.Pizza || IsBusy)
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

                OnOrderPrepared($"Піца {order.Name} приготовлена кухарем {LastName}");
            }
        }
    }
}