using System.Text;

namespace Exercise_2
{
    internal class Program
    {
        public static void Main()
        {
            ExternalMergeSorting.GenerateAndWriteNumbers(130);
            ExternalMergeSorting.ProcessAndWriteToFile(50);
            ExternalMergeSorting.MergeAndWriteBackToFile();
        }
    } 
}