using System.Text;

namespace Exercise_2
{
    internal class Program
    {
        public static void Main()
        {
            ExternalMergeSorting externalMergeSorting = new ExternalMergeSorting();

            externalMergeSorting.Perform(130, 50);
        }
    } 
}