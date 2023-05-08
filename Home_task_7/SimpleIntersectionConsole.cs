using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    internal static class SimpleIntersectionConsole
    {
        public static void Print(SimpleIntersectionController controller, int time)
        {
            Console.WriteLine($"t = {time}");
            Console.WriteLine($"North-South state: {controller.NorthSouth.GetState()}");
            Console.WriteLine($"South-North state: {controller.NorthSouth.GetState()}");

            Console.WriteLine($"East-West state: {controller.EastWest.GetState()}");
            Console.WriteLine($"West-East state: {controller.WestEast.GetState()}");

            Console.WriteLine();
        }
    }
}
