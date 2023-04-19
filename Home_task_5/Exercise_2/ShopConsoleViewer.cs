using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal static class ShopConsoleViewer
    {
        public static void ShowBoxes(Department shop)
        {
            foreach (Department department in shop.GetChildren())
            {
                Console.WriteLine($"\"{department.Name}\" box size - H:{department.GetHeight()}, W:{department.GetWidth()}, L:{department.GetLength()}");
                foreach (Product product in department.GetChildren())
                {
                    Console.WriteLine($"{"",35}\"{product.Name}\" box size - H:{product.GetHeight()}, W:{product.GetWidth()}, L:{product.GetLength()}");
                }
            }
        }
    }
}
