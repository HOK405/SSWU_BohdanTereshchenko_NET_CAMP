using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class User
    {
        private double _consumption; // швидкість витрати води користувачем

        public double Consumption
        {
            get { return _consumption; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Швидкість витрати води користувачем має бути більшою за нуль.");
                }
            }
        }
        public User(double consumption)
        {
            if (consumption <= 0)
                throw new ArgumentException("Швидкість витрати води користувачем має бути більшою за нуль.");

            _consumption = consumption;
        }

        public override string ToString()
        {
            return $"Швидкість витрати води користувачем: {_consumption}";
        }
    }
}
