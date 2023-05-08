namespace Home_task_7
{
    internal interface ITrafficLights
    {
        public string Name { get; set; } 
        public TrafficColor GetState();
    }
}
