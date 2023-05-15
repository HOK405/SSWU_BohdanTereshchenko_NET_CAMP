using System.Timers;
using Home_task_8.TrafficLights;
using Timer = System.Timers.Timer;

namespace Home_task_8.Controllers
{
    delegate void SimpleIntersectionHandler(SimpleIntersectionController controller, DateTime realTime);
    internal class SimpleIntersectionController : IIntersectionController
    {
        public event SimpleIntersectionHandler? StateChange;

        private uint _timeToWork;
        private uint _greenTime;
        private uint _orangeTime;
        private uint _redTime;
        public uint TimeToWork { get { return _timeToWork; } }
        public uint GreenTime { get { return _greenTime; } }
        public uint OrangeTime { get { return _orangeTime; } }
        public uint RedTime { get { return _redTime; } }

        public void SetWorkingTime(uint time) { _timeToWork = time == 0 ? 1 : time; } // валідація на 0
        public void SetGreenTime(uint time) { _greenTime = time == 0 ? 1 : time; }
        public void SetOrangeTime(uint time) { _orangeTime = time == 0 ? 1 : time; }
        public void SetRedTime(uint time) { _redTime = time == 0 ? 1 : time; }

        private Timer? _timer;
        public uint Time { get; private set; }

        private SimpleTrafficLight _northSouth;
        private SimpleTrafficLight _southNorth;
        private SimpleTrafficLight _eastWest;
        private SimpleTrafficLight _westEast;

        public SimpleTrafficLight GetNorthSouth() { return new SimpleTrafficLight(_northSouth); } // передача копій
        public SimpleTrafficLight GetSouthNorth() { return new SimpleTrafficLight(_southNorth); }
        public SimpleTrafficLight GetEastWest() { return new SimpleTrafficLight(_eastWest); }
        public SimpleTrafficLight GetWestEast() { return new SimpleTrafficLight(_westEast); }

        public SimpleIntersectionController(
                                            uint timeToWork = Constants.DEFAULT_WORK_DURATION,
                                            uint greenTime = Constants.DEFAULT_LIGHT_DURATION,
                                            uint orangeTime = Constants.DEFAULT_LIGHT_DURATION,
                                            uint redTime = Constants.DEFAULT_LIGHT_DURATION)
        {
            SetGreenTime(greenTime);
            SetOrangeTime(orangeTime);
            SetRedTime(redTime);
            SetWorkingTime(timeToWork);

            _northSouth = new SimpleTrafficLight("North-South");
            _southNorth = new SimpleTrafficLight("South-North");
            _eastWest = new SimpleTrafficLight("East-West");
            _westEast = new SimpleTrafficLight("West-East");
        }

        public SimpleIntersectionController(SimpleTrafficLight northSouth, SimpleTrafficLight southNorth, SimpleTrafficLight eastWest, SimpleTrafficLight westEast)
        {
            _northSouth = new SimpleTrafficLight(northSouth); // копія
            _southNorth = new SimpleTrafficLight(southNorth);
            _eastWest = new SimpleTrafficLight(eastWest);
            _westEast = new SimpleTrafficLight(westEast);

            _timeToWork = Constants.DEFAULT_LIGHT_DURATION;
            _greenTime = Constants.DEFAULT_LIGHT_DURATION;
            _orangeTime = Constants.DEFAULT_LIGHT_DURATION;
            _redTime = Constants.DEFAULT_LIGHT_DURATION;
        }

        public void Start()
        {
            Reset();
            Time = 0;

            _timer = new Timer(Constants.ONE_SECOND);
            _timer.Elapsed += OnTimedEvent;
            _timer.Start();
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            ++Time;
            try
            {
                StateChange?.Invoke(this, e.SignalTime);
            }
            catch (Exception)
            {
                throw;
            }

            uint totalCycleTime = GreenTime + OrangeTime + RedTime + OrangeTime;

            if (Time % totalCycleTime == GreenTime || Time % totalCycleTime == GreenTime + OrangeTime || Time % totalCycleTime == GreenTime + OrangeTime + RedTime)
            {
                ChangeIntersectionState();
            }
            else if (Time % totalCycleTime == 0)
            {
                ChangeIntersectionState();
                Reset();
            }
            if (Time >= _timeToWork)
            {
                _timer?.Stop();
                _timer?.Dispose();
            }
        }

        private void ChangeIntersectionState()
        {
            _northSouth.ChangeState();
            _southNorth.ChangeState();
            _eastWest.ChangeState();
            _westEast.ChangeState();
        }

        private void Reset()
        {
            _northSouth.TurnOnGreen();
            _southNorth.TurnOnGreen();

            _eastWest.TurnOnRed();
            _westEast.TurnOnRed();
        }

        public override string ToString()
        {
            return $"Name: {_northSouth.Name}, {_southNorth.Name}, {_eastWest.Name}, {_westEast.Name}";
        }
    }
}
