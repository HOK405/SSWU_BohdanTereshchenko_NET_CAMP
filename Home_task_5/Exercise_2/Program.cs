namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Department shop = new Department();
                ShopDataInputHelper.InputData(shop);
                ShopConsoleViewer.ShowBoxesInfo(shop);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}