using ProductionModels.Interfaces;

namespace ProductionModels
{
    /// <summary>
    /// Identification data about the animal
    /// </summary>
    public class Animal : IAnimal
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
