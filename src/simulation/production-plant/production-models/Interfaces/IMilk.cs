namespace ProductionModels.Interfaces
{
    public interface IMilk
    {
        IAnimal Animal { get; set; }
        IMilkComposition Composition { get; set; }
        double Kg { get; set; }
        IProductionInfo ProductionInfo { get; set; }
    }
}