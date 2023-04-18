using System.Diagnostics;

namespace Exercise_3
{
    static internal class RecordsStorageConsoleViewer
    {
        private const int SHORT_INDENTATION = 5;
        private const int MIDDLE_INDENTATION = 12;
        private const int LONG_INDENTATION = 15;

        public static void ShowSpecificRecord(RecordsStorageController storage, Record? record) // with header
        {
            if (record is null)
            {
                throw new ArgumentNullException("Record is null.");
            }

            ShowHeader();

            PrintRecord(record, storage.Price);
        }
        public static void ShowRecord(Record? record, float price) // without header
        {
            if (record is null || price <= 0)
            {
                throw new ArgumentNullException("Record is null.");
            }

            PrintRecord(record, price);
        }

        public static void ShowAllRecords(RecordsStorageController storage)
        {
            if (storage is null || storage.ApartmentCount == 0)
            {
                throw new ArgumentNullException("Storage is null or empty");
            }

            ShowHeader();

            foreach (Record record in storage.GetRecords())
            {
                ShowRecord(record, storage.Price);
            }
        }

        public static void ShowRecordsGroup(RecordsStorageController storage, List<Record>? records)
        {
            if (records is null || storage is null || storage.ApartmentCount == 0)
            {
                throw new ArgumentNullException("Storage is null or empty.");
            }

            ShowHeader();
            foreach (Record record in records)
            {
                PrintRecord(record, storage.Price);
            }
        }

        private static void ShowHeader()
        {
            Console.WriteLine($"{"No.",SHORT_INDENTATION}|{"Surname",LONG_INDENTATION}|{"Input month",LONG_INDENTATION}|" +
                $"{"Input date",LONG_INDENTATION}|{"Input Val",MIDDLE_INDENTATION}|{"Output month",LONG_INDENTATION}|" +
                $"{"Output date",LONG_INDENTATION}|{"Output Val",MIDDLE_INDENTATION}|{"Consumption",MIDDLE_INDENTATION}|" +
                $"{"Cons. Price", MIDDLE_INDENTATION}|{"Days passed",LONG_INDENTATION}");

            for (int i = 0; i < (LONG_INDENTATION * 10); i++)
            {
                Console.Write('─');
            }
            Console.WriteLine();
        }

        private static void PrintRecord(Record record, float price)
        {
            Console.WriteLine($"{record.Number,SHORT_INDENTATION}│{record.Surname,LONG_INDENTATION}│{record.InputDate.ToString("MMMM"),LONG_INDENTATION}│" +
                 $"{record.InputDate.ToString("MM.dd.yyyy"),LONG_INDENTATION}│{record.InputReading,MIDDLE_INDENTATION}│{record.OutputDate.ToString("MMMM"),LONG_INDENTATION}│" +
                 $"{record.OutputDate.ToString("MM.dd.yyyy"),LONG_INDENTATION}│{record.OutputReading,MIDDLE_INDENTATION}│{(record.OutputReading - record.InputReading),MIDDLE_INDENTATION:F2}│" +
                 $"{(record.OutputReading - record.InputReading) * price, MIDDLE_INDENTATION:F2}|{(DateTime.Now-record.OutputDate).TotalDays,LONG_INDENTATION:F0}|");
        }
    }
}
