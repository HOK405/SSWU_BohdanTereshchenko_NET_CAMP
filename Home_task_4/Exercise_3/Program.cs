namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            float price = 1.44F;  // ціна за 1квт у грн

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
    }
}