namespace Exercise_3
{
    internal class Record
    {
        private int? _number;

        private string? _address ;

        private string? _surname ;

        private double? _inputReading ;

        private double? _outputReading ;

        private DateTime _inputDate ;

        private DateTime _outputDate;

        public int? Number
        {
            get 
            { 
                return _number; 
            }
            set
            {
                if (value <=0 || value is null)
                {
                    throw new ArgumentOutOfRangeException("Number value error.");
                }
                else
                { 
                    _number = value; 
                }
            }
        }

        public string? Address
        {
            get 
            { 
                return _address; 
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("Address value error.");
                }
                else
                {
                    _address = value;
                }
            }
        }

        public string? Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("Surname value error.");
                }
                else
                {
                    _surname = value;
                }
            }
        }

        public double? InputReading
        {
            get
            {
                return _inputReading;
            }
            set
            {
                if (value < 0 || value is null)
                {
                    throw new ArgumentNullException("Input Reading value error.");
                }
                else
                {
                    _inputReading = value;
                }    
            }
        }

        public double? OutputReading
        {
            get
            {
                return _outputReading;
            }
            set
            {
                if (value < 0 || value is null)
                {
                    throw new ArgumentNullException("Output Reading value error.");
                }
                else
                {
                    _outputReading = value;
                }
            }
        }

        public DateTime InputDate
        {
            get
            {
                return _inputDate;
            }
            set
            {
                _inputDate = value;
            }
        }

        public DateTime OutputDate
        {
            get
            {
                return _outputDate;
            }
            set
            {
                _outputDate = value;
            }
        }

        public override string ToString()
        {
            return $"Flat №:{_number}; Address: {_address}; Surname: {_surname}; Input reading: {_inputReading}; Output reading: {_outputReading}; Input Date: {_inputDate}; Output Date: {_outputDate}";
        }
    }
}
