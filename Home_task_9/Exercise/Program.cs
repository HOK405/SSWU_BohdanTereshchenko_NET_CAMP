using Exercise.Cooks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            ICookHandler pizzaCookIvanov = new PizzaCook("Іванов");
            ICookHandler dessertCookPetrov = new DessertCook("Петров");
            ICookHandler drinkCookSydorov = new DrinkCook("Сидоров");
            ICookHandler pizzaCookKopaylo = new PizzaCook("Копайло");

            pizzaCookIvanov.IsBusy = true;
            pizzaCookKopaylo.IsBusy = false;

            pizzaCookIvanov.SetNextCook(dessertCookPetrov);
            dessertCookPetrov.SetNextCook(drinkCookSydorov);
            drinkCookSydorov.SetNextCook(pizzaCookKopaylo);

            pizzaCookIvanov.OrderPrepared += message => Console.WriteLine(message);
            dessertCookPetrov.OrderPrepared += message => Console.WriteLine(message);
            drinkCookSydorov.OrderPrepared += message => Console.WriteLine(message);
            pizzaCookKopaylo.OrderPrepared += message => Console.WriteLine(message);

            List<Order> orders = new List<Order>
            {
                new Order(FoodCategory.Dessert, "Райський", 1, TimeSpan.FromSeconds(1)),
                new Order(FoodCategory.Dessert, "Тірамісу", 3, TimeSpan.FromSeconds(1)),
                new Order(FoodCategory.Pizza, "4 сири", 1, TimeSpan.FromSeconds(1)),
                new Order(FoodCategory.Pizza, "5 сирів", 2, TimeSpan.FromSeconds(1)),
                new Order(FoodCategory.Pizza, "Гавайська", 3, TimeSpan.FromSeconds(1)),
                new Order(FoodCategory.Drink, "Сік ананасовий", 5, TimeSpan.FromSeconds(1))
            };

            foreach (var order in orders)
            {
                pizzaCookIvanov.HandleOrder(order);
            }
        }
    }

}