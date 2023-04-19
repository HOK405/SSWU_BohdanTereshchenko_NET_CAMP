using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal static class GardenConsoleViewer
    {
        public static void PrintShortestFencePoints(Garden garden)
        {
            if (garden is null)
            {
                throw new NullReferenceException("Garden is null.");
            }

            List<Point> points = garden.GetShortestFence();

            foreach (Point point in points)
            {
                Console.WriteLine(point);
            }
        }

        public static void PrintFencePerimeter(Garden garden)
        {
            if (garden is null)
            {
                throw new NullReferenceException("Garden is null.");
            }

            Console.WriteLine("Perimeter: {0}",garden.GetFencePerimeter());
        }
    }
}
