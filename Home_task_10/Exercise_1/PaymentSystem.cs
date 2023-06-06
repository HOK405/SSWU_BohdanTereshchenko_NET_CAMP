namespace Exercise_1
{
    public class PaymentSystem
    {
        private List<string> _startNumbers;
        private List<ushort> _numberLength;

        public string Name { get; set; }

        public PaymentSystem(string name, List<string> startNumbers, List<ushort> digits)
        {
            Name = name;
            _startNumbers = new List<string>(startNumbers);
            _numberLength = new List<ushort>(digits);
        }

        public List<string> StartNumbers
        {
            get
            {
                return new List<string>(_startNumbers);
            }
            set
            {
                if (value != null)
                {
                    _startNumbers = value;
                }
            }
        }

        public List<ushort> NumberLengths
        {
            get
            {
                return new List<ushort>(_numberLength);
            }
            set
            {
                if (value != null)
                {
                    _numberLength = value;
                }
            }
        }
    }

}
