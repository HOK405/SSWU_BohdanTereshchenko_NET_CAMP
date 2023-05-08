using System.Text;

namespace Home_task_7
{
    internal static class SimpleIntersectionConsole
    {
        public static void Print(SimpleIntersectionController controller, int time)
        {
            const int PADDING = 15;

            StringBuilder sb = new StringBuilder();

            string timeInfo = $"t = {time} |";

            sb.Append("|".PadLeft(timeInfo.Length));
            sb.Append($"{"Traffic lights".PadRight(PADDING)}|");
            sb.Append($"{controller.GetNorthSouth().Name.PadLeft(PADDING)} |");
            sb.Append($"{controller.GetSouthNorth().Name.PadLeft(PADDING)} |");
            sb.Append($"{controller.GetEastWest().Name.PadLeft(PADDING)} |");
            sb.Append($"{controller.GetWestEast().Name.PadLeft(PADDING)} |");

            PrintLine(sb.Length);
            Console.WriteLine(timeInfo);
            Console.WriteLine(sb);

            sb.Clear();
            sb.Append("|".PadLeft(timeInfo.Length));
            sb.Append($"{"Color".PadRight(PADDING)}|");
            sb.Append($"{controller.GetNorthSouth().GetState().ToString().PadLeft(PADDING)} |");
            sb.Append($"{controller.GetSouthNorth().GetState().ToString().PadLeft(PADDING)} |");
            sb.Append($"{controller.GetEastWest().GetState().ToString().PadLeft(PADDING)} |");
            sb.Append($"{controller.GetWestEast().GetState().ToString().PadLeft(PADDING)} |");
            Console.WriteLine(sb);

            PrintLine(sb.Length);
            Console.WriteLine();
            sb.Clear();
        }

        private static void PrintLine(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
