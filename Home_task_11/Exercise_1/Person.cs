using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    public class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is Person otherPerson))
            {
                throw new ArgumentException("Object is not a Person");
            }

            return Age.CompareTo(otherPerson.Age);
        }

        public override string ToString()
        {
            return $"{Name}, {Age} years old";
        }
    }

}
