using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    internal class SimpleTrafficLights : ITrafficLights
    {
        private string _name;
        private TrafficColor _trafficColor;
        private bool IsFromGreenToRed;  // змінна яка відповідає за напрямок перемикання світлофору (з зеленого на червоний чи навпаки)

        public string Name 
        { 
            get => _name; 
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Value must not be null.");
                }
                _name = value;
            }
        }

        public SimpleTrafficLights()
        {
            _name = "No name";
            _trafficColor = TrafficColor.Off;
            IsFromGreenToRed = true;
        }

        public SimpleTrafficLights(string name, TrafficColor trafficColor)
        {
            _name = name;
            _trafficColor = trafficColor;
        }

        public void TurnOnRed() 
        { 
            _trafficColor = TrafficColor.Red;
            IsFromGreenToRed = false;
        }

        public void TurnOnOrange() 
        { 
            _trafficColor = TrafficColor.Orange; 
        }

        public void TurnOnGreen() 
        { 
            _trafficColor = TrafficColor.Green;
            IsFromGreenToRed = true;
        }

        public void TurnOff() { _trafficColor = TrafficColor.Off; }

        public void ChangeState()
        {
            if (_trafficColor is not TrafficColor.Orange)
            {
                TurnOnOrange();
            }
            else
            {
                if (IsFromGreenToRed)
                {
                    TurnOnRed();
                }
                else
                {
                    TurnOnGreen();
                }
                IsFromGreenToRed = !IsFromGreenToRed;
            }
        }

        public TrafficColor GetState()
        {
            return _trafficColor;   
        }

        public override string ToString()
        {
            return $"Name: {_name}; State: {_trafficColor}";
        }
    }
}
