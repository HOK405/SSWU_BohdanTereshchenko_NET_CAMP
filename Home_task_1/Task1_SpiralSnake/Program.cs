namespace Task1_SpiralSnake
{
    internal class Program
    {//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
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

            if(IsIntRow && IsIntColumn)
            {
                SpiralMatrix spiralMatrix = new SpiralMatrix(rowsAmount, columnsAmount);
                spiralMatrix.FormSpiralLeftTop();
                Console.WriteLine(spiralMatrix);

                spiralMatrix.FormSpiralRightBottom();  // reverse spiral
                Console.WriteLine(spiralMatrix);
            }
            else
            {
                SpiralMatrix spiralMatrix = new SpiralMatrix();
                spiralMatrix.FormSpiralLeftTop();
                Console.WriteLine(spiralMatrix);

                spiralMatrix.FormSpiralRightBottom(); // reverse spiral
                Console.WriteLine(spiralMatrix);
            }
        }
    }
}
