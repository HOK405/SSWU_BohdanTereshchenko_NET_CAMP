using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class WaterPump
    {
        private double _maxPower;     // максимальна потужність насосу
        private double _currentPower; // поточна потужність насосу
        private bool isOn;        // чи увімкнений насос

        public WaterPump(double maxPower)
        {
            if (maxPower <= 0)
                throw new ArgumentException("Максимальна потужність насосу має бути більшою за нуль.");           

            _maxPower = maxPower;
            _currentPower = 0;
            isOn = false;
        }

        public double PumpWater()
        {
            if (!isOn)
                throw new InvalidOperationException("Насос вимкнений.");           

            return _currentPower;
        }

        public void TurnOn(double power)
        {
            if (power <= 0 || power > _maxPower)
                throw new ArgumentException("Насос не може працювати з такою потужністю.");

            _currentPower = power;
            isOn = true;
        }

        public void TurnOff()
        {
            isOn = false;
        }

        public override string ToString()
        {
            string pumpStatus = isOn ? "увімкнений" : "вимкнений";
            return $"Поточна потужність насосу: {_currentPower}, Насос {pumpStatus}";
        }
    }
}
