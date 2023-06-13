namespace Exercise_2
{
    public static class ExternalMergeSorting
    {
        private const int MIN_NUMBER = 0;
        private const int MAX_NUMBER = 101;
        private static string filePath = "data.txt";

        public static void GenerateAndWriteNumbers(int count)
        {
            Random random = new Random();
            string numbers = string.Join("\n", Enumerable.Range(0, count).Select(_ => random.Next(MIN_NUMBER, MAX_NUMBER)).ToArray());

            File.WriteAllText(filePath, numbers);
        }

        public static void ProcessAndWriteToFile(int chunkSize)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<int> tempList = new List<int>();
                string line;
                int fileCount = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    tempList.Add(int.Parse(line));

                    if (tempList.Count == chunkSize)
                    {
                        tempList.Sort();
                        File.WriteAllText($"chunk{fileCount++}.txt", string.Join("\n", tempList));
                        tempList.Clear();
                    }
                }

                if (tempList.Count > 0)
                {
                    tempList.Sort();
                    File.WriteAllText($"chunk{fileCount}.txt", string.Join("\n", tempList));
                }
            }
        }

        public static void MergeAndWriteBackToFile()
        {
            int fileCount = 1;
            string file1, file2;
            int mergeCount = 1;

            while (File.Exists($"chunk{fileCount + 1}.txt"))
            {
                file1 = $"chunk{fileCount++}.txt";
                file2 = $"chunk{fileCount++}.txt";

                MergeTwoFiles(file1, file2, $"merge{mergeCount++}.txt");
            }

            if (File.Exists($"chunk{fileCount}.txt")) 
            {
                MergeTwoFiles($"merge{mergeCount - 1}.txt", $"chunk{fileCount}.txt", $"merge{mergeCount++}.txt");
            }

            while (File.Exists($"merge{mergeCount - 1}.txt") && File.Exists($"merge{mergeCount - 2}.txt"))
            {
                file1 = $"merge{mergeCount - 2}.txt";
                file2 = $"merge{mergeCount - 1}.txt";

                MergeTwoFiles(file1, file2, $"merge{mergeCount}.txt");
                mergeCount++;
            }

            if (File.Exists("merge.txt"))
            {
                File.Delete("merge.txt");
            }

            File.Move($"merge{mergeCount - 1}.txt", "merge.txt");

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine("\n\nРезультат:\n" + File.ReadAllText("merge.txt"));
            }

            File.Delete("merge.txt");
        }

        private static void MergeTwoFiles(string file1, string file2, string outputFilePath) 
        {
            using (StreamReader reader1 = new StreamReader(file1), reader2 = new StreamReader(file2))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    var value1 = reader1.ReadLine();
                    var value2 = reader2.ReadLine();

                    while (value1 != null && value2 != null)
                    {
                        if (int.Parse(value1) <= int.Parse(value2))
                        {
                            writer.WriteLine(value1);
                            value1 = reader1.ReadLine();
                        }
                        else
                        {
                            writer.WriteLine(value2);
                            value2 = reader2.ReadLine();
                        }
                    }

                    while (value1 != null)
                    {
                        writer.WriteLine(value1);
                        value1 = reader1.ReadLine();
                    }

                    while (value2 != null)
                    {
                        writer.WriteLine(value2);
                        value2 = reader2.ReadLine();
                    }
                }
            }

            File.Delete(file1);
            File.Delete(file2);
        }
     
    }
}
