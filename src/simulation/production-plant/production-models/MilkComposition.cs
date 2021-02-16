using ProductionModels.Interfaces;

namespace ProductionModels
{
    /// <summary>
    /// Yak milk fat is richer in polyunsaturated fatty acids, protein, casein and fat than cow milk.
    /// </summary>
    public class MilkComposition : IMilkComposition
    {
        /// <summary>
        /// Yak milk has 16.9 - 17.7% solids
        /// </summary>
        public double Solids { get; set; }
        /// <summary>
        /// 4.9 - 5.3% protein
        /// </summary>
        public double Protein { get; set; }
        /// <summary>
        ///  5.5 - 7.2% fat
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// 4.5 - 5.0% lactose
        /// </summary>
        public double Lactose { get; set; }
        /// <summary>
        /// 0.8 - 0.9% minerals
        /// </summary>
        public double Minerals { get; set; }
    }
}