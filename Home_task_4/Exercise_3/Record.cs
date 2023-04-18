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

        public Record()
        {

        }

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
                    throw new ArgumentOutOfRangeException();
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
                    throw new ArgumentNullException();
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
                    throw new ArgumentNullException();
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
                    throw new ArgumentNullException();
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
                    throw new ArgumentNullException();
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
