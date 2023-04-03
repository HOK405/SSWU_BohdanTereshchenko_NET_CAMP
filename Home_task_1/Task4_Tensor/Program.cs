using System.Linq.Expressions;

namespace Task4_Tensor
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter number the number of dimensions:");
            string? dimensionInput = Console.ReadLine();
            int dimensionAmount = 0;
            bool IsIntDimension = int.TryParse(dimensionInput, out dimensionAmount) && dimensionAmount > 0;

            int[] sizes = new int[0];
            int size = 0;

            if (IsIntDimension)
            {
                sizes = new int[dimensionAmount];

                for (int i = 0; i < dimensionAmount; i++)
                {
                    Console.WriteLine($"Enter size for dimension {i + 1}:");
                    string? sizeInput = Console.ReadLine();
                    
                    bool IsIntSize = int.TryParse(sizeInput, out size) && size > 0;
                    if (IsIntSize)
                    {
                        sizes[i] = size;
                    }
                }
            }

            Tensor myTensor = new Tensor();

            try
            {
                myTensor = new Tensor(sizes);               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Tensor with {myTensor.DimensionsAmount} dimensions is created.");
        }
    }
}