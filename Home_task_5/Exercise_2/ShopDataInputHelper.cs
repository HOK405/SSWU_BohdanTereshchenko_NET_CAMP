namespace Exercise_2
{
    internal static class ShopDataInputHelper
    {
        public static void InputData(Department shop)
        {
            Console.WriteLine("Would you like to input the shop data by default or by your own?");
            Console.WriteLine("1 - by default; 2 - by my own");

            int choice = 0;

             if (int.TryParse(Console.ReadLine(), out choice))
             {
                 if (choice < 1 || choice > 2)
                 {
                     throw new ArgumentException("Wrong input data.");
                 }
                 if (choice == 1)
                 {
                     InputDataByDefault(shop);
                 }
                 if (choice == 2)
                 {
                     InputDataFromConsole(shop);
                 }
             }
             else
             {
                throw new ArgumentException("Wrong input data.");
             }
        }

        private static void InputDataFromConsole(Department shop)
        {
            Console.Write("Shop name: ");
            string? shopName = Console.ReadLine();

            if (IsNullOrEmptyName(shopName))
            {
                throw new ArgumentException("Shop name is null or emtpy.");
            }
            else
            {
                shop.Name = shopName;
            }

            Console.WriteLine();

            InputDepartments(shop);
        }

        private static void InputDepartments(Department department)
        {
            Console.Write("Amount of departments (at least 1): ");
            int departmentsAmount = 0;
            if (int.TryParse(Console.ReadLine(), out departmentsAmount))
            {
                if (departmentsAmount <= 0)
                {
                    throw new ArgumentOutOfRangeException("An amount of departments is less than 1.");
                }

                for (int i = 0; i < departmentsAmount; i++)
                {
                    Console.WriteLine();
                    Console.Write("Department name: ");
                    string? departmentName = Console.ReadLine();

                    Department shopDepartment = new Department();
                    if (IsNullOrEmptyName(departmentName))
                    {
                        throw new ArgumentException("Department name is null or empty.");
                    }
                    else
                    {
                        shopDepartment.Name = departmentName;
                    }

                    InputProducts(shopDepartment);                  

                    department.Add(shopDepartment);
                }
            }
            else
            {
                throw new ArgumentException("Incorrect input value.");
            }
        }

        private static void InputProducts(Department department)
        {
            Console.Write("Amount of products (at least 1): ");
            int productsAmount = 0;

            if (int.TryParse(Console.ReadLine(), out productsAmount))
            {
                if (productsAmount <= 0)
                {
                    throw new ArgumentOutOfRangeException("An amount of products is less than 1.");
                }

                for (int j = 0; j < productsAmount; j++)
                {
                    Console.Write("Product name: ");

                    string? productName = Console.ReadLine();

                    if (IsNullOrEmptyName(productName))
                    {
                        throw new ArgumentException("Product name is null or empty.");
                    }
                    Console.Write("Height: ");
                    int height = 0;

                    if (!int.TryParse(Console.ReadLine(), out height))
                    {
                        throw new ArgumentException("Height must be a number greater than zero.");
                    }

                    Console.Write("Width: ");
                    int width = 0;
                    if (!int.TryParse(Console.ReadLine(), out width))
                    {
                        throw new ArgumentException("Width must be a number greater than zero.");
                    }

                    Console.Write("Length: ");
                    int length = 0;
                    if (!int.TryParse(Console.ReadLine(), out length))
                    {
                        throw new ArgumentException("Length must be a number greater than zero.");
                    }

                    department.Add(new Product(productName, height, width, length));
                }
            }
            else
            {
                throw new ArgumentException("Incorrect input value.");
            }
        }

        private static bool IsNullOrEmptyName(string? name)
        {
            if (name is null || name == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void InputDataByDefault(Department shop)
        {
            shop.Name = "Silpo";

            Department meatDepartment = new Department("Meat");

            meatDepartment.Add(new Product("Sausage", 3, 5, 10));
            meatDepartment.Add(new Product("Venison", 10, 3, 12));
            meatDepartment.Add(new Product("Lard", 10, 10, 10));


            Department dairyDepartment = new Department("Dairy");

            dairyDepartment.Add(new Product("Butter", 4, 7, 5));
            dairyDepartment.Add(new Product("Ice cream", 12, 4, 5));
            dairyDepartment.Add(new Product("Sheep cheese", 5, 3, 8));

            Department bakeryDepartment = new Department("Bakery");

            bakeryDepartment.Add(new Product("Bread", 5, 5, 10));
            bakeryDepartment.Add(new Product("Muffin", 8, 20, 25));
            bakeryDepartment.Add(new Product("Pizza", 4, 12, 12));

            shop.Add(meatDepartment);
            shop.Add(dairyDepartment);
            shop.Add(bakeryDepartment);
        }
    }
}
