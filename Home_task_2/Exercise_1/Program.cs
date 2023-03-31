namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WaterPump waterPump = new WaterPump(100);
            List<User> users = new List<User>()
            {
                new User(2.5),
                new User(2.3),
                new User(3.1),
            };

            WaterTower waterTower = new WaterTower(100, waterPump);

            Simulator waterTowerSimulator = new Simulator(waterTower, users);

            waterTowerSimulator.Simulate();
        }
    }
}