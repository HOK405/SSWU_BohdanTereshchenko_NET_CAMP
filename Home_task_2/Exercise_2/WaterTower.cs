using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class WaterTower
    {
        protected double _maxLevel; // максимальний об'єм вежі
        protected double _currentLevel; // поточний рівень води в вежі

        private WaterPump _waterPump;

        public WaterTower(double maxLevel, WaterPump waterPump)
        {
            if (maxLevel <= 0)
                throw new ArgumentException("Максимальний об'єм вежі має бути більшим за нуль.");

            _maxLevel = maxLevel;
            _currentLevel = 0;
            _waterPump = waterPump;
        }

        public void Update() { }

        public override string ToString() // повертає рядок, що описує стан сутності
        {
            return $"Максимальний об'єм вежі: {_maxLevel}, Поточний рівень води: {_currentLevel}";
        }
    }
}
