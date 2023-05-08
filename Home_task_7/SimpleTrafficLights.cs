namespace Home_task_7
{
    internal class SimpleTrafficLights : ITrafficLights
    {
        private string _name;
        private TrafficColor _trafficColor;
        private bool IsFromGreenToRed;  // змінна яка відповідає за напрямок перемикання світлофору (з зеленого на червоний чи навпаки)

        public SimpleTrafficLights()
        {
            SetName("No name");
            _trafficColor = TrafficColor.Off;
            IsFromGreenToRed = true;
        }
        public SimpleTrafficLights(SimpleTrafficLights simpleTrafficLights) // конструктор для клонування
        {
            _name = simpleTrafficLights.Name;
            _trafficColor = simpleTrafficLights._trafficColor;
            IsFromGreenToRed = simpleTrafficLights.IsFromGreenToRed;
        }

        public SimpleTrafficLights(string name)
        {
            _name = name;
            _trafficColor = TrafficColor.Off;
        }

        public string Name { get { return _name; } }
        public void SetName(string name) { _name = string.IsNullOrEmpty(name) ? "No Name" : name; }

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
