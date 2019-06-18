namespace StarWarsProject.Model
{
    public interface ICalculations
    {
        /// <summary>
        /// Intefarce class with CalculateStop method signature.
        /// </summary>
        /// <param name="distance">Distance to check how many stops will be needed.</param>
        /// <returns></returns>
        int CalculateStops(int distance);
    }
}