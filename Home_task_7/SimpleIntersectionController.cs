namespace Home_task_7
{
    delegate void IntersectionHandler(SimpleIntersectionController controller, int time);
    internal class SimpleIntersectionController : IIntersectionController
    {
        const ushort ONE_SECOND = 1000;

        public event IntersectionHandler StateChange;

        private uint _timeToWork;
        private uint _greenTime;
        private uint _orangeTime;
        private uint _redTime;
        public uint TimeToWork { get { return _timeToWork; } }
        public uint GreenTime { get { return _greenTime; } }
        public uint OrangeTime { get { return _orangeTime; } }
        public uint RedTime { get { return _redTime; } }

        public void SetWorkingTime(uint time) { _timeToWork = time == 0 ? 1 : time; }
        public void SetGreenTime(uint time) { _greenTime = time == 0 ? 1 : time; }
        public void SetOrangeTime(uint time) { _orangeTime = time == 0 ? 1 : time; }
        public void SetRedTime(uint time) { _redTime = time == 0 ? 1 : time; }


        private SimpleTrafficLights _northSouth;
        private SimpleTrafficLights _southNorth;
        private SimpleTrafficLights _eastWest;
        private SimpleTrafficLights _westEast;

        public SimpleTrafficLights GetNorthSouth() { return new SimpleTrafficLights(_northSouth); } // передача копій
        public SimpleTrafficLights GetSouthNorth() { return new SimpleTrafficLights(_southNorth); }
        public SimpleTrafficLights GetEastWest() { return new SimpleTrafficLights(_eastWest); }
        public SimpleTrafficLights GetWestEast() { return new SimpleTrafficLights(_westEast); }

        public SimpleIntersectionController(uint timeToWork = 3, uint greenTime = 1, uint orangeTime = 1, uint redTime = 1)
        {
            SetGreenTime(greenTime);
            SetOrangeTime(orangeTime);
            SetRedTime(redTime);
            SetWorkingTime(timeToWork);

            _northSouth = new SimpleTrafficLights("North-South");
            _southNorth = new SimpleTrafficLights("South-North");
            _eastWest = new SimpleTrafficLights("East-West");
            _westEast = new SimpleTrafficLights("West-East");
        }

        public SimpleIntersectionController(SimpleTrafficLights northSouth, SimpleTrafficLights southNorth, SimpleTrafficLights eastWest, SimpleTrafficLights westEast)
        {
            _northSouth = new SimpleTrafficLights(northSouth); // копія
            _southNorth = new SimpleTrafficLights(southNorth);
            _eastWest = new SimpleTrafficLights(eastWest);
            _westEast = new SimpleTrafficLights(westEast);

            _timeToWork = 1;
            _greenTime = 1;
            _orangeTime = 1;
            _redTime = 1;
        }

        public void Start()
        {
            Reset();

            int time = 1;

            for (int i = 0; i < TimeToWork; i++)
            {
                StateChange?.Invoke(this, i + 1);

                if (time == GreenTime || time == GreenTime + OrangeTime || time == GreenTime + OrangeTime + RedTime)
                {
                    ChangeIntersectionState();
                }
                else if (time == GreenTime + (2 * OrangeTime) + RedTime)
                {
                    ChangeIntersectionState();
                    Reset();
                    time = 0;
                }

                Thread.Sleep(ONE_SECOND);
                time++;
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
