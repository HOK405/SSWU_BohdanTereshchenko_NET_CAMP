using System.Text;
using Home_task_8.Controllers;

namespace Home_task_8.Output
{
    internal static class IntersectionConsoleViewer
    {
        public static void Print(SimpleIntersectionController controller, DateTime exactTime = default)
        {
            if (controller is null)
            {
                throw new ArgumentException("Controller is null or empty.");
            }

            StringBuilder sb = new StringBuilder();

            string timeInfo = $"t = {controller.Time}, {exactTime.Hour:D2}:{exactTime.Minute:D2}:{exactTime.Second:D2}|";

            sb.Append("|".PadLeft(timeInfo.Length));
            sb.Append($"{"Traffic lights".PadRight(Constants.MIDDLE_PADDING)}|");
            sb.Append($"{controller.GetNorthSouth().Name.PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetSouthNorth().Name.PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetEastWest().Name.PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetWestEast().Name.PadLeft(Constants.MIDDLE_PADDING)} |");

            PrintLine(sb.Length);
            Console.WriteLine(timeInfo);
            Console.WriteLine(sb);

            sb.Clear();
            sb.Append("|".PadLeft(timeInfo.Length));
            sb.Append($"{"Color".PadRight(Constants.MIDDLE_PADDING)}|");
            sb.Append($"{controller.GetNorthSouth().ToString().PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetSouthNorth().ToString().PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetEastWest().ToString().PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetWestEast().ToString().PadLeft(Constants.MIDDLE_PADDING)} |");
            Console.WriteLine(sb);

            PrintLine(sb.Length);
            Console.WriteLine();
            sb.Clear();
        }


        public static void Print(DoubleIntersectionController controller, DateTime exactTime = default)
        {
            if (controller is null)
            {
                throw new ArgumentException("Controller is null or empty.");
            }

            StringBuilder sb = new StringBuilder();

            string timeInfo = $"t = {controller.Time}, {exactTime.Hour:D2}:{exactTime.Minute:D2}:{exactTime.Second:D2}|";

            sb.Append("|".PadLeft(timeInfo.Length));
            sb.Append($"{"Traffic lights".PadRight(Constants.MIDDLE_PADDING)}|");
            sb.Append($"{controller.GetNorthSouth().Name.PadLeft(Constants.LARGE_PADDING)} |");
            sb.Append($"{controller.GetSouthNorth().Name.PadLeft(Constants.LARGE_PADDING)} |");
            sb.Append($"{controller.GetEastWest().Name.PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetWestEast().Name.PadLeft(Constants.MIDDLE_PADDING)} |");

            PrintLine(sb.Length);
            Console.WriteLine(timeInfo);
            Console.WriteLine(sb);

            sb.Clear();
            sb.Append("|".PadLeft(timeInfo.Length));
            sb.Append($"{"Color".PadRight(Constants.MIDDLE_PADDING)}|");
            sb.Append($"{controller.GetNorthSouth().ToString().PadLeft(Constants.LARGE_PADDING)} |");
            sb.Append($"{controller.GetSouthNorth().ToString().PadLeft(Constants.LARGE_PADDING)} |");
            sb.Append($"{controller.GetEastWest().ToString().PadLeft(Constants.MIDDLE_PADDING)} |");
            sb.Append($"{controller.GetWestEast().ToString().PadLeft(Constants.MIDDLE_PADDING)} |");
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
