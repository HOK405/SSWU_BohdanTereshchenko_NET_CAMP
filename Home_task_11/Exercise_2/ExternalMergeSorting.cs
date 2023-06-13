namespace Exercise_2
{
    public class ExternalMergeSorting
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 101;
        private string _inputFilePath;

        public ExternalMergeSorting(string inputFilePath = "input.txt")
        {
            _inputFilePath = inputFilePath;
        }

        public void Perform(int numbersQuantity, int chunkSize)
        {
            GenerateAndWriteNumbers(numbersQuantity);
            ProcessAndWriteToChunks(chunkSize);
            MergeAndWriteBackToFile();
        }

        private void GenerateAndWriteNumbers(int count)
        {
            Random random = new Random();
            string numbers = string.Join("\n", Enumerable.Range(0, count).Select(_ => random.Next(MIN_VALUE, MAX_VALUE)).ToArray());

            File.WriteAllText(_inputFilePath, numbers);
        }

        private void ProcessAndWriteToChunks(int chunkSize)
        {
            using (StreamReader reader = new StreamReader(_inputFilePath))
            {
                List<int> tempList = new List<int>();
                string line;
                int fileCount = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    tempList.Add(int.Parse(line)); // к-сть елементів буде максимум chunkSize

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

        private void MergeAndWriteBackToFile()
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

            int lastMergedFileIndex = mergeCount > 1 ? mergeCount - 1 : 1;
            for (int i = 1; i < lastMergedFileIndex; i++) 
            {
                if (File.Exists($"merge{i}.txt") && File.Exists($"merge{i + 1}.txt"))
                {
                    MergeTwoFiles($"merge{i}.txt", $"merge{i + 1}.txt", $"merge{mergeCount}.txt");
                    lastMergedFileIndex = mergeCount;
                    mergeCount++;
                }
            }

            for (int i = 1; i < mergeCount; i++)
            {
                if (File.Exists($"merge{i}.txt") && i != lastMergedFileIndex)
                {
                    File.Delete($"merge{i}.txt");
                }
            }

            if (File.Exists("merge.txt"))
            {
                File.Delete("merge.txt");
            }

            File.Move($"merge{lastMergedFileIndex}.txt", "merge.txt");

            using (StreamWriter writer = new StreamWriter(_inputFilePath, append: true))
            {
                writer.WriteLine("\n\nРезультат:\n" + File.ReadAllText("merge.txt"));
            }

            File.Delete("merge.txt");
        }

        private void MergeTwoFiles(string file1, string file2, string outputFilePath) 
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
