namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            RecordsStorageController controller;

            TextDataFormatter.GetRecordsFromTextFile(out controller, "data.txt");

            RecordsStorageConsoleViewer.ShowAllRecords(controller);

        }
    }
}