using Home_task_8.Enum;

namespace Home_task_8.TrafficLights
{
    public class SimpleTrafficLight : ITrafficLight
    {
        protected string _name;
        protected HashSet<TrafficColor> _trafficColors;
        protected bool IsFromGreenToRed;  // змінна яка відповідає за напрямок перемикання світлофору (з зеленого на червоний чи навпаки)

        public SimpleTrafficLight()
        {
            _name = "No name";
            _trafficColors = new HashSet<TrafficColor>() { TrafficColor.Off };
            IsFromGreenToRed = true;
        }
        public SimpleTrafficLight(SimpleTrafficLight simpleTrafficLight) // конструктор для клонування
        {
            _name = simpleTrafficLight.Name;
            _trafficColors = new HashSet<TrafficColor>(simpleTrafficLight.GetState());
            IsFromGreenToRed = simpleTrafficLight.IsFromGreenToRed;
        }

        public SimpleTrafficLight(string name)
        {
            _name = name;
            _trafficColors = new HashSet<TrafficColor> { TrafficColor.Off };
        }

        public string Name { get { return _name; } }
        public void SetName(string name) { _name = string.IsNullOrEmpty(name) ? "No Name" : name; }

        public void TurnOnRed()
        {
            _trafficColors.Clear();
            _trafficColors.Add(TrafficColor.Red);
            IsFromGreenToRed = false;
        }

        public void TurnOnOrange()
        {
            _trafficColors.Clear();
            _trafficColors.Add(TrafficColor.Orange);     
        }

        public void TurnOnGreen()
        {
            _trafficColors.Clear();
            _trafficColors.Add(TrafficColor.Green);
            IsFromGreenToRed = true;
        }

        public void TurnOff() 
        {
            _trafficColors.Clear();
            _trafficColors.Add(TrafficColor.Off);

        }

        public void ChangeState()
        {
            if (!_trafficColors.Contains(TrafficColor.Orange))
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
            }
        }

        public HashSet<TrafficColor> GetState()
        {
            return _trafficColors;
        }

        public override string ToString()
        {
            return string.Join(", ", _trafficColors);
        }
    }
}
