using Home_task_8.Enum;

namespace Home_task_8.TrafficLights
{
    internal interface ITrafficLight
    {
        public string Name { get; }
        public HashSet<TrafficColor> GetState();
        public void TurnOff();
    }
}
