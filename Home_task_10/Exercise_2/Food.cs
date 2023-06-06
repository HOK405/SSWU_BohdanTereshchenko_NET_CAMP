namespace Exercise_2
{
    public class Food : IProduct
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public bool IsPerishable { get; set; }

        public double Accept(IShippingCostVisitor visitor)
        {
            return visitor.VisitFood(this);
        }
    }
}