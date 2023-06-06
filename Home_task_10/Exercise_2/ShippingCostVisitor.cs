using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class ShippingCostVisitor : IShippingCostVisitor
    {
        private const int URGENCY = 10;
        private const double OVERSIZE_PERCENTAGE = 0.05;

        public double VisitClothing(Clothing clothing)
        {
            return clothing.Weight + clothing.Size;
        }

        public double VisitElectronics(Electronics electronics)
        {
            double cost = electronics.Weight + electronics.Size;
            if (electronics.IsOversize)
            {
                cost += electronics.Price * OVERSIZE_PERCENTAGE;
            }
            return cost;
        }

        public double VisitFood(Food food)
        {
            double cost = food.Weight + food.Size;
            if (food.IsPerishable)
            {
                cost += URGENCY;
            }
            return cost;
        }
    }
}
