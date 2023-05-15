using Home_task_8.Controllers;
using Home_task_8.Output;
using Home_task_8.TrafficLights;

namespace Home_task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*SimpleIntersectionController simpleIntersectionController = new SimpleIntersectionController(
                new SimpleTrafficLight("North-South"),
                new SimpleTrafficLight("South-North"),
                new SimpleTrafficLight("East-West"),
                new SimpleTrafficLight("West-East")
                );

            simpleIntersectionController.StateChange += IntersectionConsoleViewer.Print;

            simpleIntersectionController.SetWorkingTime(15);
            simpleIntersectionController.SetGreenTime(2);
            simpleIntersectionController.SetRedTime(2);

            Console.WriteLine(simpleIntersectionController);
            try
            {
                simpleIntersectionController.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();*/

            DoubleIntersectionController doubleIntersectionController = new DoubleIntersectionController(15);
            doubleIntersectionController.StateChange += IntersectionConsoleViewer.Print;

            try
            {
                doubleIntersectionController.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
