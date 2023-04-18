using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    static internal class RecordsStorageConsoleViewer
    {
        private const int SHORT_INDENTATION = 11;
        private const int LONG_INDENTATION = 20;

        public static void ShowSpecificRecord(Record? record) // with header
        {
            if (record is null)
            {
                throw new ArgumentNullException("Record is null.");
            }

            ShowHeader();

            PrintRecord(record);
        }
        public static void ShowRecord(Record? record) // without header
        {
            if (record is null)
            {
                throw new ArgumentNullException("Record is null.");
            }

            PrintRecord(record);
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
                ShowRecord(record);
            }
        }


        private static void ShowHeader()
        {
            Console.WriteLine($"{"Flat number",SHORT_INDENTATION}|{"Surname",LONG_INDENTATION}|{"Input reading month",LONG_INDENTATION}|" +
                $"{"Input reading date",LONG_INDENTATION}|{"Output reading month",LONG_INDENTATION}|{"Output reading date",LONG_INDENTATION}");

            for (int i = 0; i < SHORT_INDENTATION + (LONG_INDENTATION * 5); i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

        private static void PrintRecord(Record? record)
        {
            Console.WriteLine($"{record.Number,SHORT_INDENTATION}|{record.Surname,LONG_INDENTATION}|{record.InputDate.ToString("MMMM"),LONG_INDENTATION}|" +
                 $"{record.InputDate.ToString("MM.dd.yyyy"),LONG_INDENTATION}|{record.OutputDate.ToString("MMMM"),LONG_INDENTATION}|{record.OutputDate.ToString("MM.dd.yyyy"),LONG_INDENTATION}");
        }
    }
}
