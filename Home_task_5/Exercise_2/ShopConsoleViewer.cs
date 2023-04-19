namespace Exercise_2
{
    internal static class ShopConsoleViewer
    {
        public static void ShowBoxesInfo(Department shop)
        {
            string shopInfo = $"\"{shop.Name}\" box size - H:{shop.GetHeight()}, W:{shop.GetWidth()}, L:{shop.GetLength()}";

            Console.WriteLine(shopInfo);

            foreach (Department department in shop.GetChildren())
            {
                string departmentInfo = $"{"".PadLeft(shopInfo.Length)}\"{department.Name}\" box size - H:{department.GetHeight()}, W:{department.GetWidth()}, L:{department.GetLength()}";
                Console.WriteLine(departmentInfo.ToString().PadLeft(shopInfo.Length));

                foreach (Product product in department.GetChildren())
                {
                    Console.WriteLine($"{"".PadLeft(departmentInfo.Length)}\"{product.Name}\" box size - H:{product.GetHeight()}, W:{product.GetWidth()}, L:{product.GetLength()}");
                }
            }
        }
    }
}
