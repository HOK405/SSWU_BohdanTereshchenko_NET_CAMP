namespace Exercise_2
{
    public class Electronics : IProduct
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public bool IsOversize { get; set; }

        public double Accept(IShippingCostVisitor visitor)
        {
            return visitor.VisitElectronics(this);
        }
    }
}