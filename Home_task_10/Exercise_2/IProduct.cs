using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public interface IProduct
    {
        public string Name { get; set; }
        public double Accept(IShippingCostVisitor visitor);
    }
}
