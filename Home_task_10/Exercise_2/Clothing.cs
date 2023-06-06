namespace Exercise_2
{
    public class Clothing : IProduct
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }

        public double Accept(IShippingCostVisitor visitor)
        {
            return visitor.VisitClothing(this);
        }
    }
}