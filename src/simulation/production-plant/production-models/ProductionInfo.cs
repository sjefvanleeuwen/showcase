using ProductionModels.Interfaces;
using System;

namespace ProductionModels
{
    public class ProductionInfo : IProductionInfo
    {
        public DateTime DateOfProduction { get; set; }
        public TimeSpan ProductionTime { get; set; }
        public double Costs { get; set; }
    }
}
