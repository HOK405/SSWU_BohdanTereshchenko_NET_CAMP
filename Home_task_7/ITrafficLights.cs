namespace Home_task_7
{
    internal interface ITrafficLights
    {
        public string Name { get; } 
        public TrafficColor GetState();
        public void TurnOff();
    }
}
