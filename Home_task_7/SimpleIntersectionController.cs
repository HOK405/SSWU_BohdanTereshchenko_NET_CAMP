using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7
{
    delegate void IntersectionHandler(SimpleIntersectionController controller, int time);
    internal class SimpleIntersectionController : IIntersectionController
    {
        public event IntersectionHandler StateChange;
        public SimpleTrafficLights NorthSouth = new SimpleTrafficLights("North-South", TrafficColor.Off);
        public SimpleTrafficLights SouthNorth = new SimpleTrafficLights("South-North", TrafficColor.Off);

        public SimpleTrafficLights EastWest = new SimpleTrafficLights("East-West", TrafficColor.Off);
        public SimpleTrafficLights WestEast = new SimpleTrafficLights("West-East", TrafficColor.Off);

        public uint TimeToWork { get; set; }
        public uint GreenTime { get; set; }
        public uint OrangeTime { get; set; }
        public uint RedTime { get; set; }

        public SimpleIntersectionController(uint timeToWork, uint greenTime, uint orangeTime, uint redTime)
        {
            GreenTime = greenTime;
            OrangeTime = orangeTime;
            RedTime = redTime;
            
            if (timeToWork < (greenTime + orangeTime + redTime))
            {
                TimeToWork = greenTime + orangeTime + redTime;
            }
            else
            {
                TimeToWork = timeToWork;
            }
        }

        public void Start()
        {
            Reset();

            int time = 1;

            for (int i = 0; i < TimeToWork; i++)
            {
                StateChange?.Invoke(this, i+1);

                if (time == GreenTime)
                {
                    ChangeIntersectionState();
                }

                if (time == GreenTime + OrangeTime)
                {
                    ChangeIntersectionState();
                }

                if (time == GreenTime + OrangeTime + RedTime)
                {
                    ChangeIntersectionState();
                }

                if (time == GreenTime + (2*OrangeTime) + RedTime)
                {
                    ChangeIntersectionState();
                    Reset();
                    time = 1;
                }

                time++;
            }
        }

        private void ChangeIntersectionState()
        {
            NorthSouth.ChangeState();
            SouthNorth.ChangeState();
            EastWest.ChangeState();
            WestEast.ChangeState();
        }

        private void Reset()
        {
            NorthSouth.TurnOnGreen();
            SouthNorth.TurnOnGreen();

            EastWest.TurnOnRed();
            WestEast.TurnOnRed();
        }
    }
}
