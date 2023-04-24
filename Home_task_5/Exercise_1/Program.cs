namespace Exercise_1
{
    internal class Program
    {//Bohdan	Tereshchenko		90	0	5	90	90	90	99	94,3. вітаю Вас у 2 турі.
        static void Main(string[] args)
        {
            Garden firstGarden = new Garden();         // сад
            firstGarden.PlantTheTree(new Point(0, 3)); // засадження першого саду деревами
            firstGarden.PlantTheTree(new Point(2, 3));
            firstGarden.PlantTheTree(new Point(1, 1));
            firstGarden.PlantTheTree(new Point(3, 0));
            firstGarden.PlantTheTree(new Point(0, 0));
            firstGarden.PlantTheTree(new Point(3, 3));


            Garden secondGarden = new Garden();        // більший сад      
            secondGarden.PlantTheTree(new Point(0, 0));// засадження другого саду деревами
            secondGarden.PlantTheTree(new Point(1, 1));
            secondGarden.PlantTheTree(new Point(3, 3));
            secondGarden.PlantTheTree(new Point(2, 1));
            secondGarden.PlantTheTree(new Point(5, 0));


            Console.WriteLine("Points of the first garden fence:");
            GardenConsoleViewer.PrintShortestFencePoints(firstGarden); // вивід точок паркану для першого саду
            GardenConsoleViewer.PrintFencePerimeter(firstGarden);      // вивід периметру паркану першого саду
            
            Console.WriteLine();

            Console.WriteLine("Points of the second garden fence:");
            GardenConsoleViewer.PrintShortestFencePoints(secondGarden);// вивід точок паркану для другого саду
            GardenConsoleViewer.PrintFencePerimeter(secondGarden);     // вивід периметру паркану другого саду

            bool firstGardenIsBigger = firstGarden > secondGarden;    // чи паркан першого саду більший
            bool secondGardenIsBigger = secondGarden > firstGarden;   // чи паркан другого саду більший
            bool gardensAreEqual = firstGarden == secondGarden;       // чи паркани однакові за довжиною

            Console.WriteLine();
            Console.WriteLine("First garden is bigger: {0}", firstGardenIsBigger);
            Console.WriteLine("Second garden is bigger: {0}", secondGardenIsBigger);
            Console.WriteLine("Gardens are equal: {0}", gardensAreEqual);
        }       
    }
}
