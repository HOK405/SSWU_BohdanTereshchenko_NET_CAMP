namespace Home_task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleIntersectionController simpleIntersectionController = new SimpleIntersectionController(
                new SimpleTrafficLights("North-South"), 
                new SimpleTrafficLights("South-North"),
                new SimpleTrafficLights("East-West"),
                new SimpleTrafficLights("West-East")
                );

            simpleIntersectionController.StateChange += new IntersectionHandler(SimpleIntersectionConsole.Print);

            simpleIntersectionController.SetWorkingTime(5);
            simpleIntersectionController.SetGreenTime(2);

            Console.WriteLine(simpleIntersectionController);
            simpleIntersectionController.Start();
        }
    }
}