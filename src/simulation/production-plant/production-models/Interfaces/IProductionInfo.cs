using System;

namespace ProductionModels.Interfaces
{
    public interface IProductionInfo
    {
        double Costs { get; set; }
        DateTime DateOfProduction { get; set; }
        TimeSpan ProductionTime { get; set; }
    }
}