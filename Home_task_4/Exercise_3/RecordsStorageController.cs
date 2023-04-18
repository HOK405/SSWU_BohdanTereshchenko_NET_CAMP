namespace Exercise_3
{
    internal class RecordsStorageController
    {
        private int _apartmentCount;
        private int _quarter;

        private List<Record> _records;
        public List<Record> GetRecords()
        {
            return _records;
        }

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
