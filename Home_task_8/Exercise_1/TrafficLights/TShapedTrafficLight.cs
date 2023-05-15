using Home_task_8.Enum;

namespace Home_task_8.TrafficLights
{
    public class TShapedTrafficLight : SimpleTrafficLight
    {
        private int _state;
        public TShapedTrafficLight() : base() 
        {
            _state = 0;
        }

        public TShapedTrafficLight(TShapedTrafficLight trafficLight) : base(trafficLight) 
        {
            _state = 0;
        }

        public TShapedTrafficLight(string name) : base(name) 
        {
            _state = 0;
        }

        public new void ChangeState()
        {
            switch(_state)
            {
                case 0:
                    _trafficColors.Clear();
                    _trafficColors.Add(TrafficColor.Red);
                    _trafficColors.Add(TrafficColor.RightGreenArrow);
                    break;
                case 1: 
                    _trafficColors.Remove(TrafficColor.RightGreenArrow); 
                    break;
                case 2: break;
                case 3: 
                    TurnOnOrange();
                    break;
                case 4:
                    _trafficColors.Clear();
                    _trafficColors.Add(TrafficColor.Green);
                    _trafficColors.Add(TrafficColor.LeftGreenArrow);
                    _trafficColors.Add(TrafficColor.RightGreenArrow);
                    break;
                case 5:
                    TurnOnOrange();
                    break;
                case 6:
                    _trafficColors.Clear();
                    _trafficColors.Add(TrafficColor.Red);
                    break;
                case 7: 
                    break;
            }
            _state = (_state + 1) % 8; // Cycle through 8 states
        }

        public void ResetToRedAndRightGreenArrow()
        {
            _state = 1;
            _trafficColors.Clear();
            _trafficColors.Add(TrafficColor.Red);
            _trafficColors.Add(TrafficColor.RightGreenArrow);
        }

        public void ResetToAllGreen()
        {
            _state = 5;
            _trafficColors.Clear();
            _trafficColors.Add(TrafficColor.Green);
            _trafficColors.Add(TrafficColor.LeftGreenArrow);
            _trafficColors.Add(TrafficColor.RightGreenArrow);
        }
    }
}
