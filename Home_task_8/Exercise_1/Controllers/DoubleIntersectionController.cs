using Home_task_8.TrafficLights;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Home_task_8.Controllers
{
    delegate void DoubleIntersectionHandler(DoubleIntersectionController controller, DateTime realTime);
    internal class DoubleIntersectionController 
    {
        public event DoubleIntersectionHandler? StateChange;

        private uint _timeToWork;

        public void SetWorkingTime(uint time) { _timeToWork = time == 0 ? 1 : time; } // валідація на 0

        private Timer? _timer;
        public uint Time { get; private set; }

        private TShapedTrafficLight _northSouth;
        private TShapedTrafficLight _southNorth;

        private SimpleTrafficLight _eastWest;
        private SimpleTrafficLight _westEast;

        public TShapedTrafficLight GetNorthSouth() { return new TShapedTrafficLight(_northSouth); } // передача копій
        public TShapedTrafficLight GetSouthNorth() { return new TShapedTrafficLight(_southNorth); }
        public SimpleTrafficLight GetEastWest() { return new SimpleTrafficLight(_eastWest); }
        public SimpleTrafficLight GetWestEast() { return new SimpleTrafficLight(_westEast); }

        public DoubleIntersectionController(TShapedTrafficLight northSouth, 
                                           TShapedTrafficLight southNorth, 
                                           SimpleTrafficLight eastWest, 
                                           SimpleTrafficLight westEast)
        {
            _northSouth = northSouth;
            _southNorth = southNorth;
            _eastWest = eastWest;
            _westEast = westEast;
        }

        public DoubleIntersectionController(uint timeToWork = Constants.DEFAULT_WORK_DURATION)
        {
            SetWorkingTime(timeToWork);

            _northSouth = new TShapedTrafficLight("North-South");
            _southNorth = new TShapedTrafficLight("South-North");
            _eastWest = new SimpleTrafficLight("East-West");
            _westEast = new SimpleTrafficLight("West-East");
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

            ChangeIntersectionState();

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
            _northSouth.ResetToAllGreen();
            _southNorth.ResetToRedAndRightGreenArrow();

            _eastWest.TurnOnRed();
            _westEast.TurnOnRed();
        }
    }
}
