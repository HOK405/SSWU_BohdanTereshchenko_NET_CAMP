namespace Exercise_2
{
    public interface IShippingCostVisitor
    {
        double VisitFood(Food food);
        double VisitElectronics(Electronics electronics);
        double VisitClothing(Clothing clothing);
    }
}