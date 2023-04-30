namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 3, 5 };
            int[] arr2 = { 2, 4, 4};
            int[] arr3 = { 0, 7, 8};
            int[] arr4 = { -1, 10, 6, 9 };

            ArraySorter sortingArray = new ArraySorter();

            try
            {
                sortingArray = new ArraySorter(arr1, arr2, arr3, arr4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (sortingArray != null)
            {
                foreach (int number in sortingArray.GetSortedArray())
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}