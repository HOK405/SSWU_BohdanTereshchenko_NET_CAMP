namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department meatDepartment = new Department("Meat");

            meatDepartment.Add(new Product("Sausage", 3, 5, 10));
            meatDepartment.Add(new Product("Venison", 10, 3, 12));
            meatDepartment.Add(new Product("Lard", 10, 10, 10));


            Department dairyDepartment = new Department("Dairy");

            dairyDepartment.Add(new Product("Butter", 4, 7, 5));
            dairyDepartment.Add(new Product("Ice cream", 12, 4, 5));
            dairyDepartment.Add(new Product("Sheep cheese", 5, 3, 8));

            Department shop = new Department("Silpo");

            shop.Add(meatDepartment);
            shop.Add(dairyDepartment);

            ShopConsoleViewer.ShowBoxes(shop);
        }
    }
}