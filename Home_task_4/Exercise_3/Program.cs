namespace Exercise_3
{// січень і березень не мали б попасти в один квартал))
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
// краще цю константу в конфігураційний клас класти.
            float price = 1.44F;  // ціна за 1квт у грн
            try
            {
                RecordsStorageController controller;

                TextDataFormatter.GetRecordsFromTextFile(out controller, "data.txt");
                controller.Price = price;

                RecordsStorageConsoleViewer.ShowAllRecords(controller);

                Console.WriteLine();
                Console.WriteLine("Record with max consumption:");

                RecordsStorageConsoleViewer.ShowSpecificRecord(controller, controller.GetMaxConsumptionRecord());

                Console.WriteLine();
                Console.WriteLine("Records without consumption:");
                RecordsStorageConsoleViewer.ShowRecordsGroup(controller, controller.GetNoConsumptionRecords());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
