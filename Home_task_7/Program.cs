namespace Home_task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleIntersectionController simpleIntersectionController = new SimpleIntersectionController(10, 2, 2, 2);

            simpleIntersectionController.StateChange += new IntersectionHandler(SimpleIntersectionConsole.Print);

            simpleIntersectionController.Start();
        }
    }
}