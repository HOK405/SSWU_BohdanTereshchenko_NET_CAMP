using System.Net.Http.Headers;

namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] myMatrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };

            SnakeMatrix snakeMatrix1 = new SnakeMatrix();
            SnakeMatrix snakeMatrix2 = new SnakeMatrix();
            SnakeMatrix snakeMatrix3 = new SnakeMatrix();

            try
            {
                snakeMatrix1 = new SnakeMatrix(5);
                snakeMatrix2 = new SnakeMatrix(5,3);
                snakeMatrix3 = new SnakeMatrix(myMatrix);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Square matrix (auto-generated):");
            Console.WriteLine(snakeMatrix1);

            foreach (int value in snakeMatrix1)
            {
                Console.Write(value + " ");
            }


            Console.WriteLine("\n");
            Console.WriteLine("5:3 matrix (auto-generated):");
            Console.WriteLine(snakeMatrix2);

            foreach (int value in snakeMatrix2)
            {
                Console.Write(value + " ");
            }


            Console.WriteLine("\n");
            Console.WriteLine("4:4 matrix (passed into constructor):");
            Console.WriteLine(snakeMatrix3);

            foreach (int value in snakeMatrix3)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }
}