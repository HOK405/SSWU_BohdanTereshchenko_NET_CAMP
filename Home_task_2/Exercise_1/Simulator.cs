using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class Simulator
    {
        List<User> _users;

        private WaterTower _waterTower;
// Хто створює ці об'єкти ?
        public Simulator(WaterTower waterTower, List<User> users)
        {
            _users = users;
            // мала б бути глибока копія
            _waterTower = waterTower;
        }

        public void Simulate() { }
    }
}
