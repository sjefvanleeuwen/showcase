namespace ProductionModels.Interfaces
{
    public interface IMilkComposition
    {
        double Fats { get; set; }
        double Lactose { get; set; }
        double Minerals { get; set; }
        double Protein { get; set; }
        double Solids { get; set; }
    }
}