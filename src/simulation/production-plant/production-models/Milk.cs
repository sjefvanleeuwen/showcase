using ProductionModels.Interfaces;

namespace ProductionModels
{
    /// <summary>
    /// Contains the average daily milk production, animal identification and milk nutritional composition.
    /// </summary>
    public class Milk : IMilk
    {
        /// <summary>
        /// Reference to the animal producing the milk.
        /// </summary>
        public IAnimal Animal { get; set; }
        /// <summary>
        /// Amount of milk in kilograms. The Yak average daily milk yield was 1.09 kg (range from 0.3-2.3 kg)
        /// </summary>
        public double Kg { get; set; }
        /// <summary>
        /// Composition of the Milk
        /// </summary>
        public IMilkComposition Composition { get; set; }
        public IProductionInfo ProductionInfo { get; set; }
    }
}