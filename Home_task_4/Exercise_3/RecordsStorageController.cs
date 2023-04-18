namespace Exercise_3
{
    internal class RecordsStorageController
    {
        private float _price;

        private int _apartmentCount;

        private int _quarter;

        private List<Record> _records;

        public RecordsStorageController(List<Record> records, int apartmentCount = 0, int quarter = 0)
        {
            _records = records;
            _apartmentCount = apartmentCount;
            _quarter = quarter;
        }     
        public int ApartmentCount
        {
            get 
            { 
                return _apartmentCount; 
            }
        }
        public int Quarter
        {
            get
            {
                return _quarter;
            }
        }
        public List<Record> GetRecords()
        {
            return _records;
        }
        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than zero.");
                }
            }
        }

        public List<Record> GetNoConsumptionRecords()
        {
            List<Record> resultRecords = new List<Record>();
            foreach (Record record in _records)
            {
                if (record.InputReading.Equals(record.OutputReading))
                {
                    resultRecords.Add(record);
                }
            }
            return resultRecords;
        }

        public Record GetMaxConsumptionRecord()
        {
            Record resultRecord = new Record();
            double? max = 0;
            foreach (Record record in _records)
            {
                if ((record.OutputReading - record.InputReading) > max)
                {
                    resultRecord = record;
                    max = resultRecord.OutputReading - resultRecord.InputReading;
                }
            }
            return resultRecord;
        }

        public Record? GetRecordByNumber(int? number)
        {
            if (number <=0 || number is null)
            {
                throw new ArgumentException();
            }

            foreach (Record record in _records)
            {
                if(record.Number == number)
                { 
                    return record; 
                }
            }

            return null;
        }
    }
}
