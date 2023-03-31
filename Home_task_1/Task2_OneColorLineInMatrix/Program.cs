namespace Task2_OneColorLineInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows:");
            string? rowsInput = Console.ReadLine();

            int rowsAmount = 0;
            bool IsIntRow = int.TryParse(rowsInput, out rowsAmount) && rowsAmount > 0;

            Console.WriteLine("Enter the number of columns:");
            string? columnsInput = Console.ReadLine();

            int columnsAmount = 0;
            bool IsIntColumn = int.TryParse(columnsInput, out columnsAmount) && columnsAmount > 0;

            Console.WriteLine();


            ColorMatrix matrix = new ColorMatrix();

            if (IsIntRow && IsIntColumn)
            {
                matrix = new ColorMatrix(rowsAmount, columnsAmount);
            }

            matrix.FillRandomly();
            Console.WriteLine(matrix);

            matrix.FindLine();

            Console.WriteLine($"Max one-color line length - {matrix.LineLength}");
            Console.WriteLine($"Coordinates [{matrix.LineRow},{matrix.ColumnStart}] - [{matrix.LineRow},{matrix.ColumnFinish}]");
            Console.WriteLine($"Color - {matrix.Color}");


            Console.Write("Hello world!!!");
        }
    }
}