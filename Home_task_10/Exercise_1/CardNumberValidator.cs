namespace Exercise_1
{
    public class CardNumberValidator
    {
        private List<PaymentSystem> _paymentSystems;

        public CardNumberValidator(List<PaymentSystem> paymentSystems)
        {
            _paymentSystems = new List<PaymentSystem> (paymentSystems);
        }


        public (string paymentSystem, string cardNumber) Check(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");

            string paymentSystemName = "Undefined";

            foreach (PaymentSystem paymentSystem in _paymentSystems)
            {
                if (paymentSystem.NumberLengths.Contains((ushort)cardNumber.Length)) // перевірка довжини номеру карти
                {
                    if (paymentSystem.StartNumbers.Any(cardNumber.StartsWith)) // перевірка початку номеру карти
                    {
                        if (LuhnValidate(cardNumber)) // перевірка за алгоритмом Луна
                        {
                            return (paymentSystem.Name, cardNumber);
                        }
                    }
                }
            }

            return (paymentSystemName, cardNumber);
        }


        private bool LuhnValidate(string cardNumber) // алгоритм Луна
        {
            int sum = 0;
            int nDigits = cardNumber.Length;
            bool isSecond = false;

            for (int i = nDigits - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0';
                if (isSecond)
                {
                    digit *= 2;
                }

                sum += digit / 10;
                sum += digit % 10;

                isSecond = !isSecond;
            }
            return (sum % 10 == 0);
        }
    }
}
