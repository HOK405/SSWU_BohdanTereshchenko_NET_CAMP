namespace Exercise.Cooks
{
    public abstract class CookHandler : ICookHandler
    {
        protected ICookHandler NextCook;

        public event OrderPreparedEventHandler OrderPrepared;

        protected static Random random = new Random();

        public string LastName { get; set; }

        public bool IsBusy { get; set; }

        public CookHandler(string lastName)
        {
            LastName = lastName;
            IsBusy = random.Next(2) == 1;
        }

        public ICookHandler SetNextCook(ICookHandler cook)
        {
            NextCook = cook;
            return this;
        }

        public virtual void HandleOrder(Order order)
        {
            if (NextCook != null)
            {
                NextCook.HandleOrder(order);
            }
            IsBusy = random.Next(2) == 1;
        }

        protected void OnOrderPrepared(string message)
        {
            OrderPrepared?.Invoke(message);
        }
    }
}