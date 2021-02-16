namespace ProductionModels.Interfaces
{
    /// <summary>
    /// Identification data about the animal.
    /// </summary>
    public interface IAnimal
    {
        /// <summary>
        /// Identification code
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }
    }
}