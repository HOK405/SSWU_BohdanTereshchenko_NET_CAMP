using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    static internal class TextDataFormatter
    {
        public static void GetRecordsFromTextFile(out RecordsStorageController controller, string source)
        {
            List<Record> records = new List<Record>();
            int apartmentCount = 0;
            int quarter = 0;

            using (StreamReader reader = new StreamReader(source))
            {
                string? line = reader.ReadLine();
                string[] parts = line.Split(';');
                apartmentCount = int.Parse(parts[0].Trim());
                quarter = int.Parse(parts[1].Trim());

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(';');
                    records.Add(new Record { 
                        Number = int.Parse(parts[0].Trim()),
                        Address = parts[1].Trim(),
                        Surname = parts[2].Trim(),
                        InputReading = double.Parse(parts[3].Trim()),
                        OutputReading = double.Parse(parts[4].Trim()),
                        InputDate = DateTime.Parse(parts[5].Trim()),
                        OutputDate = DateTime.Parse(parts[6].Trim())
                    });
                }
                controller = new RecordsStorageController(records, apartmentCount, quarter);
            }
        }
    }
}
